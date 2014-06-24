using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Core.UI
{
    public interface IField
    {
        string Code { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        string Icon { get; set; }

        string Help { get; set; }

        int OrdenGrid { get; set; }
        bool MostrarGrid { get; set; }

        int OrdenDetails { get; set; }
        bool MostrarDetails { get; set; }

        int OrdenEdit { get; set; }

        bool MostrarEdit { get; set; }

        IFuncionality Funcionality { get; set; }

        IField GetField(string code);

        IField GetField(string codeFuncionality, string code);

    }
}
