using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml;
using ListBox = System.Windows.Forms.ListBox;
using TreeNode = System.Windows.Forms.TreeNode;

namespace nHydrate.Dsl.Editor
{
    public class ControllerActionEditor : DropDownBase
    {
        

        public override void FillDropDown(ListBox dropdownlist, ITypeDescriptorContext context = null)
        {
            if (context == null) return;

            var viewShape = context.Instance as MVCViewShape;
            if (viewShape == null) return;


            var view = viewShape.ModelElement as MVCView;
            if (view == null) return;

            if (string.IsNullOrEmpty(view.ControllerName)) return;

            var controllerModel =
                view.nHydrateModel.MVCConcept.FirstOrDefault(x => x.Name == view.ControllerName) as Controller;

            if (controllerModel == null) return;

            foreach (var action in controllerModel.ControllerMethods)
            {
                dropdownlist.Items.Add(new ListItem(action.Name,
                                                    action.Name));
            }
        }
    }
}
