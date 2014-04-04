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
	public partial class RegionList : BasePage
	{
		#region Page Events

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			grdItem.RowDataBound += new GridViewRowEventHandler(grdItem_RowDataBound);
			grdItem.RowCommand += new GridViewCommandEventHandler(grdItem_RowCommand);
			this.PagingControl1.ObjectSingular = "Region";
			this.PagingControl1.ObjectPlural = "Regions";
			this.PagingControl1.RecordsPerPageChanged += new EventHandler(PagingControl1_RecordsPerPageChanged);

			cmdAdd.Click += new EventHandler(cmdAdd_Click);
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
			RegionPaging paging = new RegionPaging(this.PagingControl1.PageIndex, this.PagingControl1.RecordsPerPage, Region.FieldNameConstants.RegionId, true);
			RegionCollection regionCollection = null;

			regionCollection = RegionCollection.RunSelect(x => true, paging);
			lblHeader.Text = "This is a list of all regions.";

			this.PagingControl1.ItemCount = paging.RecordCount;
			grdItem.DataSource = regionCollection;
			grdItem.DataBind();
			SessionHelper.LastRegionListSearch = this.Request.Url.AbsoluteUri;
		}

		#endregion

		#region Event Handlers

		private void grdItem_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				Region region = (Region)e.Row.DataItem;
				HyperLink linkEdit = (HyperLink)e.Row.FindControl("linkEdit");
				HyperLink linkTerritories = (HyperLink)e.Row.FindControl("linkTerritories");
				LinkButton linkDelete = (LinkButton)e.Row.FindControl("linkDelete");

				linkEdit.NavigateUrl = "/RegionItem.aspx?id=" + region.RegionId;
				linkTerritories.NavigateUrl = "/TerritoryList.aspx?regionid=" + region.RegionId;

				linkDelete.Attributes.Add("onclick", "return confirm('Do you wish to delete this item?');");
				linkDelete.CommandArgument = region.RegionId.ToString();
				linkDelete.CommandName = "GoDelete";

			}
		}

		private void grdItem_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "GoDelete")
			{
				int id = int.Parse((string)e.CommandArgument);
				try
				{
					RegionCollection.DeleteData(x => x.RegionId == id);
				}
				catch (Exception ex)
				{
					lblError.Text = "The item has dependencies and cannot be deleted.";
					return;
				}
				this.Populate();
			}
		}

		private void PagingControl1_RecordsPerPageChanged(object sender, EventArgs e)
		{
			URL query = new URL(this.Request.Url.AbsoluteUri);
			query.Parameters.SetValue("rpp", PagingControl1.RecordsPerPage.ToString());
			query.Parameters.SetValue("po", "1");
			this.Response.Redirect(query.ToString());
		}

		private void cmdAdd_Click(object sender, EventArgs e)
		{
			this.Response.Redirect("/RegionItem.aspx");
		}

		#endregion

	}
}