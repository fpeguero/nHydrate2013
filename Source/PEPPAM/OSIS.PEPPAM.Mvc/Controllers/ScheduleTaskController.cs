using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using OSIS.PEPPAM.Mvc.Mailers;
using OSIS.PEPPAM.Mvc.UI;

namespace OSIS.PEPPAM.Mvc.Controllers
{
    public class ScheduleTaskController : Controller
    {

        private IUserMailer _userMailer = new UserMailer();
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }

        //
        // GET: /ScheduleTask/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult InformesFaltantes()
        {
            var informes = OSIS.PEPPAM.Mvc.Models.Proc_Informes_FaltantesModel.Load();

            if (informes != null && informes.Count > 0)
            {
                foreach (var informe in informes)
                {
                    ViewBag.Titulo = Messages.GetOrSetMensaje("CORREO_INFOMES_FALTANTES_TITULO");
                    ViewBag.SubTitulo =
                        Messages.GetOrSetMensaje("CORREO_INFOMES_FALTANTES_SUBTITULO")
                            .Replace("{Nombre_Completo}", "");

                    ViewBag.Cuerpo = Messages.GetOrSetMensaje("CORREO_INFOMES_FALTANTES_MENSAJE");

                    //var correo = informe.Persona_Correo;

                    //if (informe.Turno_Fecha.Value.AddDays(2) > DateTime.Now)
                    //{
                    //    correo += string.Join("", informe.Encargado_Persona_Correo);
                    //    correo += string.Join("", informe.Auxiliar_Persona_Correo);
                    //}
                    
                    //UserMailer.Correo(correo).Send();

                    Thread.Sleep(1000);
                }
            }


            return null;
        }
    }
}