using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc.Core.UI;

namespace OSIS.PEPPAM.Mvc.UI
{
    public class Action : IAction
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string CssClass { get; set; }
        public string Help { get; set; }
        public IFuncionality Funcionality { get; set; }
        public IAction GetAction(string code)
        {
            throw new NotImplementedException();
        }

        public IAction GetAction(string codeFuncionality, string code)
        {
            throw new NotImplementedException();
        }
    }
}