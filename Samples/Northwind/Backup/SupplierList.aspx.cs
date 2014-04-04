using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACME.Northwind.Business.Objects;
using Northwind.TestSite.Objects;

namespace Northwind.TestSite
{
	public partial class SupplierList : BasePage
	{
		#region Page Events

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			grdItem.RowDataBound += new GridViewRowEventHandler(grdItem_RowDataBound);
			this.PagingControl1.ObjectSingular = "Supplier";
			this.PagingControl1.ObjectPlural = "Suppliers";
			this.PagingControl1.RecordsPerPageChanged += new EventHandler(PagingControl1_RecordsPerPageChanged);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			if (!this.IsPostBack)
			{
				this.Populate();
			}
		}

		#endregion

		#region Methods

		private void Populate()
		{
			SupplierPaging paging = new SupplierPaging(this.PagingControl1.PageIndex, this.PagingControl1.RecordsPerPage, Supplier.FieldNameConstants.SupplierId, true);
			SupplierCollection productCollection = null;
			productCollection = SupplierCollection.RunSelect(x => true, paging);				
			this.PagingControl1.ItemCount = paging.RecordCount;
			grdItem.DataSource = productCollection;
			grdItem.DataBind();
			SessionHelper.LastSupplierListSearch = this.Request.Url.AbsoluteUri;
		}

		#endregion

		#region Event Handlers

		private void grdItem_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				Supplier supplier = (Supplier)e.Row.DataItem;
				HyperLink linkEdit = (HyperLink)e.Row.FindControl("linkEdit");
				HyperLink linkProduct = (HyperLink)e.Row.FindControl("linkProduct");

				linkEdit.NavigateUrl = "/SupplierItem.aspx?id=" + supplier.SupplierId;
				linkProduct.NavigateUrl = "/ProductList.aspx?supplierid=" + supplier.SupplierId;

			}
		}

		private void PagingControl1_RecordsPerPageChanged(object sender, EventArgs e)
		{
			URL query = new URL(this.Request.Url.AbsoluteUri);
			query.Parameters.SetValue("rpp", PagingControl1.RecordsPerPage.ToString());
			query.Parameters.SetValue("po", "1");
			this.Response.Redirect(query.ToString());
		}

		#endregion

	}
}
