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
using nHydrate.Dsl;

namespace nHydrate.DslPackage.Forms
{
	public partial class RelationshipViewDialog : Form
	{
		public RelationshipViewDialog()
		{
			InitializeComponent();

			lvwColumns.Columns.Clear();
			lvwColumns.Columns.Add(string.Empty, lblSecondaryTable.Width, HorizontalAlignment.Left);
			lvwColumns.Columns.Add(string.Empty, lblSecondaryTable.Width, HorizontalAlignment.Left);
			cboChildTable.Location = lblSecondaryTable.Location;
			pnlCover.Location = new Point(16, 133);
			cboChildTable.SelectedValueChanged += new EventHandler(cboChildTable_SelectedValueChanged);
		}

		private EntityHasViews _connector = null;
		private nHydrateModel _model = null;
		private Microsoft.VisualStudio.Modeling.Store _store = null;
		private bool _allowConfigure = false;

		public RelationshipViewDialog(nHydrateModel model, Microsoft.VisualStudio.Modeling.Store store, EntityHasViews connector)
			: this(model, store, connector, false)
		{
		}

		public RelationshipViewDialog(nHydrateModel model, Microsoft.VisualStudio.Modeling.Store store, EntityHasViews connector, bool allowConfigure)
			: this()
		{
			try
			{
				_connector = connector;
				_model = model;
				_store = store;
				_allowConfigure = allowConfigure;

				//Load the Form
				var parent = connector.ParentEntity;
				lblPrimaryTable.Text = parent.Name;
				
				if (!allowConfigure)
					lblSecondaryTable.Text = connector.ChildView.Name;

				LoadRelation();

				if (_allowConfigure)
				{
					cboChildTable.Items.Clear();
					foreach (var entity in _model.Entities.OrderBy(x => x.Name))
					{
						cboChildTable.Items.Add(entity.Name);
					}

					lblSecondaryTable.Visible = false;
					cboChildTable.Visible = true;
				}

			}
			catch (Exception ex)
			{
				throw;
			}
		}

		#region Child Control Event Handlers

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			if (this.lvwColumns.Items.Count == 0)
			{
				MessageBox.Show("You must specify at least one set of key mappings.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var parent = _connector.ParentEntity;
			var child = _connector.ChildView;
			if (_allowConfigure)
			{
				child = _model.Views.FirstOrDefault(x => x.Name == (string)cboChildTable.SelectedItem);
			}

			var relationId = Guid.Empty;
			relationId = _connector.Id;

			//Verify that they did not link the same two columns more than once
			var checkList = new List<string>();
			foreach (ListViewItem item in this.lvwColumns.Items)
			{
				var parentField = parent.Fields.FirstOrDefault(x => x.Name == item.SubItems[0].Text);
				var childField = child.Fields.FirstOrDefault(x => x.Name == item.SubItems[1].Text);
				var key = parentField.Id + "|" + childField.Id;
				if (checkList.Contains(key))
				{
					MessageBox.Show("You may not link on the same parent and child columns in the relation more than once.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				else
				{
					checkList.Add(key);
				}
			}

			//Actual make the change to the model
			using (var transaction = _store.TransactionManager.BeginTransaction(Guid.NewGuid().ToString()))
			{
				//Save
				_connector.RoleName = txtRole.Text;

				if (_allowConfigure)
				{
					_connector.ChildView = child;
				}

				////Remove all fields
				//var fieldList = _model.RelationFields.Where(x => x.RelationID == relationId).ToList();
				//foreach (var columnSet in fieldList)
				//{
				//  _model.RelationFields.Remove(columnSet);
				//}
				_model.RelationFields.RemoveAll(_model.RelationFields.Where(x => x.RelationID == relationId).ToList());

				foreach (ListViewItem item in this.lvwColumns.Items)
				{
					var parentField = parent.Fields.FirstOrDefault(x => x.Name == item.SubItems[0].Text);
					var childField = child.Fields.FirstOrDefault(x => x.Name == item.SubItems[1].Text);
					_model.RelationFields.Add(
						new RelationField(_model.Partition)
						{
							SourceFieldId = parentField.Id,
							TargetFieldId = childField.Id,
							RelationID = relationId,
						}
						);
				}

				transaction.Commit();
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			if ((!string.IsNullOrEmpty(cboParentField.Text)) && (!string.IsNullOrEmpty(cboChildField.Text)))
			{
				this.AddColumnMap(cboParentField.Text, cboChildField.Text);
			}
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			if (this.lvwColumns.SelectedItems.Count > 0)
			{
				for (var ii = this.lvwColumns.SelectedItems.Count - 1; ii >= 0; ii--)
				{
					this.lvwColumns.Items.Remove(this.lvwColumns.SelectedItems[ii]);
				}
			}
		}

		private void cboChildField_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.EnableButtons();
		}

		private void cboParentField_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Default the child box to the same field name if not set and if exists
			if ((cboParentField.SelectedIndex != -1) && (cboChildField.SelectedIndex == -1))
			{
				foreach (string s in cboChildField.Items)
				{
					if (s.ToLower() == cboParentField.SelectedItem.ToString().ToLower())
						cboChildField.SelectedItem = s;
				}
			}

			this.EnableButtons();
		}

		private void lvwColumns_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.EnableButtons();
		}

		#endregion

		#region Methods

		private void LoadTables(ComboBox cboEntity)
		{
			cboEntity.Items.Clear();
			foreach (var entity in _model.Entities.OrderBy(x => x.Name))
			{
				cboEntity.Items.Add(entity.Name);
			}
		}

		private void LoadFields(string tableName, ComboBox cboField)
		{
			cboField.Items.Clear();
			var entity = _model.Entities.FirstOrDefault(x => x.Name == tableName);
			if (entity != null)
			{
				foreach (var field in entity.Fields)
				{
					cboField.Items.Add(field.Name);
				}
			}
			cboField.Enabled = (cboField.Items.Count > 0);
		}

		private void LoadViewFields(string viewName, ComboBox cboField)
		{
			cboField.Items.Clear();
			var entity = _model.Views.FirstOrDefault(x => x.Name == viewName);
			if (entity != null)
			{
				foreach (var field in entity.Fields)
				{
					cboField.Items.Add(field.Name);
				}
			}
			cboField.Enabled = (cboField.Items.Count > 0);
		}

		private void AddColumnMap(string field1, string field2)
		{
			var newItem = new ListViewItem();
			newItem.Text = field1;
			newItem.SubItems.Add(field2);
			this.lvwColumns.Items.Add(newItem);
		}

		private void EnableButtons()
		{
			cmdAdd.Enabled = ((!string.IsNullOrEmpty(cboParentField.Text)) && (!string.IsNullOrEmpty(cboChildField.Text)));
			cmdDelete.Enabled = (this.lvwColumns.SelectedItems.Count > 0);
		}

		private void LoadRelation()
		{
			var parent = _connector.ParentEntity;
			var child = _model.Views.FirstOrDefault(x => x.Name == lblSecondaryTable.Text);

			this.LoadFields(lblPrimaryTable.Text, cboParentField);
			this.LoadViewFields(lblSecondaryTable.Text, cboChildField);

			//Load fields that are set
			var relationId = Guid.Empty;
			relationId = _connector.Id;

			var relation = _model.AllRelations.FirstOrDefault(x => x.Id == relationId);
			var fieldList = _model.RelationFields.Where(x => x.RelationID == relationId);
			foreach (var columnSet in fieldList)
			{
				var field1 = parent.Fields.FirstOrDefault(x => x.Id == columnSet.SourceFieldId);
				ViewField field2 = null;
				if (child != null)
					field2 = child.Fields.FirstOrDefault(x => x.Id == columnSet.TargetFieldId);

				if (field1 != null && field2 != null)
				{
					this.AddColumnMap(field1.Name, field2.Name);
					foreach (string s in cboParentField.Items)
					{
						if (s == field1.Name) cboParentField.SelectedItem = s;
					}

					foreach (string s in cboChildField.Items)
					{
						if (s == field2.Name) cboChildField.SelectedItem = s;
					}
				}
			}

			//New relation, nothing selected, so default to PK
			if (cboParentField.SelectedIndex == -1)
			{
				var pk = parent.PrimaryKeyFields.FirstOrDefault();
				if (pk != null)
				{
					cboParentField.SelectedItem = pk.Name;
				}
			}

			txtRole.Text = _connector.RoleName;
		}

		private void cboChildTable_SelectedValueChanged(object sender, EventArgs e)
		{
			this.lvwColumns.Items.Clear();
			lblSecondaryTable.Text = (string)cboChildTable.SelectedItem;
			this.LoadRelation();
		}

		#endregion

	}
}
