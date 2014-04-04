#region Copyright (c) 2006-2013 nHydrate.org, All Rights Reserved
// -------------------------------------------------------------------------- *
//                           NHYDRATE.ORG                                     *
//              Copyright (c) 2006-2013 All Rights reserved                   *
//                                                                            *
//                                                                            *
// Permission is hereby granted, free of charge, to any person obtaining a    *
// copy of this software and associated documentation files (the "Software"), *
// to deal in the Software without restriction, including without limitation  *
// the rights to use, copy, modify, merge, publish, distribute, sublicense,   *
// and/or sell copies of the Software, and to permit persons to whom the      *
// Software is furnished to do so, subject to the following conditions:       *
//                                                                            *
// The above copyright notice and this permission notice shall be included    *
// in all copies or substantial portions of the Software.                     *
//                                                                            *
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,            *
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES            *
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.  *
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY       *
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,       *
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE          *
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                     *
// -------------------------------------------------------------------------- *
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nHydrate.Generator.Models;
using nHydrate.Generator.Common.GeneratorFramework;

namespace nHydrate.Generator.EFDAL.Generators.EFSSDL
{
	public class SSDLMySqlTemplate : EFDALBaseTemplate
	{
		private readonly StringBuilder sb = new StringBuilder();

		public SSDLMySqlTemplate(ModelRoot model)
			: base(model)
		{
		}

		#region BaseClassTemplate overrides
		public override string FileName
		{
			get { return string.Format("{0}.MySql.ssdl", _model.ProjectName); }
		}


		public override string FileContent
		{
			get
			{
				try
				{
					GenerateContent();
					return sb.ToString();
				}
				catch (Exception ex)
				{
					throw;
				}

			}
		}

		#endregion

		#region GenerateContent

		private void GenerateContent()
		{
			sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");

			//MySQL Modification
			sb.AppendFormat("<Schema Namespace=\"{0}.Store\" Alias=\"Self\" Provider=\"MySql.Data.MySqlClient\" ProviderManifestToken=\"\" xmlns:store=\"http://schemas.microsoft.com/ado/2007/12/edm/EntityStoreSchemaGenerator\" xmlns=\"http://schemas.microsoft.com/ado/2009/02/edm/ssdl\">", this.GetLocalNamespace()).AppendLine();

			AppendEntityContainer();
			AppendEntityType();
			AppendAssociations();
			AppendFunctions();
			AppendScalerFunctions();
			sb.AppendLine("</Schema>");
		}

		private void AppendFunctions()
		{
			if (_model.Database.UseGeneratedCRUD)
			{
				if (_model.Database.Tables.Count(x => x.Generated && x.AssociativeTable && (x.TypedTable != TypedTableConstants.EnumOnly)) > 0)
				{
					sb.AppendLine("	<Function Name=\"" + _model.GetStoredProcedurePrefix() + "_NOOP\" Aggregate=\"false\" BuiltIn=\"false\" NiladicFunction=\"false\" IsComposable=\"false\" ParameterTypeSemantics=\"AllowImplicitConversion\" Schema=\"dbo\">");
					sb.AppendLine("	</Function>");
				}
			}

			AppendTableStoreProcedureFunctions();
			AppendCustomSpFunctions();

		}

		private void AppendScalerFunctions()
		{
			foreach (var function in _model.Database.Functions.Where(x => !x.IsTable))
			{
				sb.AppendLine("	<Function Name=\"" + function.DatabaseName + "\" ReturnType=\"" + (function.Columns.First().Object as FunctionColumn).DataType.ToEFMySqlDBType().ToLower() + "\" Aggregate=\"false\" BuiltIn=\"false\" NiladicFunction=\"false\" IsComposable=\"true\" ParameterTypeSemantics=\"AllowImplicitConversion\" Schema=\"" + function.GetSQLSchema() + "\">");
				foreach (var parameter in function.GetParameters().Where(x => x.Generated))
				{
					sb.AppendLine("		<Parameter Name=\"" + parameter.DatabaseName + "\" Type=\"" + parameter.DataType.ToEFMySqlDBType().ToLower() + "\" Mode=\"In\" />");
				}
				sb.AppendLine("	</Function>");
			}
		}

		private void AppendCustomSpFunctions()
		{
			//Stored Procedures
			foreach (var storedProcedure in _model.Database.CustomStoredProcedures.Where(x => x.Generated).OrderBy(x => x.Name))
			{
				sb.AppendLine("	<Function Name=\"" + storedProcedure.PascalName + "\" Aggregate=\"false\" BuiltIn=\"false\" NiladicFunction=\"false\" IsComposable=\"false\" ParameterTypeSemantics=\"AllowImplicitConversion\" Schema=\"" + storedProcedure.GetSQLSchema() + "\">");
				foreach (var param in storedProcedure.GetParameters().Where(x => x.Generated).OrderBy(x => x.PascalName))
				{
					sb.AppendLine("		<Parameter Name=\"" + param.PascalName + "\" Type=\"" + param.DataType.ToEFMySqlDBType() + "\" Mode=\"" + (param.IsOutputParameter ? "InOut" : "In") + "\" />");
				}
				sb.AppendLine("	</Function>");
			}

			//Functions
			foreach (var function in _model.Database.Functions.Where(x => x.Generated && x.IsTable).OrderBy(x => x.Name))
			{
				sb.AppendLine("	<Function Name=\"" + function.PascalName + "_SPWrapper\" Aggregate=\"false\" BuiltIn=\"false\" NiladicFunction=\"false\" IsComposable=\"false\" ParameterTypeSemantics=\"AllowImplicitConversion\" Schema=\"" + function.GetSQLSchema() + "\">");
				foreach (var param in function.GetParameters().Where(x => x.Generated).OrderBy(x => x.PascalName))
				{
					sb.AppendLine("		<Parameter Name=\"" + param.PascalName + "\" Type=\"" + param.DataType.ToEFMySqlDBType() + "\" Mode=\"" + (param.IsOutputParameter ? "InOut" : "In") + "\" />");
				}
				sb.AppendLine("	</Function>");
			}
		}

		private void AppendTableStoreProcedureFunctions()
		{
			if (!_model.Database.UseGeneratedCRUD)
				return;

			foreach (var currentTable in _model.Database.Tables.Where(x => x.Generated && (x.TypedTable != TypedTableConstants.EnumOnly)))
			{
				//if (currentTable.AllowAuditTracking)
				//{
				//  //AUDITS
				//  sb.AppendFormat("	<Function Name=\"" + _model.GetStoredProcedurePrefix() + "_{0}__AUDIT\" Aggregate=\"false\" BuiltIn=\"false\" NiladicFunction=\"false\" IsComposable=\"false\" ParameterTypeSemantics=\"AllowImplicitConversion\" Schema=\"" + currentTable.GetSQLSchema() + "\">", currentTable.PascalName).AppendLine();
				//  foreach (var primaryKeyColumn in currentTable.PrimaryKeyColumns)
				//  {
				//    sb.AppendLine("		<Parameter Name=\"" + primaryKeyColumn.DatabaseName + "\" Type=\"" + primaryKeyColumn.EFDatabaseType(false) + "\" Mode=\"In\" />");
				//  }
				//  sb.AppendLine("		<Parameter Name=\"auditType\" Type=\"int\" Mode=\"In\" />");
				//  sb.AppendLine("		<Parameter Name=\"pageOffset\" Type=\"int\" Mode=\"In\" />");
				//  sb.AppendLine("		<Parameter Name=\"recordsPerPage\" Type=\"int\" Mode=\"In\" />");
				//  sb.AppendLine("	</Function>");
				//}

				var moduleSuffix = string.Empty;
				if (!string.IsNullOrEmpty(_model.ModuleName))
					moduleSuffix = _model.ModuleName + "_";

				//DELETE
				sb.AppendFormat("	<Function Name=\"" + _model.GetStoredProcedurePrefix() + "_{0}Delete\" Aggregate=\"false\" BuiltIn=\"false\" NiladicFunction=\"false\" IsComposable=\"false\" ParameterTypeSemantics=\"AllowImplicitConversion\" Schema=\"" + currentTable.GetSQLSchema() + "\">", currentTable.PascalName + "_" + moduleSuffix).AppendLine();
				foreach (var primaryKeyColumn in currentTable.PrimaryKeyColumns)
				{
					sb.AppendFormat("		<Parameter Name=\"Original_{0}\" Type=\"{1}\" Mode=\"In\" />",
						primaryKeyColumn.DatabaseName,
						primaryKeyColumn.DataType.ToEFMySqlDBType()).AppendLine();
				}

				foreach (var relation in currentTable.ChildRoleRelationsFullHierarchy)
				{
					var parentTable = (Table)relation.ParentTableRef.Object;
					var childTable = (Table)relation.ChildTableRef.Object;
					foreach (ColumnRelationship columnRelationship in relation.ColumnRelationships)
					{
						var parentColumn = (Column)columnRelationship.ParentColumnRef.Object;
						var childColumn = (Column)columnRelationship.ChildColumnRef.Object;
						if (parentTable.Generated && childTable.Generated)
						{
							sb.AppendFormat("		<Parameter Name=\"{0}\" Type=\"{1}\" Mode=\"In\" />",
								relation.DatabaseRoleName + parentTable.DatabaseName + "_" + parentColumn.DatabaseName,
								childColumn.DataType.ToEFMySqlDBType()).AppendLine();
						}
					}
				}

				sb.AppendLine("	</Function>");

				//INSERT
				sb.AppendFormat("	<Function Name=\"" + _model.GetStoredProcedurePrefix() + "_{0}Insert\" Aggregate=\"false\" BuiltIn=\"false\" NiladicFunction=\"false\" IsComposable=\"false\" ParameterTypeSemantics=\"AllowImplicitConversion\" Schema=\"" + currentTable.GetSQLSchema() + "\">", currentTable.PascalName + "_" + moduleSuffix).AppendLine();
				foreach (var currentColumn in currentTable.GetColumnsFullHierarchy().Where(x => x.Generated && !x.ComputedColumn && !x.IsReadOnly))
				{
					if (!currentColumn.PrimaryKey || currentTable.GetBasePKColumn(currentColumn).Identity != IdentityTypeConstants.Database)
						sb.AppendFormat("		<Parameter Name=\"{0}\" Type=\"{1}\" Mode=\"In\" />", currentColumn.DatabaseName, currentColumn.DataType.ToEFMySqlDBType()).AppendLine();
				}

				//No audit field for Associative tables
				if (!currentTable.AssociativeTable)
				{
					if (currentTable.AllowCreateAudit)
					{
						sb.AppendFormat("		<Parameter Name=\"{0}\" Type=\"datetime\" Mode=\"In\" />", _model.Database.CreatedDateDatabaseName).AppendLine();
						sb.AppendFormat("		<Parameter Name=\"{0}\" Type=\"varchar\" Mode=\"In\" />", _model.Database.CreatedByDatabaseName).AppendLine();
					}

					if (currentTable.AllowModifiedAudit)
					{
						sb.AppendFormat("		<Parameter Name=\"{0}\" Type=\"varchar\" Mode=\"In\" />", _model.Database.ModifiedByDatabaseName).AppendLine();
					}
				}

				sb.AppendLine("	</Function>");

				//UPDATE
				if (!currentTable.AssociativeTable)
				{
					sb.AppendLine("	<Function Name=\"" + _model.GetStoredProcedurePrefix() + "_" + currentTable.PascalName + "_" + moduleSuffix + "Update" + "\" Aggregate=\"false\" BuiltIn=\"false\" NiladicFunction=\"false\" IsComposable=\"false\" ParameterTypeSemantics=\"AllowImplicitConversion\" Schema=\"" + currentTable.GetSQLSchema() + "\">");
					foreach (var currentColumn in currentTable.GetColumnsFullHierarchy().Where(x => x.Generated && !x.ComputedColumn && !x.IsReadOnly))
					{
						if (!currentColumn.PrimaryKey)
							sb.AppendFormat("		<Parameter Name=\"{0}\" Type=\"{1}\" Mode=\"In\" />", currentColumn.DatabaseName, currentColumn.DataType.ToEFMySqlDBType()).AppendLine();
					}

					if (currentTable.AllowModifiedAudit)
					{
						sb.AppendFormat("		<Parameter Name=\"{0}\" Type=\"datetime\" Mode=\"In\" />", _model.Database.ModifiedDateDatabaseName).AppendLine();
						sb.AppendFormat("		<Parameter Name=\"{0}\" Type=\"varchar\" Mode=\"In\" />", _model.Database.ModifiedByDatabaseName).AppendLine();
					}

					foreach (var primaryKeyColumn in currentTable.PrimaryKeyColumns)
					{
						sb.AppendFormat("		<Parameter Name=\"Original_{0}\" Type=\"{1}\" Mode=\"In\" />", primaryKeyColumn.DatabaseName, primaryKeyColumn.DataType.ToEFMySqlDBType()).AppendLine();
					}

					if (currentTable.AllowTimestamp)
					{
						//MySQL Modification
						sb.AppendFormat("		<Parameter Name=\"Original_{0}\" Type=\"binary\" MaxLength=\"8\" Mode=\"In\" />", _model.Database.TimestampDatabaseName).AppendLine();
					}

					sb.AppendLine("	</Function>");
				}

			}
		}

		private void AppendAssociations()
		{
			foreach (var relation in _model.Database.Relations.AsEnumerable())
			{
				var parentEntity = (Table)relation.ParentTableRef.Object;
				var childEntity = (Table)relation.ChildTableRef.Object;
				if (parentEntity != null &&
					childEntity != null &&
					parentEntity.Generated &&
					childEntity.Generated &&
					(parentEntity.TypedTable != TypedTableConstants.EnumOnly) && (childEntity.TypedTable != TypedTableConstants.EnumOnly))
				{
					var parentColumns = new StringBuilder();
					var childColumns = new StringBuilder();
					foreach (var columnRelation in relation.ColumnRelationships.AsEnumerable())
					{
						parentColumns.AppendFormat("				<PropertyRef Name=\"{0}\" />", columnRelation.ParentColumn.DatabaseName).AppendLine();
						childColumns.AppendFormat("				<PropertyRef Name=\"{0}\" />", columnRelation.ChildColumn.DatabaseName).AppendLine();
					}

					sb.AppendFormat("	<Association Name=\"{0}\">", relation.GetDatabaseFkName()).AppendLine();
					sb.AppendFormat("		<End Role=\"{0}\" Type=\"{1}.Store.{0}\" Multiplicity=\"{2}\" />", parentEntity.DatabaseName, this.GetLocalNamespace(), relation.ParentMultiplicity()).AppendLine();
					if (childEntity == parentEntity)
					{
						//Self-ref append role name
						sb.AppendFormat("		<End Role=\"{3}\" Type=\"{1}.Store.{0}\" Multiplicity=\"{2}\" />", childEntity.DatabaseName, this.GetLocalNamespace(), relation.ChildMultiplicity(), childEntity.DatabaseName + "_" + relation.DatabaseRoleName).AppendLine();
					}
					else
					{
						//Non self-ref
						sb.AppendFormat("		<End Role=\"{0}\" Type=\"{1}.Store.{0}\" Multiplicity=\"{2}\" />", childEntity.DatabaseName, this.GetLocalNamespace(), relation.ChildMultiplicity()).AppendLine();
					}
					sb.AppendLine("		<ReferentialConstraint>");
					sb.AppendFormat("			<Principal Role=\"{0}\">", parentEntity.DatabaseName).AppendLine();
					sb.Append(parentColumns.ToString());
					sb.AppendLine("			</Principal>");

					if (childEntity == parentEntity)
					{
						//Self-ref append role name
						sb.AppendFormat("			<Dependent Role=\"{0}\">", childEntity.DatabaseName + "_" + relation.DatabaseRoleName).AppendLine();
					}
					else
					{
						//Non self-ref
						sb.AppendFormat("			<Dependent Role=\"{0}\">", childEntity.DatabaseName).AppendLine();
					}

					sb.Append(childColumns.ToString());
					sb.AppendLine("			</Dependent>");
					sb.AppendLine("		</ReferentialConstraint>");
					sb.AppendLine("	</Association>");

				}
			}

			foreach (var relation in _model.Database.ViewRelations.AsEnumerable())
			{
				var parentEntity = relation.ParentTable;
				var childEntity = relation.ChildView;
				{
					var parentColumns = new StringBuilder();
					var childColumns = new StringBuilder();

					if (parentEntity != null &&
						childEntity != null &&
						parentEntity.Generated &&
						childEntity.Generated &&
						(parentEntity.TypedTable != TypedTableConstants.EnumOnly))
					{
						foreach (var columnRelation in relation.ColumnRelationships.AsEnumerable())
						{
							parentColumns.AppendFormat("				<PropertyRef Name=\"{0}\" />", columnRelation.ParentColumn.DatabaseName).AppendLine();
							childColumns.AppendFormat("				<PropertyRef Name=\"{0}\" />", columnRelation.ChildColumn.DatabaseName).AppendLine();
						}

						sb.AppendFormat("	<Association Name=\"{0}\">", relation.GetDatabaseFkName()).AppendLine();
						sb.AppendFormat("		<End Role=\"{0}\" Type=\"{1}.Store.{0}\" Multiplicity=\"0..1\" />", parentEntity.DatabaseName, this.GetLocalNamespace()).AppendLine();
						sb.AppendFormat("		<End Role=\"{0}\" Type=\"{1}.Store.{0}\" Multiplicity=\"*\" />", childEntity.DatabaseName, this.GetLocalNamespace()).AppendLine();
						sb.AppendLine("		<ReferentialConstraint>");
						sb.AppendFormat("			<Principal Role=\"{0}\">", parentEntity.DatabaseName).AppendLine();
						sb.Append(parentColumns.ToString());
						sb.AppendLine("			</Principal>");
						sb.AppendFormat("			<Dependent Role=\"{0}\">", childEntity.DatabaseName).AppendLine();
						sb.Append(childColumns.ToString());
						sb.AppendLine("			</Dependent>");
						sb.AppendLine("		</ReferentialConstraint>");
						sb.AppendLine("	</Association>");

					}
				}
			}

		}

		private void AppendEntityType()
		{
			foreach (var currentTable in _model.Database.Tables.Where(x => x.Generated && (x.TypedTable != TypedTableConstants.EnumOnly)).OrderBy(x => x.Name))
			{
				sb.AppendFormat("	<EntityType Name=\"{0}\">", currentTable.DatabaseName).AppendLine();
				sb.AppendLine();
				if (currentTable.PrimaryKeyColumns.Count > 0)
				{
					sb.AppendLine("		<Key>");
					foreach (var column in currentTable.PrimaryKeyColumns)
					{
						sb.AppendFormat("			<PropertyRef Name=\"{0}\" />", column.DatabaseName).AppendLine();
					}
					sb.AppendLine("		</Key>");
				}

				foreach (var column in currentTable.GetColumns().Where(x => x.Generated).OrderBy(x => x.Name))
				{
					GeneratePropertyNode(column);
				}
				this.GenerateAuditColumns(currentTable);
				sb.AppendLine("	</EntityType>");
			}

			foreach (var currentView in _model.Database.CustomViews.Where(x => x.Generated).OrderBy(x => x.Name))
			{
				sb.AppendLine("	<EntityType Name=\"" + currentView.PascalName + "\">");
				sb.AppendLine("		<Key>");
				sb.AppendLine("			<PropertyRef Name=\"__pk\" />");
				sb.AppendLine("		</Key>");
				sb.AppendLine("		<Property Name=\"__pk\" Type=\"varchar\" Nullable=\"false\" />");
				foreach (var column in currentView.GeneratedColumns)
				{
					GeneratePropertyNode(column);
				}
				sb.AppendLine("		</EntityType>");
			}

		}

		private void AppendEntityContainer()
		{
			sb.AppendFormat("	<EntityContainer Name=\"{0}ModelStoreContainer\">", _model.ProjectName).AppendLine();
			foreach (var currentTable in _model.Database.Tables.Where(x => x.Generated && (x.TypedTable != TypedTableConstants.EnumOnly)).OrderBy(x => x.Name))
			{
				sb.AppendFormat("		<EntitySet Name=\"{0}\" EntityType=\"{1}.Store.{0}\" store:Type=\"Tables\" Schema=\"" + currentTable.GetSQLSchema() + "\" />", currentTable.DatabaseName, this.GetLocalNamespace()).AppendLine();
			}

			foreach (var currentView in _model.Database.CustomViews.Where(x => x.Generated).OrderBy(x => x.Name))
			{
				sb.AppendFormat("		<EntitySet Name=\"{0}\" EntityType=\"{1}.Store.{0}\" store:Type=\"Views\" store:Schema=\"" + currentView.GetSQLSchema() + "\" store:Name=\"{0}\">", currentView.PascalName, this.GetLocalNamespace()).AppendLine();
				sb.AppendLine("			<DefiningQuery>");
				sb.AppendLine("				SELECT");
				sb.AppendLine("				UUID() as __pk,");

				var columns = new List<string>();
				foreach (var a in currentView.GeneratedColumns)
				{
					columns.Add("				`" + currentView.DatabaseName + "`.`" + a.DatabaseName + "` AS `" + a.DatabaseName + "`");
				}
				sb.AppendLine(string.Join(",\r\n", columns.ToArray()));

				sb.AppendLine("				FROM `" + currentView.DatabaseName + "`");
				sb.AppendLine("			</DefiningQuery>");
				sb.AppendLine("		</EntitySet>");
			}

			foreach (var relation in _model.Database.Relations.AsEnumerable())
			{
				var parentEntity = (Table)relation.ParentTableRef.Object;
				var childEntity = (Table)relation.ChildTableRef.Object;
				if (parentEntity != null &&
					childEntity != null &&
					parentEntity.Generated &&
					childEntity.Generated &&
					//!parentEntity.IsTypeTable &&
					//!childEntity.IsTypeTable &&
					relation.IsGenerated &&
					(parentEntity.TypedTable != TypedTableConstants.EnumOnly) && (childEntity.TypedTable != TypedTableConstants.EnumOnly))
				{
					sb.AppendFormat("		<AssociationSet Name=\"{0}\" Association=\"{1}.Store.{0}\">", relation.GetDatabaseFkName(), this.GetLocalNamespace()).AppendLine();
					sb.AppendFormat("			<End Role=\"{0}\" EntitySet=\"{0}\" />", parentEntity.DatabaseName).AppendLine();
					if (parentEntity == childEntity)
					{
						//Self-Ref then append role
						sb.AppendFormat("			<End Role=\"{0}\" EntitySet=\"{1}\" />", childEntity.DatabaseName + "_" + relation.DatabaseRoleName, childEntity.DatabaseName).AppendLine();
					}
					else
					{
						//Non self-ref
						sb.AppendFormat("			<End Role=\"{0}\" EntitySet=\"{0}\" />", childEntity.DatabaseName).AppendLine();
					}
					sb.AppendFormat("		</AssociationSet>").AppendLine();
				}
			}

			foreach (var relation in _model.Database.ViewRelations.AsEnumerable())
			{
				var parentEntity = relation.ParentTable;
				var childEntity = relation.ChildView;
				if (parentEntity != null &&
					childEntity != null &&
					parentEntity.Generated &&
					childEntity.Generated &&
					relation.IsGenerated &&
					(parentEntity.TypedTable != TypedTableConstants.EnumOnly))
				{
					sb.AppendFormat("		<AssociationSet Name=\"{0}\" Association=\"{1}.Store.{0}\">", relation.GetDatabaseFkName(), this.GetLocalNamespace()).AppendLine();
					sb.AppendFormat("			<End Role=\"{0}\" EntitySet=\"{0}\" />", parentEntity.DatabaseName).AppendLine();
					sb.AppendFormat("			<End Role=\"{0}\" EntitySet=\"{0}\" />", childEntity.DatabaseName).AppendLine();
					sb.AppendFormat("		</AssociationSet>").AppendLine();
				}
			}

			sb.AppendLine("	</EntityContainer>");
		}

		private void GenerateAuditColumns(Table currentTable)
		{
			if (currentTable.AssociativeTable) return;

			if (currentTable.AllowModifiedAudit)
			{
				sb.AppendFormat("		<Property Name=\"{0}\" Type=\"varchar\" MaxLength=\"50\" />", _model.Database.ModifiedByDatabaseName).AppendLine();
				sb.AppendFormat("		<Property Name=\"{0}\" Type=\"datetime\" />", _model.Database.ModifiedDateDatabaseName).AppendLine();
			}

			if (currentTable.AllowCreateAudit)
			{
				sb.AppendFormat("		<Property Name=\"{0}\" Type=\"varchar\" MaxLength=\"50\" />", _model.Database.CreatedByDatabaseName).AppendLine();
				sb.AppendFormat("		<Property Name=\"{0}\" Type=\"datetime\" />", _model.Database.CreatedDateDatabaseName).AppendLine();
			}

			if (currentTable.AllowTimestamp)
			{
				//MySQL Modification
				sb.AppendFormat("		<Property Name=\"{0}\" Type=\"binary\" MaxLength=\"8\" Nullable=\"false\" />", _model.Database.TimestampDatabaseName).AppendLine();
			}
		}

		private void GeneratePropertyNode(ColumnBase column)
		{
			//Append Name and Type
			sb.AppendFormat("		<Property Name=\"{0}\" Type=\"{1}\" ", column.DatabaseName, Column.MySqlDatatypeMap(column.DataType, true).ToLower());

			//Append Nullable
			sb.Append("Nullable=\"" + (column.AllowNull ? "true" : "false") + "\" ");

			//Append MaxLength
			if (column.DataType == System.Data.SqlDbType.UniqueIdentifier)
			{
				//GUID is a special case since we are making it a char(36)
				sb.AppendFormat("MaxLength=\"{0}\" ", "36");
			}
			if (column.DataType == System.Data.SqlDbType.Timestamp)
			{
				sb.Append("MaxLength=\"8\" ");
			}
			else if (!string.IsNullOrEmpty(column.EFGetDatabaseMaxLengthString()))
			{
				sb.AppendFormat("MaxLength=\"{0}\" ", column.EFGetDatabaseMaxLengthString());
			}

			//Append StoreGeneratedPattern
			if (!string.IsNullOrEmpty(column.ToEFStoreGeneratedPattern(SupportedDatabaseConstants.MySql)))
				sb.AppendFormat("StoreGeneratedPattern=\"{0}\" ", column.ToEFStoreGeneratedPattern(SupportedDatabaseConstants.MySql));

			sb.AppendLine("/>");
		}

		#endregion

	}
}
