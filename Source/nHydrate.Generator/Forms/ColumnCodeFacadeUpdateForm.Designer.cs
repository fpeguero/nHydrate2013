﻿namespace nHydrate.Generator.Forms
{
	partial class ColumnCodeFacadeUpdateForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColumnCodeFacadeUpdateForm));
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.optPrefix = new System.Windows.Forms.CheckBox();
			this.pnlPrefix = new System.Windows.Forms.Panel();
			this.txtPrefix = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlProgress = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.pnlReplace = new System.Windows.Forms.Panel();
			this.txtReplaceTarget = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtReplaceSource = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkReplaceText = new System.Windows.Forms.CheckBox();
			this.chkSkip2Caps = new System.Windows.Forms.CheckBox();
			this.optUnderscore = new System.Windows.Forms.CheckBox();
			this.optUpcase = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.lblLine100 = new System.Windows.Forms.Label();
			this.pnlPrefix.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.pnlProgress.SuspendLayout();
			this.pnlReplace.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(192, 306);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 9;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOK.Location = new System.Drawing.Point(112, 306);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 23);
			this.cmdOK.TabIndex = 8;
			this.cmdOK.Text = "OK";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// optPrefix
			// 
			this.optPrefix.AutoSize = true;
			this.optPrefix.Location = new System.Drawing.Point(3, 3);
			this.optPrefix.Name = "optPrefix";
			this.optPrefix.Size = new System.Drawing.Size(95, 17);
			this.optPrefix.TabIndex = 0;
			this.optPrefix.Text = "Remove Prefix";
			this.optPrefix.UseVisualStyleBackColor = true;
			this.optPrefix.CheckedChanged += new System.EventHandler(this.optPrefix_CheckedChanged);
			// 
			// pnlPrefix
			// 
			this.pnlPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlPrefix.Controls.Add(this.txtPrefix);
			this.pnlPrefix.Controls.Add(this.label1);
			this.pnlPrefix.Location = new System.Drawing.Point(3, 26);
			this.pnlPrefix.Name = "pnlPrefix";
			this.pnlPrefix.Size = new System.Drawing.Size(249, 36);
			this.pnlPrefix.TabIndex = 6;
			// 
			// txtPrefix
			// 
			this.txtPrefix.Location = new System.Drawing.Point(59, 4);
			this.txtPrefix.Name = "txtPrefix";
			this.txtPrefix.Size = new System.Drawing.Size(112, 20);
			this.txtPrefix.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Prefix:";
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.pnlProgress);
			this.pnlMain.Controls.Add(this.pnlReplace);
			this.pnlMain.Controls.Add(this.chkReplaceText);
			this.pnlMain.Controls.Add(this.chkSkip2Caps);
			this.pnlMain.Controls.Add(this.optPrefix);
			this.pnlMain.Controls.Add(this.optUnderscore);
			this.pnlMain.Controls.Add(this.pnlPrefix);
			this.pnlMain.Controls.Add(this.optUpcase);
			this.pnlMain.Location = new System.Drawing.Point(12, 76);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(255, 224);
			this.pnlMain.TabIndex = 7;
			// 
			// pnlProgress
			// 
			this.pnlProgress.Controls.Add(this.label2);
			this.pnlProgress.Controls.Add(this.progressBar1);
			this.pnlProgress.Location = new System.Drawing.Point(401, 203);
			this.pnlProgress.Name = "pnlProgress";
			this.pnlProgress.Size = new System.Drawing.Size(314, 67);
			this.pnlProgress.TabIndex = 8;
			this.pnlProgress.Visible = false;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(3, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(308, 22);
			this.label2.TabIndex = 1;
			this.label2.Text = "Progress...";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(0, 28);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(311, 23);
			this.progressBar1.TabIndex = 0;
			// 
			// pnlReplace
			// 
			this.pnlReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlReplace.Controls.Add(this.txtReplaceTarget);
			this.pnlReplace.Controls.Add(this.label4);
			this.pnlReplace.Controls.Add(this.txtReplaceSource);
			this.pnlReplace.Controls.Add(this.label3);
			this.pnlReplace.Location = new System.Drawing.Point(3, 91);
			this.pnlReplace.Name = "pnlReplace";
			this.pnlReplace.Size = new System.Drawing.Size(249, 59);
			this.pnlReplace.TabIndex = 10;
			// 
			// txtReplaceTarget
			// 
			this.txtReplaceTarget.Location = new System.Drawing.Point(59, 30);
			this.txtReplaceTarget.Name = "txtReplaceTarget";
			this.txtReplaceTarget.Size = new System.Drawing.Size(112, 20);
			this.txtReplaceTarget.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 33);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Target:";
			// 
			// txtReplaceSource
			// 
			this.txtReplaceSource.Location = new System.Drawing.Point(59, 4);
			this.txtReplaceSource.Name = "txtReplaceSource";
			this.txtReplaceSource.Size = new System.Drawing.Size(112, 20);
			this.txtReplaceSource.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Source:";
			// 
			// chkReplaceText
			// 
			this.chkReplaceText.AutoSize = true;
			this.chkReplaceText.Location = new System.Drawing.Point(3, 68);
			this.chkReplaceText.Name = "chkReplaceText";
			this.chkReplaceText.Size = new System.Drawing.Size(90, 17);
			this.chkReplaceText.TabIndex = 2;
			this.chkReplaceText.Text = "Replace Text";
			this.chkReplaceText.UseVisualStyleBackColor = true;
			// 
			// chkSkip2Caps
			// 
			this.chkSkip2Caps.AutoSize = true;
			this.chkSkip2Caps.Checked = true;
			this.chkSkip2Caps.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSkip2Caps.Location = new System.Drawing.Point(31, 203);
			this.chkSkip2Caps.Name = "chkSkip2Caps";
			this.chkSkip2Caps.Size = new System.Drawing.Size(113, 17);
			this.chkSkip2Caps.TabIndex = 7;
			this.chkSkip2Caps.Text = "Skip 2 caps in row";
			this.chkSkip2Caps.UseVisualStyleBackColor = true;
			// 
			// optUnderscore
			// 
			this.optUnderscore.AutoSize = true;
			this.optUnderscore.Checked = true;
			this.optUnderscore.CheckState = System.Windows.Forms.CheckState.Checked;
			this.optUnderscore.Location = new System.Drawing.Point(3, 180);
			this.optUnderscore.Name = "optUnderscore";
			this.optUnderscore.Size = new System.Drawing.Size(174, 17);
			this.optUnderscore.TabIndex = 6;
			this.optUnderscore.Text = "Add underscore word seperator";
			this.optUnderscore.UseVisualStyleBackColor = true;
			this.optUnderscore.CheckedChanged += new System.EventHandler(this.optUnderscore_CheckedChanged);
			// 
			// optUpcase
			// 
			this.optUpcase.AutoSize = true;
			this.optUpcase.Checked = true;
			this.optUpcase.CheckState = System.Windows.Forms.CheckState.Checked;
			this.optUpcase.Location = new System.Drawing.Point(3, 157);
			this.optUpcase.Name = "optUpcase";
			this.optUpcase.Size = new System.Drawing.Size(110, 17);
			this.optUpcase.TabIndex = 5;
			this.optUpcase.Text = "Lower case name";
			this.optUpcase.UseVisualStyleBackColor = true;
			this.optUpcase.CheckedChanged += new System.EventHandler(this.optUpcase_CheckedChanged);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.Controls.Add(this.lblLine100);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(279, 65);
			this.panel1.TabIndex = 72;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(91, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(178, 13);
			this.label5.TabIndex = 68;
			this.label5.Text = "Change values based on rules";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(8, 8);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(48, 48);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 11;
			this.pictureBox2.TabStop = false;
			// 
			// lblLine100
			// 
			this.lblLine100.BackColor = System.Drawing.Color.DarkGray;
			this.lblLine100.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblLine100.Location = new System.Drawing.Point(0, 63);
			this.lblLine100.Name = "lblLine100";
			this.lblLine100.Size = new System.Drawing.Size(279, 2);
			this.lblLine100.TabIndex = 70;
			// 
			// ColumnCodeFacadeUpdateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(279, 340);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ColumnCodeFacadeUpdateForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Update CodeFacade";
			this.pnlPrefix.ResumeLayout(false);
			this.pnlPrefix.PerformLayout();
			this.pnlMain.ResumeLayout(false);
			this.pnlMain.PerformLayout();
			this.pnlProgress.ResumeLayout(false);
			this.pnlReplace.ResumeLayout(false);
			this.pnlReplace.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.CheckBox optPrefix;
		private System.Windows.Forms.Panel pnlPrefix;
		private System.Windows.Forms.TextBox txtPrefix;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.CheckBox optUpcase;
		private System.Windows.Forms.CheckBox optUnderscore;
		private System.Windows.Forms.CheckBox chkSkip2Caps;
		private System.Windows.Forms.Panel pnlProgress;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Panel pnlReplace;
		private System.Windows.Forms.TextBox txtReplaceTarget;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtReplaceSource;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkReplaceText;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label lblLine100;
	}
}