#region Copyright (c) 2006-2012 nHydrate.org, All Rights Reserved
//--------------------------------------------------------------------- *
//                          NHYDRATE.ORG                                *
//             Copyright (c) 2006-2012 All Rights reserved              *
//                                                                      *
//                                                                      *
//This file and its contents are protected by United States and         *
//International copyright laws.  Unauthorized reproduction and/or       *
//distribution of all or any portion of the code contained herein       *
//is strictly prohibited and will result in severe civil and criminal   *
//penalties.  Any violations of this copyright will be prosecuted       *
//to the fullest extent possible under law.                             *
//                                                                      *
//THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
//TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
//TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
//CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
//THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF THE NHYDRATE GROUP *
//                                                                      *
//UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
//PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
//SUBSTANTIALLY THE SAME, FUNCTIONALITY AS THIS PRODUCT                 *
//                                                                      *
//THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
//CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF NHYDRATE,          *
//THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO             *
//INSURE ITS CONFIDENTIALITY.                                           *
//                                                                      *
//THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
//PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
//EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
//THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
//SOURCE CODE CONTAINED HEREIN.                                         *
//                                                                      *
//THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
//--------------------------------------------------------------------- *
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using nHydrate.Generator.Common;
using nHydrate.Generator.Common.GeneratorFramework;
using nHydrate.Generator.Forms;

namespace nHydrate.Generator.Models
{
	public class TableComponentCollectionController : BaseModelObjectController
	{
		#region Member Variables

		private ContextMenu PopupMenu = null;
		private ListView ControllerListView = null;

		#endregion

		#region Constructor

		protected internal TableComponentCollectionController(INHydrateModelObject modelObject):base(modelObject)
		{
			this.HeaderText = "Components";
			this.HeaderDescription = "This is a list of components for the parent entity";
			this.HeaderImage = ImageHelper.GetImage(ImageConstants.Components);
		}

		#endregion

		#region BaseModelObjectController Members

		public override ModelObjectTreeNode Node
		{
			get
			{
				if(_node == null)
				{
					_node = new TableComponentCollectionNode(this);
				}
				return _node;
			}
		}

		public override ModelObjectUserInterface UIControl
		{
			get
			{
				if(this.UserInterface == null)
				{
					var ctrl = new PanelUIControl();
					ControllerListView = new ListView();
					ControllerListView.View = View.Details;
					ControllerListView.HideSelection = false;
					ControllerListView.FullRowSelect = true;
					ControllerListView.Dock = DockStyle.Fill;
					ControllerListView.Columns.Add("Name", 250, HorizontalAlignment.Left);
					var typeList = new System.Type[] { typeof(string), typeof(string), typeof(int) };
					var comparer = new nHydrate.Generator.Common.Forms.ListViewComparer(ControllerListView, typeList);
					ControllerListView.ListViewItemSorter = comparer;
					comparer.Column = 0;
					ControllerListView.Sorting = SortOrder.Ascending;
					ControllerListView.SmallImageList = nHydrate.Generator.ImageHelper.GetImageList();
					ctrl.MainPanel.Controls.Add(ControllerListView);
					ctrl.Dock = DockStyle.Fill;

					ControllerListView.KeyUp += new KeyEventHandler(listView_KeyUp);
					ControllerListView.DoubleClick += new EventHandler(listView_DoubleClick);

					this.PopupMenu = new ContextMenu();
					ControllerListView.ContextMenu = this.PopupMenu;
					var menuDelete = new MenuItem("Delete");
					menuDelete.Click += new EventHandler(menuDelete_Click);
					this.PopupMenu.MenuItems.Add(menuDelete);

					this.UserInterface = ctrl;
				}

				this.ReloadControl();

				return this.UserInterface;
			}
		}

		private void ReloadControl()
		{
			if (ControllerListView != null)
				ControllerListView.BeginUpdate();

			try
			{
				//Load the list
				ControllerListView.Items.Clear();
				var list = (TableComponentCollection)this.Object;
				foreach (var component in list.OrderBy(x => x.Name))
				{
					var newItem = new ListViewItem(component.Name);
					newItem.Tag = component;
					newItem.ImageIndex = ImageHelper.GetImageIndex(TreeIconConstants.Column);
					newItem.Name = component.Key;
					ControllerListView.Items.Add(newItem);
				}
			}
			catch (Exception ex)
			{
				throw;
			}
			finally
			{
				if (this.ControllerListView != null)
					this.ControllerListView.EndUpdate();
			}

		}

		private void listView_DoubleClick(object sender, System.EventArgs e)
		{
		}

		private void listView_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				menuDelete_Click(null, null);
			}
			else if ((e.KeyCode == Keys.A) && (e.Control))
			{
				this.ControllerListView.SelectAll();
			}
		}

		private void menuDelete_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Do you wish to delete the selected components?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				return;

			foreach(ListViewItem item in ControllerListView.SelectedItems)
				((TableComponentCollection)this.Object).Remove((TableComponent)item.Tag);

			//Remove the item from the listview
			for(var ii = ControllerListView.SelectedItems.Count - 1 ; ii >= 0 ; ii--)
			{
				//Remove the item from the tree
				this.Node.Nodes.Remove(this.Node.Nodes[ControllerListView.SelectedItems[ii].Name]);
				//Remove Listitem
				ControllerListView.Items.Remove(ControllerListView.SelectedItems[ii]);
			}

			this.Object.Root.Dirty = true;

		}

		public override MenuCommand[] GetMenuCommands()
		{
			var mcAddComponent = new DefaultMenuCommand();
			mcAddComponent.Text = "New Component";
			mcAddComponent.Click += new EventHandler(AddTableMenuClick);

			return new MenuCommand[] { mcAddComponent };
		}

		public override MessageCollection Verify()
		{
			try
			{
				var retval = new MessageCollection();
				retval.AddRange(base.Verify());

				var tableComponentCollection = (TableComponentCollection)this.Object;

				//Check for duplicate names
				var nameList = new Dictionary<string, TableComponent>();
				foreach (TableComponent component in tableComponentCollection)
				{
					var name = component.Name.ToLower();
					if (nameList.ContainsKey(name))
						retval.Add(MessageTypeConstants.Error, string.Format(ValidationHelper.ErrorTextDuplicateName, component.Name), component.Controller);
					else
						nameList.Add(name, component);
				}

				//Check to ensure all items have at least one column
				foreach (var component in tableComponentCollection.ToList())
				{
					if (component.Columns.Count == 0)
					{
						retval.Add(MessageTypeConstants.Error, string.Format(ValidationHelper.ErrorTextTableComponentNoColumns, component.Name), component.Controller);
					}
				}

				//Check for duplicate names with tables
				foreach (Table table in ((ModelRoot)tableComponentCollection.Root).Database.Tables)
				{
					if (nameList.ContainsKey(table.Name.ToLower()))
					{
						retval.Add(MessageTypeConstants.Error, string.Format(ValidationHelper.ErrorTextComponentTableDuplicateName, nameList[table.Name.ToLower()].Name), nameList[table.Name.ToLower()].Controller);
					}
				}

				return retval;

			}
			catch (Exception ex)
			{
				throw;
			}

		}

		public override bool DeleteObject()
		{
			return false;
		}

		public override void Refresh()
		{
			//this.UserInterface = null;
			this.ReloadControl();
			this.Node.Refresh();
		}

		#endregion

		#region Menu Handlers

		private void UpdateCodefacadeColumnMenuClick(object sender, System.EventArgs e)
		{
			var root = (ModelRoot)((TableComponentCollection)this.Object).Root;
			var F = new ColumnCodeFacadeUpdateForm(null, root, ColumnCodeFacadeUpdateForm.FieldSettingConstants.CodeFacade);
			F.ShowDialog();
		}

		private void UpdateColumnNameColumnMenuClick(object sender, System.EventArgs e)
		{
			var F = new ColumnCodeFacadeUpdateForm(null, (ModelRoot)((TableComponentCollection)this.Object).Root, ColumnCodeFacadeUpdateForm.FieldSettingConstants.Name);
			F.ShowDialog();
		}

		private void AddTableMenuClick(object sender, System.EventArgs e)
		{
			var collection = (TableComponentCollection)this.Object;
			var newItem = collection.Add(new TableComponent(collection.Root, collection.Parent));
			newItem.Name = "[NEW COMPONENT]";
			this.OnItemChanged(this, new System.EventArgs());
		}

		#endregion

	}
}