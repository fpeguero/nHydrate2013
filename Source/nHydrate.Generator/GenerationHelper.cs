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
using nHydrate.Generator.Common.Forms;
using nHydrate.Generator.Models;

namespace nHydrate.Generator
{
	public static class GenerationHelper
	{
		public static void AppendCopyrightInCode(StringBuilder sb, ModelRoot model)
		{
			if (!string.IsNullOrEmpty(model.Copyright))
			{
				sb.AppendLine("#region Copyright (c) " + DateTime.Now.Year + " " + model.CompanyName + ", All Rights Reserved");

				var temp = model.Copyright.Replace("\r\n", "\n");
				temp = temp.Replace("\r", "\n");
				temp = temp.Replace("%year%", DateTime.Now.Year.ToString());
				var arr = temp.Split('\n');
				foreach (var s in arr)
				{
					sb.AppendLine("//" + s);
				}
				sb.AppendLine("#endregion");
				sb.AppendLine();
			}
		}

		public static void AppendCopyrightInSQL(StringBuilder sb, ModelRoot model)
		{
			if (!string.IsNullOrEmpty(model.Copyright))
			{
				sb.AppendLine("--Copyright (c) " + DateTime.Now.Year + " " + model.CompanyName + ", All Rights Reserved");

				var temp = model.Copyright.Replace("\r\n", "\n");
				temp = temp.Replace("\r", "\n");
				temp = temp.Replace("%year%", DateTime.Now.Year.ToString());
				var arr = temp.Split('\n');
				foreach (var s in arr)
				{
					sb.AppendLine("--" + s);
				}
				sb.AppendLine();
			}
		}

		public static void AppendFileGeneatedMessageInCode(StringBuilder sb)
		{
			sb.AppendLine("//------------------------------------------------------------------------------");
			sb.AppendLine("// <auto-generated>");
			sb.AppendLine("//    This code was generated from a template.");
			sb.AppendLine("//");
			sb.AppendLine("//    Manual changes to this file may cause unexpected behavior in your application.");
			sb.AppendLine("//    Manual changes to this file will be overwritten if the code is regenerated.");
			sb.AppendLine("// </auto-generated>");
			sb.AppendLine("//------------------------------------------------------------------------------");
			sb.AppendLine();
		}

		public static void ShowError(string text)
		{
			var F = new ErrorForm(text, "No other information is available.");
			F.ShowDialog();
		}

		public static void ShowError(string text, Exception exception)
		{
			var F = new ErrorForm(text, exception.ToString());
			F.ShowDialog();
		}


	}
}
