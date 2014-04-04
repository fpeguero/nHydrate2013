using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ListBox = System.Windows.Forms.ListBox;

namespace nHydrate.Dsl.Editor
{
    public abstract class DropDownBase : UITypeEditor
    {
        private IWindowsFormsEditorService edService;
        private ListBox dropdownlist = new ListBox();

        public DropDownBase()
        {
            dropdownlist.Click += new EventHandler(dropdownlist_Click);
        }


        public abstract void FillDropDown(ListBox dropdownlist, ITypeDescriptorContext context = null);


        /// <summary>
        /// To set the style of the UITypeEditor
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        /// <summary>
        /// Event on editing a value in he Dropdown List , to create a windows forms service which assigns the dropdownlist to the ListBox control
        /// </summary>
        /// <param name="context"></param>
        /// <param name="provider"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            dropdownlist.Items.Clear();
            //dropdownlist.Items.AddRange(dropdownList);

            FillDropDown(dropdownlist, context);



            //dropdownlist.Height =  dropdownlist.PreferredHeight;
            //Uses the IWindowsFormsEditorService to 
            //display a drop-down UI in the Properties 
            //window.
            edService = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
            if (edService != null)
            {
                edService.DropDownControl(dropdownlist);
                return dropdownlist.SelectedItem.ToString();
            }
            return value;
        }

        /// <summary>
        /// Click event of Drop down List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dropdownlist_Click(object sender, EventArgs e)
        {
            edService.CloseDropDown();
        }




       




    }


}
