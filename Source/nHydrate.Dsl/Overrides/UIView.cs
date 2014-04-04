using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nHydrate.Dsl.MyCustomCode;

namespace nHydrate.Dsl
{
    partial class UIView
    {
        List<UIField> _listParameters = new List<UIField>();

        public List<UIField> GetFieldsValue()
        {
            return _listParameters;
        }

        public void SetFieldsValue(List<UIField> value)
        {
            if (value != null)
                _listParameters = value;
        }
    }
}
