using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using nHydrate.Dsl.MyCustomCode;

namespace nHydrate.Dsl.Editor
{
    public class CollectionTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value == null)
                {
                    return "Count: 0";
                }
                var methodParameters = value as List<MethodParameters>;
                if (methodParameters != null)
                {
                    return "Count: " +  methodParameters.Count;
                }

                var uiField = value as List<UIField>;
                if (uiField != null)
                {
                    return "Count: " + uiField.Count;
                }
              
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
