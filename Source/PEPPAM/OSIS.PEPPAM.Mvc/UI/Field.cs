using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc.Core.UI;

namespace OSIS.PEPPAM.Mvc.UI
{
    public class Field : IField
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Help { get; set; }
        public int OrdenGrid { get; set; }
        public bool MostrarGrid { get; set; }
        public int OrdenDetails { get; set; }
        public bool MostrarDetails { get; set; }
        public int OrdenEdit { get; set; }
        public bool MostrarEdit { get; set; }
        public IFuncionality Funcionality { get; set; }
        public IField GetField(string code)
        {
            throw new NotImplementedException();
        }

        public IField GetField(string codeFuncionality, string code)
        {
            throw new NotImplementedException();
        }
    }
}