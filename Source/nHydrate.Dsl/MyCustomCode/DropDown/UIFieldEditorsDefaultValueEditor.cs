using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using ListBox = System.Windows.Forms.ListBox;

namespace nHydrate.Dsl.Editor
{
    public class UIFieldEditorsDefaultValueEditor : DropDownBase
    {
        private XmlDocument xml = new XmlDocument();
        private XmlNode langNode = null;

        public override void FillDropDown(ListBox dropdownlist, ITypeDescriptorContext context = null)
        {
            this.xml.Load(ImagesList.XmlFilePath);
            langNode = this.xml.SelectSingleNode(@"//Tables/Table[@TablaNombre='Field_Control_Edit_Type']");



            foreach (XmlNode mappingpNode in langNode.ChildNodes)
            {
                dropdownlist.Items.Add(new ListItem(mappingpNode.Attributes["Nombre"].Value,
                                                    mappingpNode.Attributes["Nombre"].Value));
            }

        }
    }
}
