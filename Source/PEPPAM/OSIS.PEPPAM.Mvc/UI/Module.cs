using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Mvc.Core.UI;

namespace OSIS.PEPPAM.Mvc.UI
{
    public class Module : IModule
    {
        public Module()
        {
           this.Funcionalities = new List<IFuncionality>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Help { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public List<IFuncionality> Funcionalities { get; set; }
        public IModule GetModule(string code)
        {
            var module = Models.Sistemas_Modulos_MasterModel.Load(Convert.ToInt32(code));

            return new Module()
            {
                Code = module.Modulo_Numero.ToString(CultureInfo.InvariantCulture),
                Description = module.Modulo_Descripcion,
                Funcionalities = new List<IFuncionality>(),
                Help = module.Modulo_Explicacion,
                Icon = string.Empty,
                Name = module.Modulo_Descripcion,
                Url = module.Modulo_Url
            };

        }

        public IFuncionality GetFuncionality(string codeFuncionality)
        {
            throw new NotImplementedException();
        }

        public IFuncionality GetFuncionality(string codeModule, string codeFuncionality)
        {
            throw new NotImplementedException();
        }
    }
}