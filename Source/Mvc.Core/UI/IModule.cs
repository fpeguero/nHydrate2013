using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Core.UI
{
    public interface IModule
    {
        string Code { get; set; }
        
        string Name { get; set; }

        string Description { get; set; }

        string Help { get; set; }

        string Url { get; set; }

        string Icon { get; set; }

        List<IFuncionality> Funcionalities { get; set; }

        IModule GetModule(string code);
        
        IFuncionality GetFuncionality(string codeFuncionality);

        IFuncionality GetFuncionality(string codeModule, string codeFuncionality);
    }
}
