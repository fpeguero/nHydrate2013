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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nHydrate.Generator.Common.GeneratorFramework;
using nHydrate.Generator.Common.Util;
using nHydrate.Generator.Models;
using nHydrate.Generator.EFDAL.Interfaces;

namespace nHydrate.Generator.EFDAL.Interfaces.Generators.ComplexTypes
{
	public class ComplexTypesFuncGeneratedTemplate : EFDALInterfaceBaseTemplate
	{
		private StringBuilder sb = new StringBuilder();
		private readonly Function  _item;

		public ComplexTypesFuncGeneratedTemplate(ModelRoot model, Function item)
			: base(model)
		{
			_item = item;
		}

		#region BaseClassTemplate overrides
		public override string FileName
		{
			get { return string.Format("I{0}.Generated.cs", _item.PascalName); }
		}

		public string ParentItemName
		{
			get { return string.Format("I{0}.cs", _item.PascalName); }
		}

		public override string FileContent
		{
			get
			{
				try
				{
					sb = new StringBuilder();
					this.GenerateContent();
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

		private void GenerateContent()
		{
			try
			{
				nHydrate.Generator.GenerationHelper.AppendFileGeneatedMessageInCode(sb);
				nHydrate.Generator.GenerationHelper.AppendCopyrightInCode(sb, _model);
				this.AppendUsingStatements();
				sb.AppendLine("namespace " + this.GetLocalNamespace() + ".Entity");
				sb.AppendLine("{");
				this.AppendEntityClass();
				sb.AppendLine("}");
				sb.AppendLine();
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
			sb.AppendLine();
		}

		private void AppendEntityClass()
		{
		
			sb.AppendLine("	/// <summary>");
			sb.AppendLine("	/// This is the interface for the entity " + _item.PascalName);
			sb.AppendLine("	/// </summary>");
			sb.AppendLine("	public partial interface I" + _item.PascalName);
			sb.AppendLine("	{");
			this.AppendProperties();
			sb.AppendLine("	}");
			sb.AppendLine();
		}

		private void AppendProperties()
		{
			sb.AppendLine("		#region Properties");
			sb.AppendLine();

			foreach (var column in _item.GetColumns().Where(x => x.Generated).OrderBy(x => x.Name))
			{
				sb.AppendLine("		/// <summary>");
				if (!string.IsNullOrEmpty(column.Description))
					StringHelper.LineBreakCode(sb, column.Description, "		/// ");
				else
					sb.AppendLine("		/// The property for the field '" + column.DatabaseName + "'");
				sb.AppendLine("		/// </summary>");
				sb.Append("		" + column.GetCodeType() + " " + column.PascalName);
				sb.AppendLine(" { get; }");
				sb.AppendLine();
			}

			sb.AppendLine("		#endregion");
			sb.AppendLine();
		}

		#endregion

	}
}
