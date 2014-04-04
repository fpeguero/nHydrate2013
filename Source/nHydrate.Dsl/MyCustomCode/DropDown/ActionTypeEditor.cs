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
    public class ActionTypeEditor : DropDownBase
    {
        private XmlDocument xml = new XmlDocument();
        private XmlNode langNode = null;

        public override void FillDropDown(ListBox dropdownlist, ITypeDescriptorContext context = null)
        {
            this.xml.Load(ImagesList.XmlFilePath);
            langNode = this.xml.SelectSingleNode(@"//Tables/Table[@TablaNombre='View_Actions_Type']");

            
            
            foreach (XmlNode mappingpNode in langNode.ChildNodes)
            {
                dropdownlist.Items.Add(new ListItem(mappingpNode.Attributes["Nombre"].Value,
                                                    mappingpNode.Attributes["Nombre"].Value));
            }

        }
    }
}
