using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Core.Security
{


    public enum SeguridadNivel
    {
        Precursor = 1,
        HombreClave = 2,
        EncargadoPuesto = 3,
        EncargadoZona = 4,
        Betel = 5
    }

    public interface IPrincipal : System.Security.Principal.IPrincipal
    {

        int UsuarioNumero { get; set; }

        string UsuarioNombres { get; set; }

        string UsuarioApellido { get; set; }

        string UsuarioCorreo { get; set; }

        //Implementar esto direcctamente en TimingcoNet
        //int UsuarioLocalidadNumero { get; set; }

        //string UsuarioLocalidadNombre { get; set; }

        string UsuarioNombreCompleto { get; }

        List<string> Roles { get; set; }
        string UsuarioSexo { get; set; }

        bool IsInNivel(SeguridadNivel nivel);

    }
}
