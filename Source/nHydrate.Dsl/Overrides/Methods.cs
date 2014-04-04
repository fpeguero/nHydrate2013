using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nHydrate.Dsl.MyCustomCode;

namespace nHydrate.Dsl
{
    public partial class Methods 
    {

        List<MethodParameters> _listParameters = new List<MethodParameters>();

        public List<MethodParameters> GetParametrosValue()
        {
            return _listParameters;
        }

        public void SetParametrosValue(List<MethodParameters> value)
        {
            if (value != null)
                _listParameters = value;
        }
    }
}
