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
using System.Linq;
using System.Collections.Generic;
using System.Text;
using nHydrate.Generator;
using nHydrate.Generator.Models;
using System.Collections;
using System.Xml;
using nHydrate.Generator.Common.Util;
using System.IO;
using nHydrate.Generator.Common.GeneratorFramework;
using nHydrate.Generator.Common;
using nHydrate.Generator.SQLInstaller;
using nHydrate.Generator.ProjectItemGenerators;

namespace nHydrate.Generator.SQLInstaller.ProjectItemGenerators.DatabaseSchema
{
	class UpgradeUnversionedScriptTemplate : BaseDbScriptTemplate
	{
		private StringBuilder sb = new StringBuilder();

		#region Constructors
		public UpgradeUnversionedScriptTemplate(ModelRoot model)
			: base(model)
		{
		}
		#endregion 

		#region BaseClassTemplate overrides
		public override string FileContent
		{
			get 
			{
				this.GenerateContent();
				return sb.ToString();
			}
		}

		public override string FileName
		{
			get 
			{
				var versionNumbers = _model.Version.Split('.');
				var major = int.Parse(versionNumbers[0]);
				var minor = int.Parse(versionNumbers[1]);
				var revision = int.Parse(versionNumbers[2]);
				var build = int.Parse(versionNumbers[3]);
				return string.Format("UnversionedUpgradeScript.sql", new object[] { major, minor, revision, build, _model.GeneratedVersion });
			}
		}
		
		#endregion

		#region GenerateContent
		private void GenerateContent()
		{
			try
			{
				sb = new StringBuilder();
				sb.AppendLine("--Generated Unversioned Upgrade");
				sb.AppendLine("--Generated on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				sb.AppendLine();

				sb.AppendLine("--UNCOMMENT TO DROP ALL DEFAULTS IF NEEDED. IF THIS MODEL WAS IMPORTED FROM AN EXISTSING DATABASE THE MODEL WILL RECREATE ALL DEFAULTS WITH A GENERATED NAME.");
				sb.AppendLine("--DROP ALL DEFAULTS");
				sb.AppendLine("--DECLARE @SqlCmd varchar(4000); SET @SqlCmd = ''");
				sb.AppendLine("--DECLARE @Cnt int; SET @Cnt = 0");
				sb.AppendLine("--select @Cnt = count(*) from sysobjects d");
				sb.AppendLine("--join  sysobjects o on d.parent_obj = o.id");
				sb.AppendLine("--where d.xtype = 'D'");
				sb.AppendLine(" ");
				sb.AppendLine("--WHILE @Cnt > 0");
				sb.AppendLine("--BEGIN");
				sb.AppendLine("--      select TOP 1 @SqlCmd = 'ALTER TABLE ' + o.name + ' DROP CONSTRAINT ' + d.name");
				sb.AppendLine("--      from sysobjects d");
				sb.AppendLine("--      join sysobjects o on d.parent_obj = o.id");
				sb.AppendLine("--      where d.xtype = 'D'");
				sb.AppendLine("--      EXEC(@SqlCmd) --SELECT @SqlCmd --view the command only");
				sb.AppendLine("--      select @Cnt = count(*) from   sysobjects d");
				sb.AppendLine("--      join  sysobjects o on d.parent_obj = o.id");
				sb.AppendLine("--      where d.xtype = 'D'");
				sb.AppendLine("--END");
				sb.AppendLine("--GO");
				sb.AppendLine();

				//If the indexes have a name on import then rename it
				sb.AppendLine("--RENAME OLD INDEXES FROM THE IMPORT DATABASE IF NEEDED");
				sb.AppendLine();
				foreach (var table in _model.Database.Tables.Where(x => x.Generated && x.TypedTable != TypedTableConstants.EnumOnly).OrderBy(x => x.Name))
				{
					foreach (var index in table.TableIndexList)
					{
						if (!string.IsNullOrEmpty(index.ImportedName))
						{
							var indexName = nHydrate.Core.SQLGeneration.SQLEmit.GetIndexName(table, index);
							if (index.ImportedName != indexName)
							{
								sb.AppendLine("if exists(select * from sysobjects where name = '" + table.DatabaseName + "' and xtype = 'U')");
								sb.AppendLine("BEGIN");
								sb.AppendLine("if exists(select * from sys.indexes where name = '" + index.ImportedName + "')");
								sb.AppendLine("EXEC sp_rename N'" + table.DatabaseName + "." + index.ImportedName + "', N'" + indexName + "', N'INDEX';");
								sb.AppendLine("END");
								sb.AppendLine("GO");
								sb.AppendLine();
							}
						}
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

