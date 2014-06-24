using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSIS.PEPPAM.Mvc.Extensions.Controllers;
using OSIS.PEPPAM.Mvc.Models;
using OSIS.PEPPAM.Mvc.UI;

namespace OSIS.PEPPAM.Mvc.Views
{
    public class ExperienciasController : BaseController
    {
        //
        // GET: /Experiencias/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add()
        {
            return RedirectToAction("Create");
        }


        public virtual ActionResult Create()
        {
            var experienciasMaster = new Experiencias_MasterModel();
            ViewBag.IsNew = true;
            experienciasMaster.Registro_Estado = "A";
            experienciasMaster.Registro_Usuario = User.Identity.Name;
            experienciasMaster.TurnosPasados = Personas_MasterModel.TurnosPasados(User.UsuarioNumero);

            

            return View(experienciasMaster);
        }

        //
        // POST: /Usuarios/Create
        [HttpPost]
        public virtual ActionResult Create(Experiencias_MasterModel experienciasMaster)
        {
            if (ModelState.IsValid)
            {

                //Campos Auditorias
                experienciasMaster.Registro_Fecha = DateTime.Now;
                experienciasMaster.Registro_Usuario = User.Identity.Name;

                var result = experienciasMaster.Save();

                if (result)
                {


                  //  ShowMessages(MessagesType.Success, Messages.GetOrSetMensaje("MENSAJE_EXPERIENCIAS_ENVIADA"));


                    return RedirectToAction("ExperienciaEnviada");
                }

            }

            experienciasMaster.TurnosPasados = Personas_MasterModel.TurnosPasados(User.UsuarioNumero);
            ViewBag.IsNew = true;
            return View(experienciasMaster);

        }

        public ActionResult ExperienciaEnviada()
        {
            return View();
        }




    }
}