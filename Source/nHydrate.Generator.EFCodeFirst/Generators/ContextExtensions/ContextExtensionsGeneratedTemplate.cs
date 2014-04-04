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

namespace Widgetsphere.Generator.EFCodeFirst.Generators.ContextExtensions
{
	public class ContextExtensionsGeneratedTemplate : EFCodeFirstBaseTemplate
	{
		private StringBuilder sb = new StringBuilder();

		public ContextExtensionsGeneratedTemplate(ModelRoot model)
		{
			_model = model;
		}

		#region BaseClassTemplate overrides
		public override string FileName
		{
			get { return _model.ProjectName + "EntitiesExtensions.Generated.cs"; }
		}

		public string ParentItemName
		{
			get { return _model.ProjectName + "EntitiesExtensions.cs"; }
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
				sb.AppendLine("namespace " + this.GetLocalNamespace());
				sb.AppendLine("{");
				this.AppendExtensions();
				sb.AppendLine("}");
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
			sb.AppendLine("using " + this.GetLocalNamespace() + ".Entity;");
			sb.AppendLine("using System.Linq.Expressions;");
			sb.AppendLine("using Widgetsphere.EFCore.DataAccess;");
			sb.AppendLine();
		}

		private void AppendExtensions()
		{
			sb.AppendLine("	#region " + _model.ProjectName + "EntitiesExtensions");
			sb.AppendLine();
			sb.AppendLine("	/// <summary>");
			sb.AppendLine("	/// Extension methods for this library");
			sb.AppendLine("	/// </summary>");
			sb.AppendLine("	public static partial class " + _model.ProjectName + "EntitiesExtensions");
			sb.AppendLine("	{");

			//Add an strongly-typed extension for "Include" method
			sb.AppendLine("		#region Include Extension Methods");
			sb.AppendLine();
			foreach (Table table in _model.Database.Tables.Where(x => x.Generated && !x.AssociativeTable && !x.IsTypeTable).OrderBy(x => x.PascalName))
			{
				//Build relation list
				IEnumerable<Relation> relationList1 = table.GetRelationsFullHierarchy().Where(x =>
					x.ParentTableRef.Object == table &&
					!(x.ChildTableRef.Object as Table).IsInheritedFrom(x.ParentTableRef.Object as Table)
					);

				IEnumerable<Relation> relationList2 = table.GetRelationsWhereChild().Where(x =>
					x.ChildTableRef.Object == table &&
					!(x.ChildTableRef.Object as Table).IsInheritedFrom(x.ParentTableRef.Object as Table)
					);

				List<Relation> relationList = new List<Relation>();
				relationList.AddRange(relationList1);
				relationList.AddRange(relationList2);

				//Generate an extension if there are relations for this table
				if (relationList.Count() != 0)
				{
					sb.AppendLine("		/// <summary>");
					sb.AppendLine("		/// Specifies the related objects to include in the query results.");
					sb.AppendLine("		/// </summary>");
					sb.AppendLine("		/// <param name=\"item\"></param>");
					sb.AppendLine("		/// <param name=\"query\">The LINQ expresssion that maps an include path</param>");
					sb.AppendLine("		public static ObjectQuery<" + this.GetLocalNamespace() + ".Entity." + table.PascalName + "> Include(this ObjectQuery<" + this.GetLocalNamespace() + ".Entity." + table.PascalName + "> item, Expression<Func<" + this.GetLocalNamespace() + ".ContextIncludeTree." + table.PascalName + "Include, IContextInclude>> query)");
					sb.AppendLine("		{");
					sb.AppendLine("			List<string> strings = new List<string>(query.Body.ToString().Split('.'));");
					sb.AppendLine("			strings.RemoveAt(0);");
					sb.AppendLine("			string compoundString = string.Empty;");
					sb.AppendLine("			foreach (string s in strings)");
					sb.AppendLine("			{");
					sb.AppendLine("				if (!string.IsNullOrEmpty(compoundString)) compoundString += \".\";");
					sb.AppendLine("				compoundString += s;");
					sb.AppendLine("				item = item.Include(compoundString);");
					sb.AppendLine("			}");
					sb.AppendLine("			return item;");
					sb.AppendLine("		}");
					sb.AppendLine();
				}
			}
			sb.AppendLine("		#endregion");
			sb.AppendLine();

			sb.AppendLine("	}");
			sb.AppendLine();
			sb.AppendLine("	#endregion");
			sb.AppendLine();
		}

		#endregion

	}
}