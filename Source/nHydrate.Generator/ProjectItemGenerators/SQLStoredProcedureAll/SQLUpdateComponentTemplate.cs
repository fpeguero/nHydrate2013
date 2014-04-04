#region Copyright (c) 2006-2009 Widgetsphere LLC, All Rights Reserved
//--------------------------------------------------------------------- *
//                          Widgetsphere  LLC                           *
//             Copyright (c) 2006-2009 All Rights reserved              *
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Widgetsphere.Generator.Common.Util;
using Widgetsphere.Generator.Models;

namespace Widgetsphere.Generator.ProjectItemGenerators.SQLStoredProcedureAll
{
	internal class SQLUpdateComponentTemplate : ISQLGenerate
	{
		private ModelRoot _model;
		private TableComponent _currentComponent;

		#region Constructors
		public SQLUpdateComponentTemplate(ModelRoot model, TableComponent currentComponent)
		{
			_model = model;
			_currentComponent = currentComponent;
		}
		#endregion

		#region GenerateContent

		public void GenerateContent(StringBuilder sb)
		{
			if (_model.Database.AllowZeroTouch) return;
			if (_currentComponent.Parent.IsTypeTable) return;
			if (_currentComponent.Parent.Immutable) return;			
			try
			{
				sb.AppendLine("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[" + StoredProcedureName + "]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
				sb.AppendLine("	drop procedure [dbo].[" + StoredProcedureName + "]");
				sb.AppendLine("GO");
				sb.AppendLine();

				sb.AppendLine();
				sb.AppendLine("SET QUOTED_IDENTIFIER ON ");
				sb.AppendLine("GO");
				sb.AppendLine("SET ANSI_NULLS ON ");
				sb.AppendLine("GO");
				sb.AppendLine();
				sb.AppendLine("CREATE PROCEDURE [dbo].[" + StoredProcedureName + "]");
				sb.AppendLine("(");
				sb.AppendLine(this.BuildParameterList());
				sb.AppendLine(")");
				sb.AppendLine("AS");
				sb.AppendLine();

				if (_currentComponent.Parent.AllowModifiedAudit)
				{
					sb.AppendLine("IF (@" + _model.Database.ModifiedDateColumnName + " IS NULL)");
					sb.AppendLine("SET @" + _model.Database.ModifiedDateColumnName + " = GetDate();");
					sb.AppendLine();
				}

				sb.AppendLine("SET NOCOUNT OFF;");

				List<Table> tableList = new List<Table>();
				foreach (Reference reference in _currentComponent.Columns)
				{
					Column column = (Column)reference.Object;
					Table table = (Table)column.ParentTableRef.Object;
					if (!tableList.Contains(table)) tableList.Add(table);
				}
				
				foreach (Table table in tableList)
				{
					sb.AppendLine("UPDATE ");
					sb.AppendLine("[" + table.DatabaseName + "] ");
					sb.AppendLine("SET");
					sb.AppendLine(BuildSetStatement(table));
					sb.AppendLine("WHERE");
					sb.AppendLine("\t" + BuildUpdateWhereStatement(table));
					sb.AppendLine();
				}

				sb.AppendLine("SELECT");
				sb.Append(Globals.BuildSelectList(_currentComponent, _model));
				sb.AppendLine("FROM ");
				sb.AppendLine(_currentComponent.Parent.GetFullHierarchyTableJoin());
				sb.AppendLine("WHERE");
				sb.AppendLine("\t" + BuildSelectWhereStatement());
				sb.AppendLine("GO");
				sb.AppendLine("SET QUOTED_IDENTIFIER OFF");
				sb.AppendLine("GO");
				sb.AppendLine("SET ANSI_NULLS ON");
				sb.AppendLine("GO");
				sb.AppendLine();

				if (_model.Database.GrantExecUser != string.Empty)
				{
					sb.AppendFormat("GRANT EXECUTE ON [dbo].[{0}] TO [{1}]", StoredProcedureName, _model.Database.GrantExecUser);
					sb.AppendLine();
					sb.AppendLine("GO");
					sb.AppendLine();
				}

			}
			catch (Exception ex)
			{
				throw;
			}

		}

		#endregion

		#region string methods

		protected string BuildParameterList()
		{
			List<Column> items = new List<Column>();

			int index = 0;
			StringBuilder output = new StringBuilder();
			foreach (Reference reference in _currentComponent.Columns)
			{
				Column column = (Column)reference.Object;
				output.Append("\t@");
				output.Append(ValidationHelper.MakeDatabaseScriptIdentifier(column.DatabaseName));
				output.Append(" ");
				output.Append(column.DataType);
				if (StringHelper.Match(column.DataType, "binary", true) ||
					StringHelper.Match(column.DataType, "char", true) ||
					StringHelper.Match(column.DataType, "decimal", true) ||
					StringHelper.Match(column.DataType, "nchar", true) ||
					StringHelper.Match(column.DataType, "numeric", true) ||
					StringHelper.Match(column.DataType, "nvarchar", true) ||
					StringHelper.Match(column.DataType, "varbinary", true) ||
					StringHelper.Match(column.DataType, "varchar", true))
				{
					if (column.DataType == System.Data.SqlDbType.Decimal)
						output.Append("(" + column.GetLengthString() + ", 4)");
					else
						output.Append("(" + column.GetLengthString() + ")");

				}
				output.AppendLine(",");
				index++;
			}

			if (_currentComponent.Parent.AllowModifiedAudit)
			{
				output.AppendLine("\t@" + _model.Database.ModifiedByColumnName + " varchar (50),");
				output.AppendLine("\t@" + _model.Database.ModifiedDateColumnName + " datetime = null,");
			}

			//Get Column List      
			items = new List<Column>(_currentComponent.Parent.PrimaryKeyColumns);
			index = 0;
			foreach (Column dc in items)
			{
				output.Append("\t@Original_");
				output.Append(ValidationHelper.MakeDatabaseIdenitifer(dc.DatabaseName));
				output.Append(" ");
				output.Append(dc.DataType);
				if (StringHelper.Match(dc.DataType, "binary", true) ||
					StringHelper.Match(dc.DataType, "char", true) ||
					StringHelper.Match(dc.DataType, "decimal", true) ||
					StringHelper.Match(dc.DataType, "nchar", true) ||
					StringHelper.Match(dc.DataType, "numeric", true) ||
					StringHelper.Match(dc.DataType, "nvarchar", true) ||
					StringHelper.Match(dc.DataType, "varbinary", true) ||
					StringHelper.Match(dc.DataType, "varchar", true))
				{
					if (dc.DataType == System.Data.SqlDbType.Decimal)
						output.Append("(" + dc.GetLengthString() + ", 4)");
					else
						output.Append("(" + dc.GetLengthString() + ")");
				}
				if (index < items.Count - 1 || _currentComponent.Parent.AllowTimestamp)
					output.Append(",");
				output.AppendLine();
				index++;
			}

			if (_currentComponent.Parent.AllowTimestamp)
			{
				output.AppendLine("\t@Original_" + _model.Database.TimestampColumnName + " timestamp");
			}

			return output.ToString();
		}

		protected string BuildSetStatement(Table table)
		{
			try
			{
				List<Column> validColumns = new  List<Column>();
				foreach(Reference reference in _currentComponent.Columns)
				{
					validColumns.Add((Column)reference.Object);
				}				

				//Get Column List
				List<Column> columnList = new List<Column>();
				foreach (Reference reference in table.GeneratedColumns)
				{
					Column column = (Column)reference.Object;
					if (validColumns.Contains(column))
					{
						if (!column.PrimaryKey && (column.Identity != IdentityTypeConstants.Database))
							columnList.Add(column);
					}
				}

				int index = 0;
				StringBuilder output = new StringBuilder();
				foreach (Column column in columnList)
				{
					output.Append("[" + column.DatabaseName + "] = @" + ValidationHelper.MakeDatabaseIdenitifer(column.DatabaseName));
					if (index < columnList.Count - 1 || table.AllowModifiedAudit)
						output.Append(",");
					output.AppendLine();
					index++;
				}

				if (table.AllowModifiedAudit)
				{
					output.AppendLine("[" + _model.Database.ModifiedByColumnName + "] = @" + _model.Database.ModifiedByColumnName + ",");
					output.AppendLine("[" + _model.Database.ModifiedDateColumnName + "] = @" + _model.Database.ModifiedDateColumnName);
				}

				return output.ToString();
			}
			catch (Exception ex)
			{
				throw new Exception("BuildSetStatement failed: " + table.DatabaseName, ex);
			}
		}

		protected string BuildUpdateWhereStatement(Table table)
		{
			try
			{
				bool IsTimeStamp = (table == _currentComponent.Parent) && _currentComponent.Parent.AllowTimestamp;

				StringBuilder output = new StringBuilder();
				int index = 0;
				foreach (Column dc in table.PrimaryKeyColumns)
				{
					output.Append("[" + table.DatabaseName + "].");
					output.Append("[" + dc.DatabaseName + "] = ");
					output.Append("@Original_");
					output.Append(ValidationHelper.MakeDatabaseIdenitifer(dc.DatabaseName));
					if (index < table.PrimaryKeyColumns.Count - 1 || IsTimeStamp)
						output.Append(" AND" + Environment.NewLine + "\t");
					index++;
				}

				if (IsTimeStamp)
				{
					output.AppendFormat("[" + _currentComponent.Parent.DatabaseName + "].[{0}] = @Original_{0}", _model.Database.TimestampColumnName);
				}

				output.AppendLine();
				return output.ToString();
			}

			catch (Exception ex)
			{
				throw new Exception("BuildSetStatement failed: " + table.DatabaseName, ex);
			}
		}

		protected string BuildSelectWhereStatement()
		{
			try
			{
				StringBuilder output = new StringBuilder();
				int index = 0;
				foreach (Column dc in _currentComponent.Parent.PrimaryKeyColumns)
				{
					output.Append("[" + _currentComponent.Parent.DatabaseName + "].");
					output.Append("[" + dc.DatabaseName + "] = ");
					output.Append("@Original_" + dc.DatabaseName);
					if (index < _currentComponent.Parent.PrimaryKeyColumns.Count - 1)
						output.Append(" AND" + Environment.NewLine + "\t");
					index++;
				}
				return output.ToString();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string StoredProcedureName
		{
			get { return "gen_" + _currentComponent.PascalName + "Update"; }
		}

		#endregion

	}
}