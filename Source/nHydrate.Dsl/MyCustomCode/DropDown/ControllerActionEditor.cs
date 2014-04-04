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
    public class ControllerNameEditor : DropDownBase
    {
        

        public override void FillDropDown(ListBox dropdownlist, ITypeDescriptorContext context = null)
        {
            if (context == null) return;

            var viewShape = context.Instance as MVCViewShape;
            if (viewShape == null) return;

            var action = viewShape.ModelElement as MVCView;
            if (action == null) return;
                

            //action.MVCViewFields.FirstOrDefault(x=> x.Name)
            //    action.MVCViewFields.FirstOrDefault().EditorType.IndexOf("for")
            

            foreach (var controller in action.nHydrateModel.MVCConcept.OfType<Controller>())
            {
                dropdownlist.Items.Add(new ListItem(controller.Name,
                                                    controller.Name));
            }
        }
    }
}
