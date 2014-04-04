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
using System.Collections.Generic;
using System.Text;
using Widgetsphere.Generator.Models;
using Widgetsphere.Generator.Common.Util;
using System.Collections;
using System.Collections.ObjectModel;
using Widgetsphere.Generator.ProjectItemGenerators;

namespace Widgetsphere.Generator.EFCodeFirst.Generators.IncludeTreeLINQ
{
	class IncludeTreeLINQGeneratedTemplate : EFCodeFirstBaseTemplate
	{
		private StringBuilder sb = new StringBuilder();
		private Table _currentTable;

		public IncludeTreeLINQGeneratedTemplate(ModelRoot model, Table currentTable)
		{
			_model = model;
			_currentTable = currentTable;
		}

		#region BaseClassTemplate overrides
		public override string FileName
		{
			get { return string.Format("{0}Include.Generated.cs", _currentTable.PascalName); }
		}

		public string ParentItemName
		{
			get { return string.Format("{0}Include.cs", _currentTable.PascalName); }
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
				ValidationHelper.AppendCopyrightInCode(sb, _model);
				this.AppendUsingStatements();
				sb.AppendLine("namespace " + this.GetLocalNamespace() + ".ContextIncludeTree");
				sb.AppendLine("{");
				this.AppendClass();
				sb.AppendLine("}");
			}
			catch (Exception ex)
			{
				throw;
			}

		}

		#endregion

		#region namespace / objects

		public void AppendUsingStatements()
		{
			sb.AppendLine("using System;");
			sb.AppendLine("using System.Data;");
			sb.AppendLine("using System.Linq;");
			sb.AppendLine("using System.Data.Linq;");
			sb.AppendLine("using System.Linq.Expressions;");
			sb.AppendLine("using System.Data.Linq.Mapping;");
			sb.AppendLine("using System.Collections;");
			sb.AppendLine("using System.Collections.Generic;");
			sb.AppendLine("using " + this.GetLocalNamespace() + ";");
			sb.AppendLine("using Widgetsphere.EFCore.DataAccess;");
			sb.AppendLine();
		}

		private void AppendClass()
		{
			try
			{
				IEnumerable<Table> allTables = _currentTable.GetTableHierarchy();

				sb.AppendLine("	/// <summary>");
				sb.AppendLine("	/// This is a helper object for creating LINQ definitions for context includes on the " + _currentTable.PascalName + " collection.");
				sb.AppendLine("	/// </summary>");
				sb.AppendLine("	[Serializable()]");
				sb.AppendLine("	[Table(Name = \"" + _currentTable.DatabaseName + "\")]");
				sb.AppendLine("	public partial class " + _currentTable.PascalName + "Include : Widgetsphere.EFCore.DataAccess.IContextInclude");
				sb.AppendLine("	{");

				//Add child relationships
				foreach (Relation relation in _model.Database.Relations.FindByParentTable(_currentTable, true).Where(x => x.IsGenerated))
				{
					Table parentTable = (Table)relation.ParentTableRef.Object;
					Table childTable = (Table)relation.ChildTableRef.Object;
					if (childTable.AssociativeTable)
					{
						Table middleTable = childTable;
						var relationlist = middleTable.GetRelationsWhereChild();
						if (relationlist.First() == relation)
							childTable = (Table)relationlist.Last().ParentTableRef.Object;
						else
							childTable = (Table)relationlist.First().ParentTableRef.Object;

						if (childTable.Generated &&
							parentTable.Generated &&
							!childTable.IsInheritedFrom(parentTable) &&
							(!allTables.Contains(childTable)))
						{
							sb.AppendLine("		/// <summary>");
							sb.AppendLine("		/// This is a mapping of the relationship with the " + childTable.PascalName + " entity. This is a N:M relation with two relationships though an intermediary table. (" + parentTable.PascalName + " -> " + middleTable.PascalName + " -> " + childTable.PascalName + ")");
							sb.AppendLine("		/// </summary>");
							//sb.AppendLine("		[Association(ThisKey = \"" + thisKey + "\", OtherKey = \"" + otherKey + "\")]");
							if (relation.IsOneToOne)
								sb.AppendLine("		public " + this.GetLocalNamespace() + ".ContextIncludeTree." + childTable.PascalName + "Include " + relation.PascalRoleName + childTable.PascalName + " { get; private set; }");
							else
								sb.AppendLine("		public " + this.GetLocalNamespace() + ".ContextIncludeTree." + childTable.PascalName + "Include " + relation.PascalRoleName + childTable.PascalName + "List { get; private set; }");
						}
					}
					else
					{
						string thisKey = "";
						string otherKey = "";
						foreach (ColumnRelationship columnRelationship in relation.ColumnRelationships)
						{
							thisKey += ((Column)columnRelationship.ParentColumnRef.Object).PascalName + ",";
							otherKey += ((Column)columnRelationship.ChildColumnRef.Object).PascalName + ",";
						}
						if (!string.IsNullOrEmpty(thisKey)) thisKey = thisKey.Substring(0, thisKey.Length - 1);
						if (!string.IsNullOrEmpty(otherKey)) otherKey = otherKey.Substring(0, otherKey.Length - 1);

						if (childTable.Generated &&
							parentTable.Generated &&
							!childTable.IsInheritedFrom(parentTable) &&
							(!allTables.Contains(childTable)))
						{
							sb.AppendLine("		/// <summary>");
							sb.AppendLine("		/// This is a mapping of the relationship with the " + childTable.PascalName + " entity." + (relation.PascalRoleName == "" ? "" : " (Role: '" + relation.RoleName + "')"));
							sb.AppendLine("		/// </summary>");
							sb.AppendLine("		[Association(ThisKey = \"" + thisKey + "\", OtherKey = \"" + otherKey + "\")]");
							if (relation.IsOneToOne)
								sb.AppendLine("		public " + this.GetLocalNamespace() + ".ContextIncludeTree." + childTable.PascalName + "Include " + relation.PascalRoleName + childTable.PascalName + " { get; private set; }");
							else
								sb.AppendLine("		public " + this.GetLocalNamespace() + ".ContextIncludeTree." + childTable.PascalName + "Include " + relation.PascalRoleName + childTable.PascalName + "List { get; private set; }");
						}
					}

				}

				//Add parent relationships
				foreach (Relation relation in _model.Database.Relations.FindByChildTable(_currentTable, true).Where(x => x.IsGenerated))
				{
					Table parentTable = (Table)relation.ParentTableRef.Object;
					Table childTable = (Table)relation.ChildTableRef.Object;

					//Do not process self-referencing relationships
					if (parentTable != _currentTable)
					{
						string thisKey = "";
						string otherKey = "";
						foreach (ColumnRelationship columnRelationship in relation.ColumnRelationships)
						{
							thisKey += ((Column)columnRelationship.ChildColumnRef.Object).PascalName + ",";
							otherKey += ((Column)columnRelationship.ParentColumnRef.Object).PascalName + ",";
						}
						if (!string.IsNullOrEmpty(thisKey)) thisKey = thisKey.Substring(0, thisKey.Length - 1);
						if (!string.IsNullOrEmpty(otherKey)) otherKey = otherKey.Substring(0, otherKey.Length - 1);

						if ((parentTable.Generated) && (!allTables.Contains(parentTable)))
						{
							sb.AppendLine("		/// <summary>");
							sb.AppendLine("		/// This is a mapping of the relationship with the " + parentTable.PascalName + " entity." + (relation.PascalRoleName == "" ? "" : " (Role: '" + relation.RoleName + "')"));
							sb.AppendLine("		/// </summary>");
							sb.AppendLine("		[Association(ThisKey = \"" + thisKey + "\", OtherKey = \"" + otherKey + "\")]");
							sb.AppendLine("		public " + this.GetLocalNamespace() + ".ContextIncludeTree." + parentTable.PascalName + "Include " + relation.PascalRoleName + parentTable.PascalName + " { get; private set; }");
						}

					}
				}

				sb.AppendLine();
				sb.AppendLine("	}");
				sb.AppendLine();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		#endregion

	}
}