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
    public class AuditColumns
    {
        private string _name;
        private string _editorType;
        private string _defaultValue;

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
        [Description("Tipo de Dato")]
        [DisplayName]
        [ElementName]
        [Editor(typeof(Editor.TypeNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string DataType
        {
            get { return _editorType; }
            set { _editorType = value; }
        }


        [Category("Definition")]
        [Description("Valor predeterminado")]
        [DisplayName]
        [ElementName]
        [Editor(typeof(Editor.ParameterDefaultValueEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }
    }
}
