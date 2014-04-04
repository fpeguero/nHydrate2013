//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROJECTNAMESPACE
{
	using System;
	using System.Text;
	using System.Drawing;
	using System.ComponentModel;
	using System.Windows.Forms;
	using System.Collections;
	using System.Data.SqlClient;
	using System.IO;
	using System.Xml;
	using System.Xml.XPath;
	using System.Collections.Generic;

	/// <summary>
	/// 
	/// </summary>
	internal enum ActionTypeConstants
	{
		/// <summary>
		/// 
		/// </summary>
		Create,
		/// <summary>
		/// 
		/// </summary>
		Upgrade,
		/// <summary>
		/// 
		/// </summary>
		AzureCopy,
	}

	internal partial class IdentifyDatabaseForm : Form
	{
		public ActionTypeConstants Action { get; private set; }

		public IdentifyDatabaseForm()
		{
			InitializeComponent();
		}

		private InstallSetup _setup;
		public IdentifyDatabaseForm(InstallSetup setup)
			: this()
		{
			this.Settings = new InstallSettings();
			_setup = setup;
			this.InstallSettingsUI1.LoadUI(setup);

			cmdCancel.Click += new EventHandler(cmdCancel_Click);
			cmdOK.Click += new EventHandler(cmdOK_Click);
			cboConnectionDatabaseName.DropDown += cboConnectionDatabaseName_DropDown;
			cboConnectionServerName.DropDown += ServerName_DropDown;
			cboCreationServerName.DropDown += ServerName_DropDown;
			buttonCreationRefresh.Click += buttonCreationRefresh_Click;
			optConnectionUserPassword.CheckedChanged += optConnectionUserPassword_CheckedChanged;
			radioButtonCreationUserPassword.CheckedChanged += radioButtonCreationUserPassword_CheckedChanged;
			optCreationIntegratedSecurity.CheckedChanged += optCreationIntegratedSecurity_CheckedChanged;
			cmdViewHistory.Click += cmdViewHistory_Click;
			buttonConnectionTestConnection.Click += buttonConnectionTestConnection_Click;
			optConnectionIntegratedSecurity.CheckedChanged += optConnectionIntegratedSecurity_CheckedChanged;
			buttonConnectionRefresh.Click += buttonConnectionRefresh_Click;

			//Turn off features for Azure
			//if (SqlServers.DatabaseVersion != SqlServers.SQLServerTypeConstants.SQLAzure)
			//  tabControlChooseDatabase.TabPages.Remove(tabPageAzureCopy);

			this.Settings.Load();
			if (this.Settings.IsLoaded)
			{
				chkSaveSettings.Checked = true;

				//Tab Upgrade
				cboConnectionServerName.Text = this.Settings.PrimaryServer;
				optConnectionIntegratedSecurity.Checked = this.Settings.PrimaryUseIntegratedSecurity;
				optConnectionUserPassword.Checked = !optConnectionIntegratedSecurity.Checked;
				txtConnectionUserName.Text = this.Settings.PrimaryUserName;
				txtConnectionPassword.Text = this.Settings.PrimaryPassword;
				cboConnectionDatabaseName.Text = this.Settings.PrimaryDatabase;

				//Tab Create
				cboCreationServerName.Text = this.Settings.PrimaryServer;
				txtCreationDatabaseName.Text = this.Settings.PrimaryDatabase;
				optCreationIntegratedSecurity.Checked = this.Settings.PrimaryUseIntegratedSecurity;
				radioButtonCreationUserPassword.Checked = !optCreationIntegratedSecurity.Checked;
				txtCreationUserName.Text = this.Settings.PrimaryUserName;
				txtCreationPassword.Text = this.Settings.PrimaryPassword;

				//Tab Azure Copy
				azureCopyControl1.LoadSettings(this.Settings);
			}
			this.UpdateLogin();

		}

		internal InstallSettings Settings { get; private set; }

		#region Tab1 Connection

		private void ServerName_DropDown(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				if (cboConnectionServerName.Items.Count == 0)
				{
					((ComboBox)sender).DataSource = SqlServers.GetServers();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void buttonConnectionRefresh_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				if (cboConnectionServerName.Items.Count == 0)
				{
					cboConnectionServerName.DataSource = SqlServers.GetServers();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void buttonConnectionTestConnection_Click(object sender, System.EventArgs e)
		{
			var connectString = SqlServers.BuildConnectionString(optConnectionIntegratedSecurity.Checked, cboConnectionDatabaseName.Text, cboConnectionServerName.Text, txtConnectionUserName.Text, txtConnectionPassword.Text);
			var valid = SqlServers.TestConnectionString(connectString);
			if (valid)
			{
				MessageBox.Show("Connection Succeeded.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("The information does not describe a valid connection string.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void radioButtonConnectionUsePasswordIntegratedSecurity_CheckedChanged(object sender, System.EventArgs e)
		{
			txtConnectionPassword.Enabled = true;
			txtConnectionUserName.Enabled = true;
		}

		private void radioButtonConnectionIntegratedSecurity_CheckedChanged(object sender, System.EventArgs e)
		{
			txtConnectionPassword.Enabled = false;
			txtConnectionUserName.Enabled = false;
		}

		private void cboConnectionDatabaseName_DropDown(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				cboConnectionDatabaseName.Items.Clear();
				if (!string.IsNullOrEmpty(cboConnectionServerName.Text))
				{
					(sender as ComboBox).Items.AddRange(GetDatabaseNames());
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		#endregion

		#region OK/Cancel Handlers
		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			this.SaveSettings();
			if (tabControlChooseDatabase.SelectedTab == this.tabPageConnection)
			{
				var connectString = SqlServers.BuildConnectionString(optConnectionIntegratedSecurity.Checked, cboConnectionDatabaseName.Text, cboConnectionServerName.Text, txtConnectionUserName.Text, txtConnectionPassword.Text);
				var valid = SqlServers.TestConnectionString(connectString);
				if (valid)
				{
					this.InstallSettingsUI1.SaveUI(_setup);
					this.Action = ActionTypeConstants.Upgrade;
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					MessageBox.Show("The information does not describe a valid connection string.");
				}
			}
			else if (tabControlChooseDatabase.SelectedTab == this.tabPageCreation)
			{
				bool error = false;
				if (_cbCreateDatabase.Checked)
				{
					error = CreateDatabase();
				}

				if (!error)
				{
					var outputConnectString = SqlServers.BuildConnectionString(optCreationIntegratedSecurity.Checked, txtCreationDatabaseName.Text, cboCreationServerName.Text, txtCreationUserName.Text, txtCreationPassword.Text);
					if (SqlServers.TestConnectionString(outputConnectString))
					{
						//_connectionString = outputConnectString;
						//_databaseName = cboCreationServerName.Text + "." + txtCreationDatabaseName.Text;
						//_createdDb = true;
					}
					this.Action = ActionTypeConstants.Create;
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			else if (tabControlChooseDatabase.SelectedTab == this.tabPageAzureCopy)
			{
				this.Action = ActionTypeConstants.AzureCopy;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private bool CreateDatabase()
		{
			var error = false;
			var connectString = SqlServers.BuildConnectionString(optCreationIntegratedSecurity.Checked, string.Empty, cboCreationServerName.Text, txtCreationUserName.Text, txtCreationPassword.Text);
			if (SqlServers.TestConnectionString(connectString) && SqlServers.HasCreatePermissions(connectString))
			{
				try
				{
					var setup = new InstallSetup()
					{
						MasterConnectionString = connectString,
						NewDatabaseName = txtCreationDatabaseName.Text,
					};
					SqlServers.CreateDatabase(setup);
				}
				catch (Exception ex)
				{
					error = true;
					System.Diagnostics.Debug.WriteLine(ex.ToString());
					MessageBox.Show("Could not create database." + Environment.NewLine + ex.Message);
				}
			}
			else
			{
				error = true;
				MessageBox.Show("The account does not have permissions to create a database on this server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return error;
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void cmdViewHistory_Click(object sender, EventArgs e)
		{
			string connectionString = SqlServers.BuildConnectionString(optConnectionIntegratedSecurity.Checked, cboConnectionDatabaseName.Text, cboConnectionServerName.Text, txtConnectionUserName.Text, txtConnectionPassword.Text);

			if (!SqlServers.TestConnectionString(connectionString))
			{
				MessageBox.Show("The information does not describe a valid connection string.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			HistoryForm F = new HistoryForm(connectionString);
			F.Show();
		}

		#endregion

		#region Tab2 Creation
		private void comboBoxCreationServerName_DropDown(object sender, System.EventArgs e)
		{
			if (cboCreationServerName.Items.Count == 0)
			{
				cboCreationServerName.DataSource = SqlServers.GetServers();
			}
		}

		private void buttonCreationRefresh_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				if (cboConnectionServerName.Items.Count == 0)
				{
					cboCreationServerName.DataSource = SqlServers.GetServers();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void radioButtonCreationUsePassword_CheckedChanged(object sender, System.EventArgs e)
		{
			txtCreationPassword.Enabled = true;
			txtCreationUserName.Enabled = true;
		}

		private void radioButtonCreationIntegratedSecurity_CheckedChanged(object sender, System.EventArgs e)
		{
			txtCreationPassword.Enabled = false;
			txtCreationUserName.Enabled = false;
		}

		#endregion

		#region Public Properties

		#endregion

		private void SaveSettings()
		{
			this.Settings.Kill();
			if (tabControlChooseDatabase.SelectedTab == tabPageConnection)
			{
				this.Settings.PrimaryServer = cboConnectionServerName.Text;
				this.Settings.PrimaryUseIntegratedSecurity = optConnectionIntegratedSecurity.Checked;
				this.Settings.PrimaryUserName = txtConnectionUserName.Text;
				this.Settings.PrimaryPassword = txtConnectionPassword.Text;
				this.Settings.PrimaryDatabase = cboConnectionDatabaseName.Text;
			}
			else if (tabControlChooseDatabase.SelectedTab == tabPageCreation)
			{
				this.Settings.PrimaryServer = cboCreationServerName.Text;
				this.Settings.PrimaryDatabase = txtCreationDatabaseName.Text;
				this.Settings.PrimaryUseIntegratedSecurity = optCreationIntegratedSecurity.Checked;
				this.Settings.PrimaryUserName = txtCreationUserName.Text;
				this.Settings.PrimaryPassword = txtCreationPassword.Text;
			}
			else if (tabControlChooseDatabase.SelectedTab == tabPageAzureCopy)
			{
				azureCopyControl1.SaveSettings(this.Settings);
			}

			if (chkSaveSettings.Checked)
			{
				this.Settings.Save();
			}
		}

		private string[] GetDatabaseNames()
		{
			var connectString = SqlServers.BuildConnectionString(optConnectionIntegratedSecurity.Checked,
					cboConnectionDatabaseName.Text,
					cboConnectionServerName.Text,
					txtConnectionUserName.Text,
					txtConnectionPassword.Text);
			return SqlServers.GetDatabaseNames(connectString);
		}

		private void UpdateLogin()
		{
			txtConnectionPassword.Enabled = !optConnectionIntegratedSecurity.Checked;
			txtConnectionUserName.Enabled = !optConnectionIntegratedSecurity.Checked;
			txtCreationPassword.Enabled = !optCreationIntegratedSecurity.Checked;
			txtCreationUserName.Enabled = !optCreationIntegratedSecurity.Checked;
		}

		private void optConnectionIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdateLogin();
		}

		private void optConnectionUserPassword_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdateLogin();
		}

		private void optCreationIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdateLogin();
		}

		private void radioButtonCreationUserPassword_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdateLogin();
		}

	}
}
