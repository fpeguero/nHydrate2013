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
using System.Text;
using nHydrate.Generator.Models;
using nHydrate.Generator.Common.GeneratorFramework;

namespace nHydrate.Generator.DataTransfer
{
	class DataTransferObjectExtenderTemplate : BaseDataTransferTemplate
	{
		private readonly StringBuilder sb = new StringBuilder();
		private readonly INamedObject _dbItem;

		#region Constructors
		public DataTransferObjectExtenderTemplate(ModelRoot model, INamedObject dbItem)
			: base(model)
		{
			_dbItem = dbItem;
		}
		#endregion

		#region BaseClassTemplate overrides
		public override string FileContent
		{
			get
			{
				GenerateContent();
				return sb.ToString();
			}
		}

		public override string FileName
		{
			get
			{
				return string.Format("{0}.cs", _dbItem.PascalName);
			}
		}
		#endregion

		#region GenerateContent
		private void GenerateContent()
		{
			try
			{
				nHydrate.Generator.GenerationHelper.AppendCopyrightInCode(sb, _model);
				this.AppendUsingStatements();
				sb.AppendLine("namespace " + this.GetLocalNamespace());
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

		}

		public void AppendClass()
		{
			sb.AppendLine("		/// <summary>");
			sb.AppendLine("		/// This is a customizable extender class for the '" + _dbItem.PascalName + "' data transfer object");
			sb.AppendLine("		/// </summary>");
			sb.AppendLine("	public partial class " + _dbItem.PascalName);
			sb.AppendLine("	{");
			sb.AppendLine("	}");
		}

		#endregion

	}
}
