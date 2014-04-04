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
using nHydrate.Generator.Common.GeneratorFramework;
using System.Globalization;
using nHydrate.Generator.Common.Util;
using System.IO;
using nHydrate.DslPackage.Objects;

namespace nHydrate.DslPackage.Forms
{
	internal partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();

			linkLabel1.Links.Add(new LinkLabel.Link(0, linkLabel1.Text.Length, linkLabel1.Text));
			txtKey.Text = AddinAppData.Instance.Key;
			txtKey.ReadOnly = (!string.IsNullOrEmpty(txtKey.Text));
			chkStat.Checked = AddinAppData.Instance.AllowStats;

			//if (!string.IsNullOrEmpty(txtKey.Text))
			//{
			//  cmdRegister.Visible = false;
			//}

			try
			{
				var fi = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
				var a = System.Reflection.Assembly.LoadFrom(Path.Combine(fi.DirectoryName, "nHydrate.Dsl.dll"));
				var v = a.GetName().Version;
				lblVersion.Text = "Version " + v.Major + "." + v.Minor + "." + v.Build + "." + v.Revision;
			}
			catch (Exception ex)
			{
				lblVersion.Text = "Version (Unknown)";
			}

			//cmdLibrary.Visible = GeneratorStoreHelper.IsStoreInstalled();
			cmdLibrary.Visible = false;
		}

		private void cmdLibrary_Click(object sender, System.EventArgs e)
		{
			//UIHelper.ShowLibraryDialog();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			if (AddinAppData.Instance.Key != txtKey.Text)
			{
				txtKey.Text = txtKey.Text.Trim();
				if (!ValidateRegistrationKey(txtKey.Text))
				{
					MessageBox.Show("The entered key is not valid.", "Invalid Key!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				if (chkStat.Checked != AddinAppData.Instance.AllowStats)
				{
					try
					{
						var service = new nHydrate.Generator.Common.nhydrateservice.MainService();
						service.Url = "http://www.nhydrate.org/Webservice/MainService.asmx";
						service.ResetStatistics(AddinAppData.Instance.Key, chkStat.Checked);
					}
					catch (Exception ex)
					{
						//Do Nothing
					}
				}

				AddinAppData.Instance.AllowStats = chkStat.Checked;
				AddinAppData.Instance.Key = txtKey.Text;
				AddinAppData.Instance.Save();
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			//Home Page
			linkLabel1.Links[linkLabel1.Links.IndexOf(e.Link)].Visited = true;
			System.Diagnostics.Process.Start("http://bit.ly/5JW5AB");
		}

		private bool ValidateRegistrationKey(string key)
		{
			try
			{
				var encData_byte = Convert.FromBase64String(key);
				var decode = System.Text.Encoding.UTF8.GetString(encData_byte);
				var arr = decode.Split('|');
				if (arr.Length == 3)
				{
					if (arr[0] != "nhydrate") return false;
					int id;
					if (!int.TryParse(arr[1], out id)) return false;
					DateTime theDate;
					if (!DateTime.TryParseExact(arr[2], "yyyyMMdd", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.NoCurrentDateDefault, out theDate)) return false;
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		private void cmdRegister_Click(object sender, System.EventArgs e)
		{
			//If already registered...warn
			if (!string.IsNullOrEmpty(txtKey.Text))
			{
				if (MessageBox.Show("This machine has already been registered and you are logged-in. Are you sure that you want re-register or login as a different user?", "Already Registered", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
				{
					return;
				}
			}

			this.DialogResult = DialogResult.Cancel;
			this.Hide();
			Application.DoEvents();
			this.Close();

			var F = new RegistrationForm();
			F.ShowDialog();

		}

		private void cmdCheckUpdate_Click(object sender, System.EventArgs e)
		{
			//Check for latest version
			if (VersionHelper.CanConnect())
			{
				if (VersionHelper.NeedUpdate(VersionHelper.GetLatestVersion()))
					MessageBox.Show("The version of nHydrate you are using is " + VersionHelper.GetCurrentVersion() + ". There is a newer version available " + VersionHelper.GetLatestVersion() + ". Download the latest version at http://nHydrate.CodePlex.com.", "New Version Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else
					MessageBox.Show("This is the latest version.", "Version Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("There was an error trying to connect to the server.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void linkReleaseNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			//string link = "http://nhydrate.codeplex.com/wikipage?title=Release%20Notes
			var link = "http://bit.ly/8xBPhd";
			linkLabel1.Links[0].Visited = true;
			System.Diagnostics.Process.Start(link);
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
			//System.Diagnostics.Process.Start("http://www.linkedin.com/groups?gid=2401073");
			System.Diagnostics.Process.Start("http://bit.ly/859IDc");
		}

		private void pictureBox2_Click(object sender, System.EventArgs e)
		{
			//System.Diagnostics.Process.Start("http://nhydrate.codeplex.com");
			System.Diagnostics.Process.Start("http://bit.ly/8gI7Ap");
		}

		private void pictureBox4_Click(object sender, System.EventArgs e)
		{
			//System.Diagnostics.Process.Start("http://www.youtube.com/nhydrate");
			System.Diagnostics.Process.Start("http://bit.ly/62Vaxz");
		}

		private void pictureBox5_Click(object sender, System.EventArgs e)
		{
			//System.Diagnostics.Process.Start("http://www.twitter.com/nhydrate");
			System.Diagnostics.Process.Start("http://bit.ly/5IIdmw");
		}

		private void pictureBox6_Click(object sender, System.EventArgs e)
		{
			//System.Diagnostics.Process.Start("http://nhydrate.blogspot.com/");
			System.Diagnostics.Process.Start("http://bit.ly/6XRZl1");
		}

		private void cmdGettingStarted_Click(object sender, EventArgs e)
		{
			var  fileName= Path.Combine(AddinAppData.Instance.ExtensionDirectory, "GettingStarted.pdf");
			if (File.Exists(fileName))
			{
				System.Diagnostics.Process.Start(fileName);
			}
			else
			{
				MessageBox.Show("The file could not be found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void cmdUserGuide_Click(object sender, EventArgs e)
		{
			var fileName = Path.Combine(AddinAppData.Instance.ExtensionDirectory, "UsersGuide.pdf");
			if (File.Exists(fileName))
			{
				System.Diagnostics.Process.Start(fileName);
			}
			else
			{
				MessageBox.Show("The file could not be found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}


	}
}
