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
using System.Collections;
using System.Windows.Forms;
using nHydrate.Generator.Common;
using nHydrate.Generator.Common.Forms;
using nHydrate.Generator.Common.GeneratorFramework;

namespace nHydrate.Generator.Models
{
	public class ParameterCollectionController : BaseModelObjectController
	{
		#region Member Variables

		private ContextMenu PopupMenu = null;
		private ListView ControllerListView = null;

		#endregion

		#region Constructor

		protected internal ParameterCollectionController(INHydrateModelObject modelObject)
			: base(modelObject)
		{
			this.HeaderText = "Parameters";
			this.HeaderDescription = "This is a list of parameters defined for the parent object";
			this.HeaderImage = ImageHelper.GetImage(ImageConstants.Parameters);
		}

		#endregion

		#region BaseModelObjectController Members

		public override ModelObjectTreeNode Node
		{
			get
			{
				if(_node == null)
				{
					_node = new ParameterCollectionNode(this);
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
					ControllerListView.Columns.Add("Name", 100, HorizontalAlignment.Left);
					ControllerListView.Columns.Add("Allow Null", 100, HorizontalAlignment.Left);
					ControllerListView.Columns.Add("Type", 100, HorizontalAlignment.Left);
					ControllerListView.Columns.Add("Length", 50, HorizontalAlignment.Right);
					var typeList = new System.Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(int) };
					var comparer = new ListViewComparer(ControllerListView, typeList);
					ControllerListView.ListViewItemSorter = comparer;
					comparer.Column = 0;
					ControllerListView.Sorting = SortOrder.Ascending;
					ControllerListView.SmallImageList = nHydrate.Generator.ImageHelper.GetImageList();
					ctrl.MainPanel.Controls.Add(ControllerListView);
					ctrl.Dock = DockStyle.Fill;

					this.ReloadControl();

					ControllerListView.KeyUp += new KeyEventHandler(listView_KeyUp);
					ControllerListView.DoubleClick += new EventHandler(listView_DoubleClick);

					this.PopupMenu = new ContextMenu();
					ControllerListView.ContextMenu = this.PopupMenu;
					var menuDelete = new MenuItem("Delete");
					menuDelete.Click += new EventHandler(menuDelete_Click);
					this.PopupMenu.MenuItems.Add(menuDelete);

					this.UserInterface = ctrl;
				}
				return this.UserInterface;
			}
		}

		private void ReloadControl()
		{
			try
			{
				//Load the list
				ControllerListView.Items.Clear();
				foreach (Reference reference in (ReferenceCollection)this.Object)
				{
					var parameter = ((Parameter)reference.Object);
					var newItem = new ListViewItem(parameter.Name);
					newItem.ImageIndex = ImageHelper.GetImageIndex(TreeIconConstants.Parameter);

					newItem.Tag = reference;
					newItem.Name = reference.Key;
					newItem.SubItems.Add(parameter.AllowNull.ToString());
					newItem.SubItems.Add(parameter.DataType.ToString().ToLower());
					newItem.SubItems.Add(parameter.Length.ToString());
					ControllerListView.Items.Add(newItem);
				}

				ControllerListView.Sort();

			}
			catch (Exception ex)
			{
				throw;
			}
		}

		private void listView_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.ControllerListView.SelectedItems.Count == 1)
			{
				var item = this.ControllerListView.SelectedItems[0];
				var nodeList = this.Node.Nodes.Find(((Reference)item.Tag).Key, false);
				if(nodeList.Length > 0)
				{
					if(this.Node.TreeView != null)
						this.Node.TreeView.SelectedNode = nodeList[0];
				}
			}
		}

		private void listView_KeyUp(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Delete)
			{
				menuDelete_Click(null, null);
			}
		}

		private void menuDelete_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("Do you wish to delete the selected items?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				return;

			foreach(ListViewItem item in ControllerListView.SelectedItems)
				((ReferenceCollection)this.Object).Remove(((Reference)item.Tag));

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
			var mcAddParameter = new DefaultMenuCommand();
			mcAddParameter.Text = "New Parameter";
			mcAddParameter.Click += new EventHandler(AddParameterMenuClick);

			return new MenuCommand[] { mcAddParameter };
		}

		public override MessageCollection Verify()
		{
			try
			{
				var retval = new MessageCollection();
				retval.AddRange(base.Verify());

				//Check for duplicate names
				var nameList = new Hashtable();
				var referenceCollection = (ReferenceCollection)this.Object;
				foreach(Reference reference in referenceCollection)
				{
					var parameter = (Parameter)reference.Object;
					var name = parameter.Name.ToLower();
					if(nameList.ContainsKey(name))
						retval.Add(MessageTypeConstants.Error, string.Format(ValidationHelper.ErrorTextDuplicateName, name), parameter.Controller);
					else
						nameList.Add(name, string.Empty);
				}

				return retval;

			}
			catch(Exception ex)
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
		}

		#endregion

		#region Menu Handlers

		private void AddParameterMenuClick(object sender, System.EventArgs e)
		{
			try
			{
				var parameter = ((ModelRoot)this.Object.Root).Database.CustomRetrieveRuleParameters.Add();
				((ReferenceCollection)this.Object).Add(parameter.CreateRef());
				object o = ((ModelObjectTreeNode)this.Node.Parent).Controller.Object;
				Reference tableRef = null;
				if (o is CustomRetrieveRule)
					tableRef = ((CustomRetrieveRule)((ModelObjectTreeNode)this.Node.Parent).Controller.Object).CreateRef();
				else if(o is CustomView)
					tableRef = ((CustomView)((ModelObjectTreeNode)this.Node.Parent).Controller.Object).CreateRef();
				else if(o is CustomStoredProcedure)
					tableRef = ((CustomStoredProcedure)((ModelObjectTreeNode)this.Node.Parent).Controller.Object).CreateRef();

				parameter.ParentTableRef = tableRef;
				this.OnItemChanged(this, new System.EventArgs());
			}
			catch(Exception ex)
			{
				throw;
			}
		}

		#endregion

	}
}