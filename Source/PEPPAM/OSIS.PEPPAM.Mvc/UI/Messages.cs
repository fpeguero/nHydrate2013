using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using Mvc.Core.UI;
using OSIS.PEPPAM.Mvc.Models;

namespace OSIS.PEPPAM.Mvc.UI
{
    public class Messages : IMessages
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public IMessages GetMessages(string code)
        {
            throw new NotImplementedException();
        }

        string IMessages.GetOrSetMensaje(string code)
        {
            return GetOrSetMensaje(code);
        }

        //string IMessages.GetOrSetMensaje(string code)
        //{
        //    return GetOrSetMensaje(code);
        //}

        public string Mensaje(string code)
        {
            throw new NotImplementedException();
        }

        public static string GetOrSetMensaje(string code)
        {
            return GetMensaje(code, true);
        }
       public static string GetMensaje(string code, bool isNewRegisted = false)
        {
            var mensaje = Models.Sistemas_Mensaje_TransModel.Load(code);
            if (mensaje == null)
            {
                if (isNewRegisted)
                {
                    mensaje = new Sistemas_Mensaje_TransModel()
                    {
                        Mensaje_Codigo = code,
                        Mensaje_Descripcion = code.Replace("_", ""),
                        Registro_Estado = "A",
                        Registro_Fecha = DateTime.Now,
                        Registro_Usuario = "Automatico"
                    };
                    mensaje.Save();
                }
            }


            return mensaje.Mensaje_Descripcion;
        }
    }
}