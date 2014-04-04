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

using nHydrate.Generator.Common.GeneratorFramework;

namespace nHydrate.Generator.Models
{
  public class CustomViewColumnNode : ModelObjectTreeNode
  {
    #region Member Variables

    protected ModelObjectTreeNode mTableCollectionNode = null;

    #endregion

    #region Constructor

    public CustomViewColumnNode(CustomViewColumnController controller)
      : base(controller)
    {
    }

    #endregion

    #region Refresh

    public override void Refresh()
    {
      if((this.TreeView != null) && (this.TreeView.InvokeRequired))
      {
        this.TreeView.Invoke(new EmptyDelegate(this.Refresh));
        return;
      }

      var customViewCustomViewColumn = (CustomViewColumn)this.Object;
      //this.Text = this.Object.ToString();
      //this.Name = this.Object.Key;
      this.ToolTipText = customViewCustomViewColumn.Description;
      this.ImageIndex = ImageHelper.GetImageIndex(TreeIconConstants.CustomViewColumn);
      this.SelectedImageIndex = this.ImageIndex;
      this.Text = customViewCustomViewColumn.Name;
      if(this.Parent != null)
        ((CustomViewColumnCollectionController)((CustomViewColumnCollectionNode)this.Parent).Controller).Refresh();

      //Update the CustomViewColumnCollection list
      if(this.Parent != null)
        ((CustomViewColumnCollectionNode)this.Parent).Refresh();
    }

    #endregion

  }
}
