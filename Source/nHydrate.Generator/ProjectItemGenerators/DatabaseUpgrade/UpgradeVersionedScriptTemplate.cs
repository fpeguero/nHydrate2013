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
using System.Collections.Generic;
using System.Text;
using Widgetsphere.Generator;
using Widgetsphere.Generator.Models;
using System.Collections;
using System.Xml;
using Widgetsphere.Generator.Common.Util;
using System.IO;
using Widgetsphere.Generator.Common.GeneratorFramework;
using Widgetsphere.Generator.Common;

namespace Widgetsphere.Generator.ProjectItemGenerators.DatabaseSchema
{
	class UpgradeVersionedTemplate : BaseDbScriptTemplate
	{
		private StringBuilder sb = new StringBuilder();		

		#region Constructors
		public UpgradeVersionedTemplate(ModelRoot model)
    {
      _model = model;
		}
		#endregion 

		#region BaseClassTemplate overrides
		public override string FileContent
		{
			get 
			{
				this.IncrementNextGeneratedVersion();
				this.GenerateContent();
				return sb.ToString();
			}
		}

		public override string FileName
		{
			get 
			{
				string[] versionNumbers = _model.Version.Split('.');
				int major = int.Parse(versionNumbers[0]);
				int minor = int.Parse(versionNumbers[1]);
				int revision = int.Parse(versionNumbers[2]);
				int build = int.Parse(versionNumbers[3]);
				int generated = this.GetNextGeneratedVersion();
				return string.Format("{0}_{1}_{2}_{3}_{4}_GeneratedScript.sql", new object[] { major, minor, revision, build, generated });
			}
		}

		private void IncrementNextGeneratedVersion()
		{
			ModelCacheFile cacheFile = new ModelCacheFile(_model.GeneratorProject);
			cacheFile.GeneratedVersion++;
			cacheFile.Save();			
		}

		private int GetNextGeneratedVersion()
		{
			ModelCacheFile cacheFile = new ModelCacheFile(_model.GeneratorProject);
			return cacheFile.GeneratedVersion;
		}

		#endregion

		#region GenerateContent
		private void GenerateContent()
		{
      try
      {
				sb = new StringBuilder();
				sb.AppendLine("--Generated Upgrade For Version " + _model.Version + "." + this.GetNextGeneratedVersion());
				sb.AppendLine("--Generated on " + DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));
				sb.AppendLine();

				//***********************************************************
				//ATTEMPT TO GENERATE AN UPGRADE SCRIPT FROM PREVIOUS VERSION
				//***********************************************************				

				#region Generate Upgrade Script

				//Find the previous model file if one exists
				string fileName = this._model.GeneratorProject.FileName;
				System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
				if (fi.Exists)
				{
					fileName = fi.Name + ".lastgen";
					fileName = System.IO.Path.Combine(fi.DirectoryName, fileName);
					fi = new System.IO.FileInfo(fileName);
					if (fi.Exists)
					{
						//Load the previous model
						Widgetsphere.Generator.Common.GeneratorFramework.IGenerator generator = Widgetsphere.Generator.Common.GeneratorFramework.GeneratorHelper.OpenModel(fi.FullName);
						ModelRoot oldRoot = (ModelRoot)generator.RootController.Object;
						sb.Append(DatabaseHelper.GetModelDifferenceSQL(oldRoot, _model));

						//Copy the current LASTGEN file to BACKUP
						fi.CopyTo(fileName + ".bak", true);
					}

					//Save this version on top of the old version
					System.IO.FileInfo currentFile = new System.IO.FileInfo(this._model.GeneratorProject.FileName);
					currentFile.CopyTo(fileName, true);

				}

				#endregion

			}
      catch(Exception ex)
      {
        throw;
      }
		}
		#endregion
	}
}
