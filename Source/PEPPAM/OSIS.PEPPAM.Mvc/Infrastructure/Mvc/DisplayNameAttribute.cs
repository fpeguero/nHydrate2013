using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OSIS.PEPPAM.Mvc.UI;

namespace OSIS.PEPPAM.Mvc.Infrastructure.Mvc
{
    public class DisplayNameAttribute : System.ComponentModel.DisplayNameAttribute
    {
        private readonly string _parent;
        private readonly string _son;

        public DisplayNameAttribute(string parent, string son)
        {
            _parent = parent;
            _son = son;
        }

        private string _displayName = string.Empty;
        public override string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(_displayName))
                {
                    _displayName = Funcionality.GetDescription(_parent, _son,true);
                }
                return _displayName;
            }
        }


    }
}