using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Core.UI
{
    public interface IAction
    {
        string Id { get; set; }
        string Code { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        string Icon { get; set; }

        string CssClass { get; set; }

        string Help { get; set; }

        IFuncionality Funcionality { get; set; }

        IAction GetAction(string code);

        IAction GetAction(string codeFuncionality, string code);
    }
}
