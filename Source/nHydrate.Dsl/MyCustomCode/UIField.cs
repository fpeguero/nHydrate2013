using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace nHydrate.Dsl.MyCustomCode
{
    [Serializable]
    [TypeConverter(typeof(nHydrate.Dsl.Editor.CollectionTypeConverter))]
    public class UIField
    {
        private string _name;
        private string _editorType;

        [Category("Definition")]
        [Description("Nombre del Campo")]
        [DisplayName]
        [ElementName]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        [Category("Definition")]
        [Description("Tipo de Editor")]
        [DisplayName]
        [ElementName]
        [Editor(typeof(Editor.UIFieldEditorsDefaultValueEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string EditorType
        {
            get { return _editorType; }
            set { _editorType = value; }
        }
    }
}
