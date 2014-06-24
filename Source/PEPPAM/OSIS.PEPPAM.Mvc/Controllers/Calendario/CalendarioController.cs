using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CodeFluent.Runtime.Compression;
using OSIS.PEPPAM.BOM;
using OSIS.PEPPAM.Mvc.Extensions.Controllers;
using OSIS.PEPPAM.Mvc.Models;

namespace OSIS.PEPPAM.Mvc.Controllers.Calendario
{
    public class CalendarioController : BaseController
    {
        //
        // GET: /Calendario/
        public ActionResult Index(CalendarioModel model)
        {
            return Calendario(model);
        }

        public ActionResult NoPuestoConHorarios()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calendario(CalendarioModel model)
        {

            //var dias_tran = Horario_Turno_Dias_TransModel.LoadPuestoHorarios(model.Ruta_Secuencia, model.Horario_Secuencia);


            var turnos = Horario_TransModel.LoadCalendario(model.Horario_Secuencia, model.Ruta_Secuencia);


            var rutas = Personas_MasterModel.MisPuestosConHorarios(User.UsuarioNumero);

            if (rutas == null || rutas.Count <= 0)
            {
                return RedirectToAction("NoPuestoConHorarios");
            }

            ViewBag.Rutas = rutas;

            var rutasMasterModel = rutas.FirstOrDefault();
            if (rutasMasterModel != null)
            {

                if (model.Ruta_Secuencia <= 0)
                {
                    model.Ruta_Secuencia = rutasMasterModel.Ruta_Secuencia;
                }

                ViewBag.Horarios = Horario_TransModel.LoadByruta(model.Ruta_Secuencia);

                if (model.Horario_Secuencia <= 0 && ViewBag.Horarios != null)
                {
                    var procHorariosRutaModel = ((List<Proc_Horarios_RutaModel>)ViewBag.Horarios).FirstOrDefault();
                    if (procHorariosRutaModel != null)
                        model.Horario_Secuencia = procHorariosRutaModel.Horario_Secuencia;
                }

                //if (model.Ruta_Secuencia <= 0)
                //{
                   // model.Ruta_Secuencia = rutasMasterModel.Ruta_Secuencia;

                    //dias_tran = Horario_Turno_Dias_TransModel.LoadPuestoHorarios(model.Ruta_Secuencia, model.Horario_Secuencia);
                    turnos = Horario_TransModel.LoadCalendario(model.Horario_Secuencia, model.Ruta_Secuencia);
                //}
            }

            


            var puesto = Rutas_MasterModel.Load(model.Ruta_Secuencia);

            var calendario = new CalendarioModel()
            {
                Horario_Secuencia = model.Horario_Secuencia,
                Ruta_Secuencia = model.Ruta_Secuencia,
                Turnos = turnos,
                Puesto = puesto
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("Calendario", calendario);
            }

            return View("CalendarioMain", calendario);


        }

        public ActionResult MisTurnosPendientes()
        {
            var misturnosPendientes = Personas_MasterModel.LoadMisTurnosPredicacion(User.UsuarioNumero);

            if (misturnosPendientes == null || misturnosPendientes.Count <= 0)
            {
                return RedirectToAction("NoTurnosProgramados");
            }

            return View("MisTurnosPredicacion", misturnosPendientes);
        }

        public ActionResult NoTurnosProgramados()
        {
            return View("NoTurnosProgramados");
        }

        public JsonResult LoadHorarios(int rutaSecuencia)
        {
            var horarios = Horario_TransModel.LoadByruta(rutaSecuencia);

            return Json(new SelectList(horarios, "Horario_Secuencia", "EntityDisplayName2"), JsonRequestBehavior.AllowGet);

        }

        public JsonResult LoadTurnos(int puestoSecuencia, int horarioSecuencia)
        {
            var turnosdias = Horario_Turno_Dias_TransModel.LoadPuestoHorarios(puestoSecuencia, horarioSecuencia);


            return Json(new SelectList(turnosdias, "EntityKey", "EntityDisplanName"));

        }


        public ActionResult LoadHermanosTurnos(int puesto, int turno, int dia)
        {

            var personasTurnos = Personas_Turnos_TransModel.Loadhorariodia(turno, dia);



            if (personasTurnos == null || personasTurnos.Count <= 0)
            {
                personasTurnos = new List<Personas_Turnos_TransModel>();
                personasTurnos.Add(new Personas_Turnos_TransModel()
                {
                    Horario_Turno_Secuencia = turno,
                    Dia_Secuencia = dia,
                    Ruta_Secuencia = puesto
                  //  Persona_Secuencia = 1
                });
            }
            else
            {
                foreach (var personasTurnosTransModel in personasTurnos)
                {
                    personasTurnosTransModel.Ruta_Secuencia = puesto;
                }
            }

            
          

            
            return PartialView("TurnosHermanos", personasTurnos);
        }


        [HttpPost]
        public ActionResult EditHermanosTurnos(int puesto,int turno, int dia, int horario)
        {

            var personasTurnos = Personas_Turnos_TransModel.Load(User.UsuarioNumero, turno, dia);

            

            if (personasTurnos == null)
            {
                //Asginar al Primer hombre como Hombre Clave
                var isHc = "N";
                if (User.UsuarioSexo == "M")
                {
                    var turnosAll = Personas_Turnos_TransModel.PageLoadhorariodia(1, 10, null, turno, dia);

                    if (turnosAll != null)
                    {
                        isHc = turnosAll.Any(x => x.Persona_Turno_HC == "S") ? "N" : "S";
                    }
                }


                var apuntarme = new Personas_Turnos_TransModel()
                {
                    Dia_Secuencia = dia,
                    Horario_Turno_Secuencia = turno,
                    Persona_Secuencia = User.UsuarioNumero,
                    Registro_Estado = "A",
                    Registro_Fecha = DateTime.Now,
                    Registro_Usuario = User.Identity.Name,
                    Persona_Turno_HC = isHc

                };

                apuntarme.Save();

             // return Json("Ok");
            }
            else
            {
                personasTurnos.Delete();
             // return Json("Ok");
            }

            return RedirectToAction("Index", new { Ruta_Secuencia = puesto, Horario_Secuencia = horario });
        }

    }



    public class CalendarioModel
    {


        public int Ruta_Secuencia { get; set; }

        public int Horario_Secuencia { get; set; }


        //public List<Horario_Turno_Dias_TransModel> Turnos { get; set;}

        public List<Proc_Puesto_HorariosModel> Turnos  { get; set;}


        public Rutas_MasterModel Puesto { get; set; }
    }



}