using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSIS.PEPPAM.Mvc.UI
{
    public class Helper
    {
        public static string GetMensaje(string code)
        {
            var mensaje = Models.Sistemas_Mensaje_TransModel.Load(code);

            return mensaje.Mensaje_Descripcion;
        }
    }
}