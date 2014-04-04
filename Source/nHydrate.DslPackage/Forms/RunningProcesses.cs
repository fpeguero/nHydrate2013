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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nHydrate.DslPackage.Forms
{
	public partial class RunningProcesses : Form
	{
		private const string WINDOW_TEXT = "Processing nHydrate Model";
		private bool _hasShown = false;
		private DateTime _loaded = DateTime.Now;

		public RunningProcesses()
		{
			InitializeComponent();
			this.Text = WINDOW_TEXT;
			lblText.Text = string.Empty;
			lblSubText.Text = string.Empty;
			timer1.Start();
		}

		public void UpdateSubText(string text, string subText)
		{
			UpdateSubText(text, subText, -1, string.Empty);
		}

		public void UpdateSubText(string text, string subText, int progress, string windowTextAppend)
		{
			if (!string.IsNullOrEmpty(text))
			{
				lblText.Text = text;
			}

			lblSubText.Text = TruncatePathForDisplay(subText, lblSubText.Width, lblSubText.Font, TextFormatFlags.PathEllipsis);
			if (!string.IsNullOrEmpty(windowTextAppend))
			{
				this.Text = WINDOW_TEXT + " " + windowTextAppend;
			}

			if (0 <= progress && progress <= 100)
			{
				if (timer1.Enabled)
				{
					timer1.Stop();
					timer1.Enabled = false;
				}
				progressBar1.Value = progress;
			}
		}

		public void Update(string text, bool topMost, int timeout)
		{
			lblText.Text = text;
			this.TopMost = topMost;
			var tick = (timeout * 1000) / 100;
			if (tick <= 0) tick = 100;
			timer1.Interval = tick;
			this.Activate();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			var v = progressBar1.Value + 1;
			if (v > 100) v = 100;
			progressBar1.Value = v;
			Application.DoEvents();

			//Wait a short time and pop on top just in case it is hidden
			if (!_hasShown && DateTime.Now.Subtract(_loaded).TotalMilliseconds > 1000)
			{
				_hasShown = true;
				this.Activate();
			}
		}

		private static string TruncatePathForDisplay(string text, int Width, System.Drawing.Font font, System.Windows.Forms.TextFormatFlags FormatFlags)
		{
			var result = string.Copy(text);
			TextRenderer.MeasureText(result, font, new System.Drawing.Size(Width, 0), FormatFlags | TextFormatFlags.ModifyString);
			return result;
		}

	}
}
