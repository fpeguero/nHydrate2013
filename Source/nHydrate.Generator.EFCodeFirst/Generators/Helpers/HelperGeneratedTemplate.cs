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

namespace Widgetsphere.Generator.EFCodeFirst.Generators.Helpers
{
	public class HelperGeneratedTemplate : EFCodeFirstBaseTemplate
	{
		private StringBuilder sb = new StringBuilder();

		public HelperGeneratedTemplate(ModelRoot model)
		{
			_model = model;
		}

		#region BaseClassTemplate overrides
		public override string FileName
		{
			get { return "Globals.Generated.cs"; }
		}

		public string ParentItemName
		{
			get { return "Globals.cs"; }
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

		public void GenerateContent()
		{
			try
			{
				ValidationHelper.AppendCopyrightInCode(sb, _model);

				sb.AppendLine("using System;");
				sb.AppendLine("using System.Data.Objects.DataClasses;");
				sb.AppendLine("using System.Collections.Generic;");
				sb.AppendLine("using System.Data;");
				sb.AppendLine("using System.Data.SqlClient;");
				sb.AppendLine();

				sb.AppendLine("namespace " + this.GetLocalNamespace());
				sb.AppendLine("{");

				#region DBHelper

				sb.AppendLine("	internal class DBHelper");
				sb.AppendLine("	{");
				sb.AppendLine("		internal static IDbConnection GetConnection()");
				sb.AppendLine("		{");
				sb.AppendLine("			return new SqlConnection(" + _model.ProjectName + "Entities.GetConnectionString());");
				sb.AppendLine("		}");
				sb.AppendLine();

				sb.AppendLine("		internal static IDbCommand GetCommand(string commandText, CommandType commandType, IDbConnection connection)");
				sb.AppendLine("		{");
				sb.AppendLine("			SqlCommand cmd = new SqlCommand(commandText);");
				sb.AppendLine("			cmd.CommandType = commandType;");
				sb.AppendLine("			cmd.Connection = (SqlConnection)connection;");
				sb.AppendLine("			return cmd;");
				sb.AppendLine("		}");
				sb.AppendLine();

				sb.AppendLine("		internal static void AddParameter(IDbCommand cmd, string parameterName, object value)");
				sb.AppendLine("		{");
				sb.AppendLine("			SqlParameter sqlParam = new SqlParameter(parameterName, value);");
				sb.AppendLine("			cmd.Parameters.Add(sqlParam);");
				sb.AppendLine("		}");
				sb.AppendLine();

				sb.AppendLine("		internal static void AddReturnParameter(IDbCommand cmd)");
				sb.AppendLine("		{");
				sb.AppendLine("			SqlParameter sqlParam = new SqlParameter();");
				sb.AppendLine("			sqlParam.ParameterName = \"@RETURN_VALUE\";");
				sb.AppendLine("			sqlParam.Direction = ParameterDirection.ReturnValue;");
				sb.AppendLine("			cmd.Parameters.Add(sqlParam);");
				sb.AppendLine("		}");
				sb.AppendLine();

				sb.AppendLine("	}");
				sb.AppendLine();

				#endregion

				sb.AppendLine("}");
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