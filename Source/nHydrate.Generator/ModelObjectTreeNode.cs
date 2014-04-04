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
using System.Collections;
using System.Windows.Forms;

namespace nHydrate.Generator.Common.GeneratorFramework
{
	public abstract class ModelObjectTreeNode : TreeNode
	{

		public abstract void Refresh();
		protected INHydrateModelObjectController _controller = null;

		public INHydrateModelObjectController Controller
		{
			get { return _controller; }
		}

		#region Constructor

		public ModelObjectTreeNode(INHydrateModelObjectController controller)
		{      
			_controller = controller;
			_controller.ItemChanged += new ItemChanagedEventHandler(ControllerItemChanged);
			_object = _controller.Object;
			this.Refresh();
		}

		private void ControllerItemChanged(object sender, System.EventArgs e)
		{
			this.Object.Dirty = true;
			this.Refresh();
		}

		#endregion

		#region Object

		protected INHydrateModelObject _object = null;
		public virtual INHydrateModelObject Object
		{
			get { return _object; }
		}

		#endregion

		#region RefreshDeep

		public void RefreshDeep()
		{
			this.RefreshDeep(this);
		}

		private void RefreshDeep(ModelObjectTreeNode node)
		{
			try
			{
				if (node == null)
					return;

				node.Refresh();
				foreach (ModelObjectTreeNode child in node.Nodes)
				{
					this.RefreshDeep(child);
					if (DateTime.Now.Millisecond % 6 == 0)
						System.Windows.Forms.Application.DoEvents();
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		#endregion

		#region Sort

		public void Sort()
		{
			try
			{
				//Sort Nodes
				TreeNode selNode = null;
				if (this.TreeView != null) 
					selNode = this.TreeView.SelectedNode;

				var sortedList = new SortedList();
				foreach (TreeNode node in this.Nodes)
				{
					//Ensure key is unique to avoid error
					var text = node.Text.ToLower();
					var key = text;
					var ii = 0;
					while (sortedList.ContainsKey(key))
					{
						key = text + ii.ToString();
						ii++;
					}
					sortedList.Add(key, node);
				}

				//Cache a sorted node list
				var nodeList = new TreeNode[this.Nodes.Count];
				var index = 0;
				foreach (DictionaryEntry di in sortedList)
				{
					nodeList[index] = (TreeNode)di.Value;
					index++;
				}

				//Loop through the current nodes and determine if the sorted list matches
				var needUpdate = false;        
				for(var ii=0;ii<nodeList.Length;ii++)
				{
					if (!Util.StringHelper.Match(this.Nodes[ii].Text, nodeList[ii].Text, true))
						needUpdate = true;
				}

				//If the nodes list was in the same order as the 
				//new sortedlist then there is no need to reorder
				if (needUpdate)
				{
					//Clear nodes
					this.Nodes.Clear();

					//Re-add them in order
					if (this.TreeView != null)
						this.TreeView.BeginUpdate();

					foreach (DictionaryEntry di in sortedList)
						this.Nodes.Add((TreeNode)di.Value);

					if (this.TreeView != null)
						this.TreeView.EndUpdate();

					//Reselect previously selected node
					if (this.TreeView != null)
						this.TreeView.SelectedNode = selNode;
				}

			}
			catch (Exception ex)
			{        
				throw;
			}
		}

		#endregion

	}
}

