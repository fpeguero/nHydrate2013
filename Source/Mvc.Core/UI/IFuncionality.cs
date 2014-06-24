using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Core.UI
{
    public interface IFuncionality
    {
        string Code { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        string Icon { get; set; }

        string Help { get; set; }

        string Url { get; set; }

        List<IField> Fields { get; set; }

        List<IAction> Actions { get; set; }

        IModule Module { get; set; }

        IFuncionality GetFuncionality(string codeFuncionality);

        
        IField GetField(string codeField);

        
        List<IField> GetgFields(string codeFuncionality);



        IAction GetAction(string codeAction);

        List<IAction> GetgActions(string codeFuncionality);

        IMessages GetMessages(string code);

        string GetGridColumns(string code);

        string GetGridColumnsArray(string code);

        string GetDescription(string codeParent, string codeChild);
    }
}


