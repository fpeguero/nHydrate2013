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

namespace Widgetsphere.Generator.EFCodeFirst.Generators.EFCSDL
{
	public class EntityGeneratedTemplate : EFCodeFirstBaseTemplate
	{
		private StringBuilder sb = new StringBuilder();
		private Table _currentTable;

		public EntityGeneratedTemplate(ModelRoot model, Table currentTable)
		{
			_model = model;
			_currentTable = currentTable;
		}

		#region BaseClassTemplate overrides
		public override string FileName
		{
			get { return string.Format("{0}.Generated.cs", _currentTable.PascalName); }
		}

		public string ParentItemName
		{
			get { return string.Format("{0}.cs", _currentTable.PascalName); }
		}

		public override string FileContent
		{
			get
			{
				try
				{
					sb = new StringBuilder();
					this.GenerateContent();
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
			try
			{
				Widgetsphere.Generator.GenerationHelper.AppendCopyrightInCode(sb, _model);
				this.AppendUsingStatements();
				sb.AppendLine("namespace " + this.GetLocalNamespace() + ".Entity");
				sb.AppendLine("{");
				this.AppendEntityClass();
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
			sb.AppendLine("using System.Runtime.Serialization;");
			sb.AppendLine("using System.Data.Objects.DataClasses;");
			sb.AppendLine("using System.Xml.Serialization;");
			sb.AppendLine("using System.ComponentModel;");
			sb.AppendLine("using System.Collections.Generic;");
			sb.AppendLine("using System.Data.Objects;");
			sb.AppendLine("using System.Text;");
			sb.AppendLine("using " + this.GetLocalNamespace() + ";");
			sb.AppendLine("using System.Text.RegularExpressions;");
			sb.AppendLine("using System.Linq.Expressions;");
			sb.AppendLine("using System.Data.Entity;");
			sb.AppendLine("using System.Data.Entity.ModelConfiguration;");
			sb.AppendLine();
		}

		private void AppendEntityClass()
		{
			sb.AppendLine("	/// <summary>");
			sb.AppendLine("	/// The collection to hold '" + _currentTable.PascalName + "' entities");
			if (!string.IsNullOrEmpty(_currentTable.Description))
				sb.AppendLine("	/// " + _currentTable.Description);
			sb.AppendLine("	/// </summary>");
			sb.AppendLine("	[DataContract]");
			sb.AppendLine("	[Serializable]");

			if (_currentTable.ParentTable == null)
				sb.AppendLine("	public partial class " + _currentTable.PascalName);
			else
				sb.AppendLine("	public partial class " + _currentTable.PascalName + " : " + this.GetLocalNamespace() + ".Entity." + _currentTable.ParentTable.PascalName);

			sb.AppendLine("	{");
			this.AppendConstructors();
			this.AppendProperties();
			this.AppendIsEquivalent();
			this.AppendNavigationProperties();
			sb.AppendLine("	}");
			sb.AppendLine();
		}

		private void AppendConstructors()
		{
			string scope = "public";
			if (_currentTable.Immutable)
				scope = "protected internal";

			sb.AppendLine("		#region Constructors");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Initializes a new instance of the " + this.GetLocalNamespace() + ".Entity." + _currentTable.PascalName + " class");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		" + scope + " " + _currentTable.PascalName + "()");
			sb.AppendLine("		{");
			if (_currentTable.PrimaryKeyColumns.Count == 1 && _currentTable.PrimaryKeyColumns[0].DataType == System.Data.SqlDbType.UniqueIdentifier)
				sb.AppendLine("			this." + _currentTable.PrimaryKeyColumns[0].PascalName + " = Guid.NewGuid();");
			sb.AppendLine("		}");
			sb.AppendLine();

			if (_currentTable.PrimaryKeyColumns.Count == _currentTable.PrimaryKeyColumns.Count(x => x.Identity == IdentityTypeConstants.None))
			{
				sb.AppendLine("		/// <summary>");
				sb.AppendLine("		/// Initializes a new instance of the " + this.GetLocalNamespace() + ".Entity." + _currentTable.PascalName + " class with a defined primary key");
				sb.AppendLine("		/// </summary>");
				sb.Append("		" + scope + " " + _currentTable.PascalName + "(");
				int index = 0;
				foreach (Column pkColumn in _currentTable.PrimaryKeyColumns.OrderBy(x => x.PascalName))
				{
					sb.Append(pkColumn.GetCodeType() + " " + pkColumn.CamelName);
					if (index < _currentTable.PrimaryKeyColumns.Count - 1)
						sb.Append(", ");
					index++;
				}
				sb.AppendLine(")");

				sb.AppendLine("			: this()");
				sb.AppendLine("		{");
				foreach (Column pkColumn in _currentTable.PrimaryKeyColumns.OrderBy(x => x.PascalName))
				{
					sb.AppendLine("			this." + pkColumn.PascalName + " = " + pkColumn.CamelName + ";");
				}
				sb.AppendLine("		}");
				sb.AppendLine();
			}

			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		private void AppendIsEquivalent()
		{
			sb.AppendLine("		#region IsEquivalent");
			sb.AppendLine();
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// Determines if all of the fields for the specified object exactly matches the current object.");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("		/// <param name=\"item\">The object to compare</param>");
			sb.AppendLine("		public virtual bool IsEquivalent(object item)");
			sb.AppendLine("		{");
			sb.AppendLine("			if (item == null) return false;");
			sb.AppendLine("			if (!(item is " + this.GetLocalNamespace() + ".Entity." + _currentTable.PascalName + ")) return false;");
			sb.AppendLine("			" + this.GetLocalNamespace() + ".Entity." + _currentTable.PascalName + " o = item as " + this.GetLocalNamespace() + ".Entity." + _currentTable.PascalName + ";");
			sb.AppendLine("			return (");

			IEnumerable<Column> allColumns = _currentTable.GetColumnsFullHierarchy(true).Where(x => x.Generated);
			int index = 0;
			foreach (Column column in allColumns)
			{
				Table typeTable = _currentTable.GetRelatedTypeTableByColumn(column, true);
				if (typeTable != null)
				{
					//TODO: NEXT VERSION: CODE FIRST CTP5 DOES NOT SUPPORT ENUMS SO ADD INTEGERS
					//sb.Append("				o." + typeTable.PascalName + " == this." + typeTable.PascalName);
					sb.Append("				o." + column.PascalName + " == this." + column.PascalName);
				}
				else
				{
					sb.Append("				o." + column.PascalName + " == this." + column.PascalName);
				}
				if (index < allColumns.Count() - 1) sb.Append(" &&");
				sb.AppendLine();
				index++;
			}

			sb.AppendLine("				);");
			sb.AppendLine("		}");
			sb.AppendLine();
			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		private void AppendProperties()
		{
			sb.AppendLine("		#region Properties");
			sb.AppendLine();

			foreach (Column column in _currentTable.GetColumns().Where(x => x.Generated).OrderBy(x => x.Name))
			{
				if (column.PrimaryKey && _currentTable.ParentTable != null)
				{
					//PK in descendant, do not process
				}
				else if (_currentTable.IsColumnRelatedToTypeTable(column))
				{
					Table typeTable = _currentTable.GetRelatedTypeTableByColumn(column);

					//If this column is a type table column then generate a special property
					sb.AppendLine("		/// <summary>");
					if (!string.IsNullOrEmpty(column.Description))
						sb.AppendLine("		/// " + column.Description + "");
					else
						sb.AppendLine("		/// The property that maps back to the database '" + (column.ParentTableRef.Object as Table).DatabaseName + "." + column.DatabaseName + "' field");
					sb.AppendLine("		/// </summary>");
					sb.AppendLine("		/// <remarks>" + column.GetIntellisenseRemarks() + "</remarks>");
					sb.AppendLine("		[DataMember]");

					//TODO: NEXT VERSION: CODE FIRST CTP5 DOES NOT SUPPORT ENUMS SO ADD INTEGERS
					//sb.AppendLine("		public virtual " + typeTable.PascalName + "Constants " + typeTable.PascalName + " { get; set; }");
					sb.AppendLine("		public virtual " + column.GetCodeType() + " " + column.PascalName + " { get; set; }");

					sb.AppendLine();
				}
				else
				{
					sb.AppendLine("		/// <summary>");
					if (!string.IsNullOrEmpty(column.Description))
						sb.AppendLine("		/// " + column.Description + "");
					else
						sb.AppendLine("		/// The property that maps back to the database '" + (column.ParentTableRef.Object as Table).DatabaseName + "." + column.DatabaseName + "' field");
					sb.AppendLine("		/// </summary>");
					sb.AppendLine("		/// <remarks>" + column.GetIntellisenseRemarks() + "</remarks>");
					sb.AppendLine("		[DataMember]");
					sb.AppendLine("		public virtual " + column.GetCodeType() + " " + column.PascalName + " { get; set; }");
					sb.AppendLine();
				}
			}

			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		private void AppendNavigationProperties()
		{
			sb.AppendLine("		#region Navigation Properties");
			sb.AppendLine();

			#region Parent Relations
			IEnumerable<Relation> relationList = _currentTable.GetRelations().AsEnumerable();
			foreach (Relation relation in relationList)
			{
				Table parentTable = (Table)relation.ParentTableRef.Object;
				Table childTable = (Table)relation.ChildTableRef.Object;

				//If not both generated then do not process this code block
				if (!parentTable.Generated || !childTable.Generated)
				{
					//Do Nothing
				}

				//inheritance relationship
				else if (parentTable == childTable.ParentTable && relation.IsOneToOne)
				{
					//Do Nothing
				}

				//Do not walk to type tables
				else if (parentTable.IsTypeTable || childTable.IsTypeTable)
				{
					//Do Nothing
				}

				//1-1 relations
				else if (relation.IsOneToOne)
				{
					sb.AppendLine("		/// <summary>");
					sb.AppendLine("		/// The navigation definition for walking " + _currentTable.PascalName + "->" + childTable.PascalName + (string.IsNullOrEmpty(relation.PascalRoleName) ? "" : " (role: '" + relation.PascalRoleName + "')"));
					sb.AppendLine("		/// </summary>");
					sb.AppendLine("		[DataMember]");
					sb.AppendLine("		public virtual " + childTable.PascalName + " " + relation.PascalRoleName + childTable.PascalName + " { get; set; }");
					sb.AppendLine();
				}

				//Process the associative tables
				else if (childTable.AssociativeTable)
				{
					IEnumerable<Relation> associativeRelations = childTable.GetRelationsWhereChild();
					Relation targetRelation = null;
					Relation otherRelation = null;
					Relation relation1 = associativeRelations.First();
					Relation relation2 = associativeRelations.Last();
					if (_currentTable == ((Table)relation1.ParentTableRef.Object)) targetRelation = relation2;
					else targetRelation = relation1;
					if (targetRelation == relation2) otherRelation = relation1;
					else otherRelation = relation2;
					Table targetTable = (Table)targetRelation.ParentTableRef.Object;

					if (targetTable.Generated && !targetTable.IsTypeTable)
					{
						sb.AppendLine("		/// <summary>");
						sb.AppendLine("		/// The navigation definition for walking " + _currentTable.PascalName + "->" + targetTable.PascalName + (string.IsNullOrEmpty(otherRelation.PascalRoleName) ? "" : " (role: '" + otherRelation.PascalRoleName + "')"));
						sb.AppendLine("		/// </summary>");
						sb.AppendLine("		[DataMember]");
						sb.AppendLine("		public virtual ICollection<" + this.GetLocalNamespace() + ".Entity." + targetTable.PascalName + "> " + targetTable.PascalName + "List { get; set; }");
						sb.AppendLine();
					}
				}

				//Process relations where Current Table is the parent
				else if (parentTable == _currentTable && parentTable.Generated && childTable.Generated && !childTable.IsTypeTable && !childTable.AssociativeTable)
				{
					sb.AppendLine("		/// <summary>");
					sb.AppendLine("		/// The navigation definition for walking " + parentTable.PascalName + "->" + childTable.PascalName + (string.IsNullOrEmpty(relation.PascalRoleName) ? "" : " (role: '" + relation.PascalRoleName + "')"));
					sb.AppendLine("		/// </summary>");
					sb.AppendLine("		[DataMember]");
					sb.AppendLine("		public virtual ICollection<" + this.GetLocalNamespace() + ".Entity." + childTable.PascalName + "> " + relation.PascalRoleName + childTable.PascalName + "List { get; set; }");
					sb.AppendLine();
				}

			}
			#endregion

			#region Child Relations
			relationList = _currentTable.GetRelationsWhereChild().AsEnumerable();
			foreach (Relation relation in relationList)
			{
				Table parentTable = (Table)relation.ParentTableRef.Object;
				Table childTable = (Table)relation.ChildTableRef.Object;

				//Do not walk to associative
				if (parentTable.IsTypeTable || childTable.IsTypeTable)
				{
					//Do Nothing
				}

				//inheritance relationship
				else if (parentTable == childTable.ParentTable && relation.IsOneToOne)
				{
					//Do Nothing
				}

				//Process relations where Current Table is the child
				else if (childTable == _currentTable && parentTable.Generated && childTable.Generated)
				{
					sb.AppendLine("		/// <summary>");
					sb.AppendLine("		/// The navigation definition for walking " + parentTable.PascalName + "->" + childTable.PascalName + (string.IsNullOrEmpty(relation.PascalRoleName) ? "" : " (role: '" + relation.PascalRoleName + "')"));
					sb.AppendLine("		/// </summary>");
					sb.AppendLine("		[DataMember]");
					sb.AppendLine("		public virtual " + parentTable.PascalName + " " + relation.PascalRoleName + parentTable.PascalName + " { get; set; }");
					sb.AppendLine();
				}
			}
			#endregion

			sb.AppendLine("		#endregion");
			sb.AppendLine();

		}

		#endregion

	}
}