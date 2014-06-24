using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSIS.PEPPAM.Mvc.Infrastructure.Security
{
    public class PrincipalSerializeModel
    {
        public PrincipalSerializeModel()
        {
            Roles = new List<string>();
        }
        public int UsuarioNumero { get; set; }
        public string UsuarioNombres { get; set; }
        public string UsuarioApellido { get; set; }
        public string UsuarioCorreo { get; set; }

        public string UsuarioSexo { get; set; }

        public List<string> Roles { get; set; }

        public int UsuarioZona { get; set; }
        public int UsuarioCongregacion { get; set; }


        
    }
}