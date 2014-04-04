﻿#region Copyright (c) 2006-2012 nHydrate.org, All Rights Reserved
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
using System.Linq;
using System.Windows.Forms;
using nHydrate.Generator.Models;

namespace nHydrate.Generator.Forms
{
	public partial class TableCompositeColumnForm : Form
	{
		#region Class Members

		private readonly TableComposite _TableComposite = null;

		#endregion

		#region Constructors

		public TableCompositeColumnForm()
		{
			InitializeComponent();
		}

		public TableCompositeColumnForm(TableComposite TableComposite)
			: this()
		{
			_TableComposite = TableComposite;

			this.RefreshForm();
		}

		#endregion

		#region Methods

		private void RefreshForm()
		{
			var columnList = _TableComposite.Parent.GetColumnsFullHierarchy();
			foreach (var column in (from x in columnList orderby x.Name select x))
			{
				lstMembers.Items.Add(column);
			}

			foreach (Reference reference in _TableComposite.Columns)
			{
				var column = (Column)reference.Object;
				if (lstMembers.Items.Contains(column))
				{
					lstMembers.SetItemChecked(lstMembers.Items.IndexOf(column), true);
				}
			}

		}

		#endregion

		#region Event Handlers

		private void cmdOK_Click(object sender, EventArgs e)
		{
			_TableComposite.Columns.Clear();
			foreach (Column column in lstMembers.CheckedItems)
			{
				_TableComposite.Columns.Add(column.CreateRef());
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		#endregion

	}
}
