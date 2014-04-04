#region Copyright (c) 2006-2010 Widgetsphere LLC, All Rights Reserved
//--------------------------------------------------------------------- *
//                          Widgetsphere  LLC                           *
//             Copyright (c) 2006-2010 All Rights reserved              *
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
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Widgetsphere.Generator.Models;
using Widgetsphere.Generator.Common.Util;
using System.Collections;
using System.Collections.ObjectModel;
using Widgetsphere.Generator.Common.GeneratorFramework;
using Widgetsphere.Generator.ProjectItemGenerators;

namespace Widgetsphere.Generator.EFDAL.Generators.QueryOptimizationObject
{
	class QueryOptimizationObjectGeneratedTemplate : EFDALBaseTemplate
	{
		private StringBuilder sb = new StringBuilder();
		
		public QueryOptimizationObjectGeneratedTemplate(ModelRoot model)
		{
			_model = model;			
		}

		#region BaseClassTemplate overrides
		public override string FileName
		{
			get { return "QueryOptimizer.Generated.cs"; }
		}

		public string ParentItemName
		{
			get { return "QueryOptimizer.cs"; }
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
				sb.AppendLine("namespace " + DefaultNamespace);
				sb.AppendLine("{");
				sb.AppendLine("	/// <summary>");
				sb.AppendLine("	/// This class can be used to optimize queries or report information about the operations");
				sb.AppendLine("	/// </summary>");
				sb.AppendLine("	public partial class QueryOptimizer");
				sb.AppendLine("	{");
				sb.AppendLine("		/// <summary>");
				sb.AppendLine("		/// Determines if the query use select locks");
				sb.AppendLine("		/// </summary>");
				sb.AppendLine("		public bool NoLocking { get; set; }");
				sb.AppendLine();
				sb.AppendLine("		/// <summary>");
				sb.AppendLine("		/// Determines the total time a query took to run");
				sb.AppendLine("		/// </summary>");
				sb.AppendLine("		public long TotalMilliseconds { get; internal set; }");
				sb.AppendLine();
				sb.AppendLine("		/// <summary>");
				sb.AppendLine("		/// Default constructor");
				sb.AppendLine("		/// </summary>");
				sb.AppendLine("		public QueryOptimizer()");
				sb.AppendLine("		{");
				sb.AppendLine("			this.NoLocking = false;");
				sb.AppendLine("		}");
				sb.AppendLine();
				sb.AppendLine("		/// <summary>");
				sb.AppendLine("		/// Initializes a new instance of this object using the specified NoLocking property");
				sb.AppendLine("		/// </summary>");
				sb.AppendLine("		/// <param name=\"noLocking\">Determines if the query use select locks</param>");
				sb.AppendLine("		public QueryOptimizer(bool noLocking)");
				sb.AppendLine("			: this()");
				sb.AppendLine("		{");
				sb.AppendLine("			this.NoLocking = noLocking;");
				sb.AppendLine("		}");
				sb.AppendLine();
				sb.AppendLine("	}");
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
			sb.AppendLine();
		}

		#endregion

	}
}