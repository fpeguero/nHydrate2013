using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Core.Security;
using OSIS.PEPPAM.Mvc.Extensions.Controllers;
using OSIS.PEPPAM.Mvc.Models;

namespace OSIS.PEPPAM.Mvc.Controllers
{
    public class ReportesController : BaseController
    {
        //
        // GET: /Reportes/
        public ActionResult Index()
        {

            var congregacion = Personas_MasterModel.Load(User.UsuarioNumero);

            var zona = congregacion.Congregacion.Zona_Secuencia;

            
            return RedirectToAction("General", new { zona = zona });
        }

        //[HttpPost]
        public ActionResult General(int? zona, string fechas)
        {

            DateTime date1 = DateTime.MinValue;
            DateTime date2 = DateTime.MaxValue;

            if (!string.IsNullOrEmpty(fechas))
            {
                var arrayFechas = fechas.Split(Convert.ToChar("-"));
                DateTime.TryParse(arrayFechas[0], out date1);

                DateTime.TryParse(arrayFechas[1], out date2);
            }


            var model = Proc_Reporte_GeneralModel.Load(0, (date1 > DateTime.MinValue ? date1 : (DateTime?)null), (date2 < DateTime.MaxValue ? date2 : (DateTime?)null), zona);


            return View(model);
        }

        public ActionResult Detalles(int? zona, string fechas, int publicacion = -99, int idioma = -99)
        {
            if (!zona.HasValue)
            {
                var congregacion = Personas_MasterModel.Load(User.UsuarioNumero);

                 zona = congregacion.Congregacion.Zona_Secuencia;
            }

            //Proc_Reporte_Publicaciones_Idioma
            DateTime date1 = DateTime.MinValue;
            DateTime date2 = DateTime.MaxValue;

            if (!string.IsNullOrEmpty(fechas))
            {
                var arrayFechas = fechas.Split(Convert.ToChar("-"));
                DateTime.TryParse(arrayFechas[0], out date1);

                DateTime.TryParse(arrayFechas[1], out date2);
            }

            var model = Proc_Reporte_Publicaciones_IdiomaModel.Load(idioma,publicacion,-99, (date1 > DateTime.MinValue ? date1 : (DateTime?)null), (date2 < DateTime.MaxValue ? date2 : (DateTime?)null), zona);


            return View(model);
        }

       

	}
}