#region Copyright (c) 2006-2011 Widgetsphere LLC, All Rights Reserved
//--------------------------------------------------------------------- *
//                          Widgetsphere  LLC                           *
//             Copyright (c) 2006-2011 All Rights reserved              *
//                                                                      *
//                                                                      *
//This file and its contents are protected by United States and         *
//International copyright laws.  Unauthorized reproduction and/or       *
//distribution of all or any portion of the code contained herein       *
//is strictly prohibited and will result in severe civil and criminal   *
//penalties.  Any violations of this copyright will be prosecuted       *
//to the fullest extent possible under law.                             *
//                                                                      *
//THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
//TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
//TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
//CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
//THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF WIDGETSPHERE LLC   *
//                                                                      *
//UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
//PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
//SUBSTANTIALLY THE SAME, FUNCTIONALITY AS ANY WIDGETSPHERE PRODUCT.    *
//                                                                      *
//THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
//CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF WIDGETSPHERE,      *
//INC.  THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO       *
//INSURE ITS CONFIDENTIALITY.                                           *
//                                                                      *
//THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
//PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
//EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
//THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
//SOURCE CODE CONTAINED HEREIN.                                         *
//                                                                      *
//THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
//--------------------------------------------------------------------- *
#endregion
using System;
using System.Linq;
using Widgetsphere.Generator.Common.GeneratorFramework;
using Widgetsphere.Generator.Models;
using System.Text;
using Widgetsphere.Generator.Common.Util;
using System.Collections.Generic;
using Widgetsphere.Generator.Common;

namespace Widgetsphere.Generator.EFCodeFirst.Generators.Contexts
{
	public class ContextGeneratedTemplate : EFCodeFirstBaseTemplate
	{
		private StringBuilder sb = new StringBuilder();

		public ContextGeneratedTemplate(ModelRoot model)
		{
			_model = model;
		}

		#region BaseClassTemplate overrides
		public override string FileName
		{
			get { return _model.ProjectName + "Entities.Generated.cs"; }
		}

		public string ParentItemName
		{
			get { return _model.ProjectName + "Entities.cs"; }
		}

		public override string FileContent
		{
			get
			{
				GenerateContent();
				return sb.ToString();
			}
		}
		#endregion

		#region GenerateContent

		private void GenerateContent()
		{
			try
			{
				Widgetsphere.Generator.GenerationHelper.AppendCopyrightInCode(sb, _model);
				this.AppendUsingStatements();
				sb.AppendLine("namespace " + this.GetLocalNamespace());
				sb.AppendLine("{");
				this.AppendTypeTableEnums();
				this.AppendClass();
				sb.AppendLine("}");
				sb.AppendLine();

				sb.AppendLine("namespace " + this.GetLocalNamespace() + ".Entity");
				sb.AppendLine("{");
				sb.AppendLine("}");
				sb.AppendLine();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		private void AppendUsingStatements()
		{
			sb.AppendLine("using System;");
			sb.AppendLine("using System.Linq;");
			sb.AppendLine("using System.Data.Objects;");
			sb.AppendLine("using System.Data.Objects.DataClasses;");
			sb.AppendLine("using System.ComponentModel;");
			sb.AppendLine("using System.Runtime.Serialization;");
			sb.AppendLine("using System.Collections.Generic;");
			sb.AppendLine("using System.Data.Entity;");
			sb.AppendLine("using System.Data.Entity.ModelConfiguration;");
			sb.AppendLine("using " + this.GetLocalNamespace() + ".Entity;");
			sb.AppendLine();
		}

		private void AppendClass()
		{
			sb.AppendLine("	#region Entity Context");
			sb.AppendLine();
			sb.AppendLine("	/// <summary>");
			sb.AppendLine("	/// The object context for the schema tied to this generated model.");
			sb.AppendLine("	/// </summary>");
			sb.AppendLine("	[DataContract]");
			sb.AppendLine("	[Serializable]");
			sb.AppendLine("	public partial class " + _model.ProjectName + "Entities : System.Data.Entity.DbContext");
			sb.AppendLine("	{");

			//Create the modifier property
			//sb.AppendLine("		/// <summary>");
			//sb.AppendLine("		/// The audit modifier used to mark database edits");
			//sb.AppendLine("		/// </summary>");
			//sb.AppendLine("		protected ContextStartup _contextStartup = new ContextStartup(null);");
			//sb.AppendLine();

			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Initializes a new " + _model.ProjectName + "Entities object using the connection string found in the '" + _model.ProjectName + "Entities' section of the application configuration file.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public " + _model.ProjectName + "Entities() :");
			sb.AppendLine("			base()");
			sb.AppendLine("		{");
			sb.AppendLine("			this.OnContextCreated();");
			sb.AppendLine("		}");
			sb.AppendLine();

			//sb.AppendLine("		/// <summary>");
			//sb.AppendLine("		/// Initialize a new " + _model.ProjectName + "Entities object with an audit modifier.");
			//sb.AppendLine("		/// </summary>");
			//sb.AppendLine("		public " + _model.ProjectName + "Entities(ContextStartup contextStartup) :");
			//sb.AppendLine("			this()");
			//sb.AppendLine("		{");
			//sb.AppendLine("			_contextStartup = contextStartup;");
			//sb.AppendLine("		}");
			//sb.AppendLine();

			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Initializes a new " + _model.ProjectName + "Entities object using the connection string specified.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public " + _model.ProjectName + "Entities(string connectionString) :");
			sb.AppendLine("			base(connectionString)");
			sb.AppendLine("		{");
			sb.AppendLine("			this.OnContextCreated();");
			sb.AppendLine("		}");
			sb.AppendLine();

			sb.AppendLine("		partial void OnContextCreated();");
			sb.AppendLine();

			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Model creation event");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		protected override void OnModelCreating(ModelBuilder modelBuilder)");
			sb.AppendLine("		{");
			sb.AppendLine("			base.OnModelCreating(modelBuilder);");
			sb.AppendLine();

			sb.AppendLine("			#region Rename Tables");
			sb.AppendLine();
			foreach (Table table in _model.Database.Tables.Where(x => x.Generated && !x.AssociativeTable && !x.IsTypeTable).OrderBy(x => x.Name))
			{
				if (table.DatabaseName != table.PascalName)
					sb.AppendLine("			modelBuilder.Entity<" + this.GetLocalNamespace() + ".Entity." + table.PascalName + ">().ToTable(\"" + table.DatabaseName + "\");");
			}
			sb.AppendLine("			#endregion");
			sb.AppendLine();

			//Create annotations for properties
			sb.AppendLine("			#region Setup Fields");
			sb.AppendLine();
			foreach (Table table in _model.Database.Tables.Where(x => x.Generated && !x.AssociativeTable && !x.IsTypeTable).OrderBy(x => x.Name))
			{
				sb.AppendLine("			//Field setup for " + table.PascalName + " entity");
				foreach (var column in table.GeneratedColumns)
				{
					//If this is a base table OR the column is not a PK then process it
					//Primary key code should be emited ONLY for base tables
					if (table.ParentTable == null || !column.PrimaryKey)
					{
						sb.Append("			modelBuilder.Entity<" + this.GetLocalNamespace() + ".Entity." + table.PascalName + ">()");
						sb.Append(".Property(d => d." + column.PascalName + ")");
						if (!column.AllowNull) sb.Append(".IsRequired()");
						if (column.IsTextType) sb.Append(".HasMaxLength(" + column.GetAnnotationStringLength() + ")");
						if (column.DatabaseName != column.PascalName) sb.Append(".HasColumnName(\"" + column.DatabaseName + "\")");
						sb.AppendLine(";");
					}
				}
				sb.AppendLine();
			}
			sb.AppendLine("			#endregion");
			sb.AppendLine();

			//Create annotations for relationships
			sb.AppendLine("			#region Relations");
			sb.AppendLine();
			foreach (Table table in _model.Database.Tables.Where(x => x.Generated && !x.AssociativeTable && !x.IsTypeTable).OrderBy(x => x.Name))
			{
				foreach (Relation relation in table.GetRelations())
				{
					Table childTable = relation.ChildTableRef.Object as Table;
					if (childTable.Generated && !childTable.IsInheritedFrom(table) && !childTable.AssociativeTable)
					{
						sb.AppendLine("			//Relation " + table.PascalName + " -> " + childTable.PascalName);
						sb.AppendLine("			modelBuilder.Entity<" + this.GetLocalNamespace() + ".Entity." + childTable.PascalName + ">()");

						if (relation.IsRequired)
							sb.AppendLine("							 .HasRequired(a => a." + relation.PascalRoleName + table.PascalName + ")");
						else
							sb.AppendLine("							 .HasOptional(a => a." + relation.PascalRoleName + table.PascalName + ")");

						if (relation.IsOneToOne)
							sb.AppendLine("							 .WithMany()");
						else
							sb.AppendLine("							 .WithMany(b => b." + relation.PascalRoleName + childTable.PascalName + "List)");

						sb.Append("							 .HasForeignKey(u => new { ");

						int index = 0;
						foreach (ColumnRelationship columnRelationship in relation.ColumnRelationships)
						{
							Column childColumn = columnRelationship.ChildColumnRef.Object as Column;
							sb.Append("u." + childColumn.PascalName);
							if (index < relation.ColumnRelationships.Count - 1)
								sb.Append(", ");
							index++;
						}

						sb.AppendLine(" })");
						sb.AppendLine("							 .WillCascadeOnDelete(false);");
						sb.AppendLine();
					}
				}
			}
			
			foreach (Table table in _model.Database.Tables.Where(x => x.Generated && x.AssociativeTable && !x.IsTypeTable).OrderBy(x => x.Name))
			{
				IEnumerable<Relation> associativeRelations = table.GetChildRoleRelationsFullHierarchy();
				Relation relation1 = associativeRelations.FirstOrDefault();
				Relation relation2 = associativeRelations.LastOrDefault();
				Table table1 = (Table)relation1.ParentTableRef.Object;
				Table table2 = (Table)relation2.ParentTableRef.Object;
				if (!table1.IsTypeTable &&
					!table2.IsTypeTable &&
					table1.Generated &&
					table2.Generated)
				{
					sb.AppendLine("			//Relation " + table2.PascalName + " -> " + table1.PascalName);
					sb.AppendLine("			modelBuilder.Entity<" + this.GetLocalNamespace() + ".Entity." + table2.PascalName + ">()");
					sb.AppendLine("						.HasMany(p => p." + table1.PascalName + "List)");
					sb.AppendLine("						.WithMany(s => s." + table2.PascalName + "List)");
					sb.AppendLine("						.Map(mc =>");
					sb.AppendLine("						{");
					sb.AppendLine("							mc.ToTable(\"" + table.DatabaseName + "\");");

					foreach (var c in table2.GetColumns().Where(x => x.PrimaryKey).OrderBy(x => x.Name))
						sb.AppendLine("							mc.MapLeftKey(p => p." + c.PascalName + ", \"" + c.DatabaseName + "\");");

					foreach (var c in table1.GetColumns().Where(x => x.PrimaryKey).OrderBy(x => x.Name))
						sb.AppendLine("							mc.MapRightKey(p => p." + c.PascalName + ", \"" + c.DatabaseName + "\");");

					sb.AppendLine("						});");
					sb.AppendLine();
				}
			}

			sb.AppendLine("			#endregion");
			sb.AppendLine();

			//Primary Keys
			sb.AppendLine("			#region Primary Keys");
			sb.AppendLine();
			foreach (Table table in _model.Database.Tables.Where(x => x.Generated && !x.AssociativeTable && !x.IsTypeTable).OrderBy(x => x.Name))
			{
				sb.Append("			modelBuilder.Entity<" + this.GetLocalNamespace() + ".Entity." + table.PascalName + ">().HasKey(x => new { ");
				var columnList = table.GetColumns().Where(x => x.PrimaryKey).OrderBy(x => x.Name).ToList();
				foreach (var c in columnList)
				{
					sb.Append("x." + c.PascalName);
					if (columnList.IndexOf(c) < columnList.Count - 1)
						sb.Append(", ");
				}
				sb.AppendLine(" });");
			}
			sb.AppendLine("			#endregion");
			sb.AppendLine();

			sb.AppendLine("		}");
			sb.AppendLine();

			sb.AppendLine("		#region Entity Sets");
			sb.AppendLine();
			foreach (Table table in _model.Database.Tables.Where(x => x.Generated && !x.AssociativeTable && !x.IsTypeTable).OrderBy(x => x.Name))
			{
				sb.AppendLine("		/// <summary>");
				sb.AppendLine("		/// Entity set for " + table.PascalName);
				sb.AppendLine("		/// </summary>");
				sb.AppendLine("		public DbSet<" + this.GetLocalNamespace() + ".Entity." + table.PascalName + "> " + table.PascalName + " { get; set; }");
				sb.AppendLine();
			}
			sb.AppendLine("		#endregion");
			sb.AppendLine();
			
			//sb.AppendLine("		/// <summary>");
			//sb.AppendLine("		/// The global settings of this context");
			//sb.AppendLine("		/// </summary>");
			//sb.AppendLine("		public ContextStartup ContextStartup");
			//sb.AppendLine("		{");
			//sb.AppendLine("			get { return _contextStartup; }");
			//sb.AppendLine("		}");
			//sb.AppendLine();

			#region Configuration API/Database verification
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Determines the version of the model that created this library.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public virtual string Version");
			sb.AppendLine("		{");

			var cacheFile = new Widgetsphere.Generator.Common.ModelCacheFile(_model.GeneratorProject);
			var genVersion = cacheFile.GeneratedVersion;
			sb.AppendLine("			get { return \"" + _model.Version + "." + genVersion + "\"; }");

			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Determines the key of the model that created this library.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		public virtual string ModelKey");
			sb.AppendLine("		{");
			sb.AppendLine("			get { return \"" + _model.Key + "\"; }");
			sb.AppendLine("		}");
			sb.AppendLine();
			#endregion

			sb.AppendLine("	}");
			sb.AppendLine();

			sb.AppendLine("	#endregion");
			sb.AppendLine();

		}

		private void AppendTypeTableEnums()
		{
			try
			{
				foreach (Table table in _model.Database.Tables.Where(x => x.IsTypeTable).OrderBy(x => x.Name))
				{
					if (table.IsTypeTable && table.PrimaryKeyColumns.Count == 1)
					{
						sb.AppendLine("	#region StaticDataConstants Enumeration for '" + table.PascalName + "' entity");
						sb.AppendLine("	/// <summary>");
						sb.AppendLine("	/// Enumeration to define static data items and their ids '" + table.PascalName + "' table.");
						sb.AppendLine("	/// </summary>");
						sb.AppendLine("	public enum " + table.PascalName + "Constants");
						sb.AppendLine("	{");
						foreach (RowEntry rowEntry in table.StaticData)
						{
							string idValue = rowEntry.GetCodeIdValue(table);
							string identifier = rowEntry.GetCodeIdentifier(table);
							string description = rowEntry.GetCodeDescription(table);
							if (!string.IsNullOrEmpty(description))
							{
								sb.AppendLine("		/// <summary>");
								sb.AppendLine("		/// " + description);
								sb.AppendLine("		/// </summary>");
								sb.AppendLine("		[Description(\"" + description + "\")]");
							}
							else
							{
								sb.AppendLine("		/// <summary>");
								sb.AppendLine("		/// Enumeration for the '" + identifier + "' item");
								sb.AppendLine("		/// </summary>");
								sb.AppendLine("		[Description(\"" + description + "\")]");
							}

							string key = ValidationHelper.MakeDatabaseIdentifier(identifier.Replace(" ", ""));
							if ((key.Length > 0) && ("0123456789".Contains(key[0])))
								key = "_" + key;

							sb.AppendLine("		" + key + " = " + idValue + ",");
						}
						sb.AppendLine("	}");
						sb.AppendLine("	#endregion");
						sb.AppendLine();
					}
				}
			}
			catch (Exception ex)
			{
				throw;
			}

		}

		#endregion

	}
}