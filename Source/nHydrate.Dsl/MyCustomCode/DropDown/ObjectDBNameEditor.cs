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
    public class ObjectDBNameEditor : DropDownBase
    {
       
        public override void FillDropDown(ListBox dropdownlist, ITypeDescriptorContext context = null)
        {
            if (context == null) return;

            var viewShape = context.Instance as EntityShape;
            if (viewShape == null) return;

            var action = viewShape.ModelElement as Entity;
            if (action == null) return;

            foreach (var entity in action.nHydrateModel.Entities)
            {
                dropdownlist.Items.Add(new ListItem(entity.Name,
                                                    entity.Name));
            }

            foreach (var procedure in action.nHydrateModel.StoredProcedures)
            {
                dropdownlist.Items.Add(new ListItem(procedure.Name,
                                                    procedure.Name));
            }
        }
    }
}
