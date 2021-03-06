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

using Widgetsphere.Generator.Common.GeneratorFramework;
using Widgetsphere.Generator.Models;
using EnvDTE;
using Widgetsphere.Generator.Common.Util;

namespace Widgetsphere.Generator.ProjectItemGenerators
{
	[GeneratorItemAttribute("Database Installer/Updater", typeof(WidgetsphereGeneratorProject))]
	public class DatabaseProjectGenerator : BaseProjectGenerator
	{
		public override string ProjectName
		{
			get
			{
				ModelRoot modelRoot = ((ModelRoot)_model);
				return string.Format("{1}.{0}.Install", modelRoot.ProjectName, modelRoot.CompanyName);
			}
		}

		protected override string ProjectTemplate
		{
			get
			{
				return "database.vstemplate";
			}
		}

		protected override void OnAfterGenerate()
		{
			base.OnAfterGenerate();

			EnvDTE.Project project = EnvDTEHelper.Instance.GetProject(ProjectName);
			EnvDTE.Property preBuildProperty = project.Properties.Item("PreBuildEvent");
			preBuildProperty.Value = "attrib -r \"$(SolutionDir)Bin\\*.*\"";
			EnvDTE.Property postBuildProperty = project.Properties.Item("PostBuildEvent");
			postBuildProperty.Value = "copy \"$(TargetDir)$(TargetName).*\" \"$(SolutionDir)Bin\\\"";
		}
		protected override void OnInitialize(IModelObject model)
		{
			WidgetsphereGeneratorProject.AddICSharpDllToBinFolder();
		}
	}
}