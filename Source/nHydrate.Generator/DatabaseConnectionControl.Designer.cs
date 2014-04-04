﻿namespace nHydrate.Generator
{
	partial class DatabaseConnectionControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.grpConnectionString = new System.Windows.Forms.GroupBox();
			this.lblConnectionString = new System.Windows.Forms.Label();
			this.txtConnectionString = new System.Windows.Forms.TextBox();
			this.opt2 = new System.Windows.Forms.RadioButton();
			this.grpProperties = new System.Windows.Forms.GroupBox();
			this.chkWinAuth = new System.Windows.Forms.CheckBox();
			this.lblServer = new System.Windows.Forms.Label();
			this.txtPWD = new System.Windows.Forms.TextBox();
			this.opt1 = new System.Windows.Forms.RadioButton();
			this.lblDatabase = new System.Windows.Forms.Label();
			this.txtUID = new System.Windows.Forms.TextBox();
			this.lblUID = new System.Windows.Forms.Label();
			this.txtDatabase = new System.Windows.Forms.TextBox();
			this.lblPWD = new System.Windows.Forms.Label();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.grpConnectionString.SuspendLayout();
			this.grpProperties.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpConnectionString
			// 
			this.grpConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpConnectionString.Controls.Add(this.lblConnectionString);
			this.grpConnectionString.Controls.Add(this.txtConnectionString);
			this.grpConnectionString.Controls.Add(this.opt2);
			this.grpConnectionString.Location = new System.Drawing.Point(3, 172);
			this.grpConnectionString.Name = "grpConnectionString";
			this.grpConnectionString.Size = new System.Drawing.Size(395, 57);
			this.grpConnectionString.TabIndex = 20;
			this.grpConnectionString.TabStop = false;
			// 
			// lblConnectionString
			// 
			this.lblConnectionString.AutoSize = true;
			this.lblConnectionString.Location = new System.Drawing.Point(19, 27);
			this.lblConnectionString.Name = "lblConnectionString";
			this.lblConnectionString.Size = new System.Drawing.Size(112, 13);
			this.lblConnectionString.TabIndex = 5;
			this.lblConnectionString.Text = "Database connection:";
			// 
			// txtConnectionString
			// 
			this.txtConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtConnectionString.Location = new System.Drawing.Point(136, 24);
			this.txtConnectionString.Name = "txtConnectionString";
			this.txtConnectionString.Size = new System.Drawing.Size(245, 20);
			this.txtConnectionString.TabIndex = 7;
			// 
			// opt2
			// 
			this.opt2.AutoSize = true;
			this.opt2.Location = new System.Drawing.Point(6, 0);
			this.opt2.Name = "opt2";
			this.opt2.Size = new System.Drawing.Size(107, 17);
			this.opt2.TabIndex = 6;
			this.opt2.TabStop = true;
			this.opt2.Text = "Connection string";
			this.opt2.UseVisualStyleBackColor = true;
			this.opt2.CheckedChanged += new System.EventHandler(this.opt2_CheckedChanged);
			// 
			// grpProperties
			// 
			this.grpProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpProperties.Controls.Add(this.chkWinAuth);
			this.grpProperties.Controls.Add(this.lblServer);
			this.grpProperties.Controls.Add(this.txtPWD);
			this.grpProperties.Controls.Add(this.opt1);
			this.grpProperties.Controls.Add(this.lblDatabase);
			this.grpProperties.Controls.Add(this.txtUID);
			this.grpProperties.Controls.Add(this.lblUID);
			this.grpProperties.Controls.Add(this.txtDatabase);
			this.grpProperties.Controls.Add(this.lblPWD);
			this.grpProperties.Controls.Add(this.txtServer);
			this.grpProperties.Location = new System.Drawing.Point(5, 7);
			this.grpProperties.Name = "grpProperties";
			this.grpProperties.Size = new System.Drawing.Size(395, 159);
			this.grpProperties.TabIndex = 19;
			this.grpProperties.TabStop = false;
			// 
			// chkWinAuth
			// 
			this.chkWinAuth.AutoSize = true;
			this.chkWinAuth.Checked = true;
			this.chkWinAuth.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkWinAuth.Location = new System.Drawing.Point(134, 133);
			this.chkWinAuth.Name = "chkWinAuth";
			this.chkWinAuth.Size = new System.Drawing.Size(163, 17);
			this.chkWinAuth.TabIndex = 5;
			this.chkWinAuth.Text = "Use Windows Authentication";
			this.chkWinAuth.UseVisualStyleBackColor = true;
			this.chkWinAuth.CheckedChanged += new System.EventHandler(this.chkWinAuth_CheckedChanged);
			// 
			// lblServer
			// 
			this.lblServer.AutoSize = true;
			this.lblServer.Location = new System.Drawing.Point(14, 29);
			this.lblServer.Name = "lblServer";
			this.lblServer.Size = new System.Drawing.Size(41, 13);
			this.lblServer.TabIndex = 9;
			this.lblServer.Text = "Server:";
			// 
			// txtPWD
			// 
			this.txtPWD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPWD.Location = new System.Drawing.Point(131, 106);
			this.txtPWD.Name = "txtPWD";
			this.txtPWD.Size = new System.Drawing.Size(245, 20);
			this.txtPWD.TabIndex = 4;
			this.txtPWD.UseSystemPasswordChar = true;
			// 
			// opt1
			// 
			this.opt1.AutoSize = true;
			this.opt1.Checked = true;
			this.opt1.Location = new System.Drawing.Point(6, 0);
			this.opt1.Name = "opt1";
			this.opt1.Size = new System.Drawing.Size(120, 17);
			this.opt1.TabIndex = 0;
			this.opt1.TabStop = true;
			this.opt1.Text = "Database properties";
			this.opt1.UseVisualStyleBackColor = true;
			this.opt1.CheckedChanged += new System.EventHandler(this.opt1_CheckedChanged);
			// 
			// lblDatabase
			// 
			this.lblDatabase.AutoSize = true;
			this.lblDatabase.Location = new System.Drawing.Point(14, 54);
			this.lblDatabase.Name = "lblDatabase";
			this.lblDatabase.Size = new System.Drawing.Size(56, 13);
			this.lblDatabase.TabIndex = 10;
			this.lblDatabase.Text = "Database:";
			// 
			// txtUID
			// 
			this.txtUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUID.Location = new System.Drawing.Point(131, 80);
			this.txtUID.Name = "txtUID";
			this.txtUID.Size = new System.Drawing.Size(245, 20);
			this.txtUID.TabIndex = 3;
			// 
			// lblUID
			// 
			this.lblUID.AutoSize = true;
			this.lblUID.Location = new System.Drawing.Point(14, 79);
			this.lblUID.Name = "lblUID";
			this.lblUID.Size = new System.Drawing.Size(63, 13);
			this.lblUID.TabIndex = 11;
			this.lblUID.Text = "User Name:";
			// 
			// txtDatabase
			// 
			this.txtDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDatabase.Location = new System.Drawing.Point(131, 54);
			this.txtDatabase.Name = "txtDatabase";
			this.txtDatabase.Size = new System.Drawing.Size(245, 20);
			this.txtDatabase.TabIndex = 2;
			// 
			// lblPWD
			// 
			this.lblPWD.AutoSize = true;
			this.lblPWD.Location = new System.Drawing.Point(14, 109);
			this.lblPWD.Name = "lblPWD";
			this.lblPWD.Size = new System.Drawing.Size(56, 13);
			this.lblPWD.TabIndex = 12;
			this.lblPWD.Text = "Password:";
			// 
			// txtServer
			// 
			this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtServer.Location = new System.Drawing.Point(131, 29);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(245, 20);
			this.txtServer.TabIndex = 1;
			// 
			// DatabaseConnectionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.grpConnectionString);
			this.Controls.Add(this.grpProperties);
			this.Name = "DatabaseConnectionControl";
			this.Size = new System.Drawing.Size(405, 238);
			this.grpConnectionString.ResumeLayout(false);
			this.grpConnectionString.PerformLayout();
			this.grpProperties.ResumeLayout(false);
			this.grpProperties.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpConnectionString;
		private System.Windows.Forms.Label lblConnectionString;
		private System.Windows.Forms.TextBox txtConnectionString;
		private System.Windows.Forms.RadioButton opt2;
		private System.Windows.Forms.GroupBox grpProperties;
		private System.Windows.Forms.CheckBox chkWinAuth;
		private System.Windows.Forms.Label lblServer;
		private System.Windows.Forms.TextBox txtPWD;
		private System.Windows.Forms.RadioButton opt1;
		private System.Windows.Forms.Label lblDatabase;
		private System.Windows.Forms.TextBox txtUID;
		private System.Windows.Forms.Label lblUID;
		private System.Windows.Forms.TextBox txtDatabase;
		private System.Windows.Forms.Label lblPWD;
		private System.Windows.Forms.TextBox txtServer;
	}
}
