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
using System.Linq;
using nHydrate.Generator.Common.EventArgs;
using nHydrate.Generator.Common.GeneratorFramework;
using nHydrate.Generator.ProjectItemGenerators;
using nHydrate.Generator.Models;
using System.Collections.Generic;

namespace nHydrate.Generator.EFDAL.Mocks.Generators.ComplexTypes
{
	[GeneratorItem("ComplexTypesExtenderGenerator", typeof(EFDALMockProjectGenerator))]
	public class ComplexTypesExtenderGenerator : BaseClassGenerator
	{
		#region Class Members

		private const string RELATIVE_OUTPUT_LOCATION = @"\Entity\";

		#endregion

		#region Overrides

		public override int FileCount
		{
			get { return GetListSP().Count + GetListFunc().Count; }
		}

		private List<CustomStoredProcedure> GetListSP()
		{
			return _model.Database.CustomStoredProcedures
				.Where(x => x.Generated && x.Columns.Count != 0)
				.OrderBy(x => x.Name)
				.ToList();
		}

		private List<Function> GetListFunc()
		{
			return _model.Database.Functions
				.Where(x => x.Generated && x.IsTable)
				.OrderBy(x => x.Name)
				.ToList();
		}

		public override void Generate()
		{
			foreach (var item in GetListSP())
			{
				var template = new ComplexTypesSPExtenderTemplate(_model, item);
				var fullFileName = RELATIVE_OUTPUT_LOCATION + template.FileName;
				var eventArgs = new ProjectItemGeneratedEventArgs(fullFileName, template.FileContent, ProjectName, this, false);
				OnProjectItemGenerated(this, eventArgs);
			}

			foreach (var item in GetListFunc())
			{
				var template = new ComplexTypesFuncExtenderTemplate(_model, item);
				var fullFileName = RELATIVE_OUTPUT_LOCATION + template.FileName;
				var eventArgs = new ProjectItemGeneratedEventArgs(fullFileName, template.FileContent, ProjectName, this, false);
				OnProjectItemGenerated(this, eventArgs);
			}

			//Process deleted items
			foreach (var name in _model.RemovedStoredProcedures)
			{
				var fullFileName = RELATIVE_OUTPUT_LOCATION + name + ".cs";
				var eventArgs = new ProjectItemDeletedEventArgs(fullFileName, ProjectName, this);
				OnProjectItemDeleted(this, eventArgs);
			}

			//Process deleted items
			foreach (var name in _model.RemovedFunctions)
			{
				var fullFileName = RELATIVE_OUTPUT_LOCATION + name + ".cs";
				var eventArgs = new ProjectItemDeletedEventArgs(fullFileName, ProjectName, this);
				OnProjectItemDeleted(this, eventArgs);
			}

			var gcEventArgs = new ProjectItemGenerationCompleteEventArgs(this);
			OnGenerationComplete(this, gcEventArgs);
		}

		public override string LocalNamespaceExtension
		{
			get { return EFDALMockProjectGenerator.NamespaceExtension; }
		}

		#endregion

	}
}

