﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PROJECTNAMESPACE
{
	internal partial class HistoryForm : Form
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
			this.cmdOK = new System.Windows.Forms.Button();
			this.lstItem = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdOK.Location = new System.Drawing.Point(210, 167);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 23);
			this.cmdOK.TabIndex = 0;
			this.cmdOK.Text = "OK";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// lstItem
			// 
			this.lstItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lstItem.FormattingEnabled = true;
			this.lstItem.IntegralHeight = false;
			this.lstItem.Location = new System.Drawing.Point(12, 12);
			this.lstItem.Name = "lstItem";
			this.lstItem.Size = new System.Drawing.Size(273, 149);
			this.lstItem.TabIndex = 1;
			// 
			// HistoryForm
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.CancelButton = this.cmdOK;
			this.ClientSize = new System.Drawing.Size(297, 202);
			this.Controls.Add(this.lstItem);
			this.Controls.Add(this.cmdOK);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(313, 240);
			this.Name = "HistoryForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Database Publish History";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.ListBox lstItem;

		public HistoryForm()
		{
			InitializeComponent();
		}

		public HistoryForm(string connectionString)
			: this()
		{
			List<HistoryItem> historyList = SqlServers.GetHistory(connectionString);
			foreach (HistoryItem item in historyList.OrderByDescending(x => x.PublishDate))
			{
				lstItem.Items.Add(item.PublishDate.ToString("yyyy-MM-dd HH:mm:ss") + " / " + item.Version);
			}
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}
