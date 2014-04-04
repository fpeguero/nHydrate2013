﻿namespace PROJECTNAMESPACE
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Drawing;
	using System.Data;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;

	internal partial class InstallSettingsUI : UserControl
	{
		public InstallSettingsUI()
		{
			InitializeComponent();
		}

		public void LoadUI(InstallSetup setup)
		{
			chkIgnoreWarnings.Checked = setup.AcceptVersionWarnings;
			chkSkipNormalize.Checked = !setup.Normalize;
			chkUseTransaction.Checked = setup.UseTransaction;
			chkUseHash.Checked = setup.UseHashes;
		}

		public void SaveUI(InstallSetup setup)
		{
			setup.AcceptVersionWarnings = chkIgnoreWarnings.Checked;
			setup.Normalize = !chkSkipNormalize.Checked;
			setup.UseTransaction = chkUseTransaction.Checked;
			setup.UseHashes = chkUseHash.Checked;
		}

		private void cmdHelp_Click(object sender, EventArgs e)
		{
			//Create Help dialog
			var sb = new StringBuilder();
			sb.AppendLine("Creates or updates a Sql Server database");
			sb.AppendLine();
			sb.AppendLine("InstallUtil.exe PROJECTNAMESPACE.dll [/upgrade] [/create] [/master:connectionstring] [/connectionstring:connectionstring] [/newdb:name] [/showsql] [/notran] [/nonormalize] [/scriptfile:filename] [/scriptfileaction:append] [/usehashes]");
			sb.AppendLine();
			sb.AppendLine("Providing no parameters will display the default UI.");
			sb.AppendLine();
			sb.AppendLine("/upgrade");
			sb.AppendLine("Specifies that this is an update database operation");
			sb.AppendLine();
			sb.AppendLine("/create");
			sb.AppendLine("Specifies that this is a create database operation");
			sb.AppendLine();
			sb.AppendLine("/master:\"connectionstring\"");
			sb.AppendLine("Specifies the master connection string. This is only required for create database.");
			sb.AppendLine();
			sb.AppendLine("/connectionstring:\"connectionstring\"");
			sb.AppendLine("/Specifies the connection string to the upgrade database");
			sb.AppendLine();
			sb.AppendLine("newdb:name");
			sb.AppendLine("/When creating a new database, this is the name of the newly created database.");
			sb.AppendLine();
			sb.AppendLine("/showsql");
			sb.AppendLine("Displays each SQL statement in the console window as its executed");
			sb.AppendLine();
			sb.AppendLine("/notran");
			sb.AppendLine("Specifies not to use transactions. There is no rollback functionality if an error occurs!");
			sb.AppendLine();
			sb.AppendLine("/nonormalize");
			sb.AppendLine("Specifies to use only the upgrade scripts on an upgrade. The normalization script to correct for any database errors will not be run.");
			sb.AppendLine();
			sb.AppendLine("/scriptfile:filename");
			sb.AppendLine("Specifies that a script be created and written to the specified file.");
			sb.AppendLine();
			sb.AppendLine("/scriptfileaction:append");
			sb.AppendLine("Optionally you can specify to append the script to an existing file. If this parameter is omitted, the file will first be deleted if it exists.");
			sb.AppendLine();
			sb.AppendLine("/usehashes");
			sb.AppendLine("Hash valeus for all scripts are stored on a success create or upgrade. You may choose to use these as a comparison tool and only apply scripts on upgrade that have changed by hash value. This may greatly improve upgrade performance with large script sets.");

			MessageBox.Show(sb.ToString(), "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

	}
}
