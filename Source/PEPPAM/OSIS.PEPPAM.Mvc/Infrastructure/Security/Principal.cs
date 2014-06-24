using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Mvc.Core.Security;
using OSIS.PEPPAM.Mvc.Models;
using IPrincipal =  Mvc.Core.Security.IPrincipal;

namespace OSIS.PEPPAM.Mvc.Infrastructure.Security
{

    //public enum SeguridadNivel
    //{
    //    Precursor = 1,
    //    HombreClave = 2,
    //    EncargadoPuesto = 3,
    //    EncargadoZona = 4,
    //    Betel = 5
    //}


    public class Principal : IPrincipal
    {
        private string _usuarioNombreCompleto;


        public IIdentity Identity { get; private set; }
        public int UsuarioNumero { get; set; }
        public string UsuarioNombres { get; set; }
        public string UsuarioApellido { get; set; }
        public string UsuarioCorreo { get; set; }

        public int UsuarioZona { get; set; }
        public int UsuarioCongregacion { get; set; }

        public string UsuarioNombreCompleto
        {
            get { return string.Format("{0} {1}", this.UsuarioNombres, this.UsuarioApellido); }
            
        }

        public string UsuarioSexo { get; set; }

        public List<string> Roles { get; set; }
        

        public Principal(string email)
        {
            this.Identity = new GenericIdentity(email);

            Roles = new List<string>();
        }

        public bool IsInNivel(SeguridadNivel nivel)
        {
            var roles = Persona_Roles_TransModel.PageLoadByPersonasMaster(1, 100, this.UsuarioNumero);
            return roles.Any(personaRolesTransModel => personaRolesTransModel.RolesCata.Role_Nivel_Numero >= (int) nivel);
        }


        public bool IsInRole(string role)
        {
            return this.Roles.Contains(role);

            /*
             * return Identity != null && Identity.IsAuthenticated && 
		   !string.IsNullOrWhiteSpace(role) && Roles.IsUserInRole(Identity.Name, role);
             */
        }

    }
}