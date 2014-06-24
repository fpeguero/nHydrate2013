using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFluent.Runtime;
using OSIS.PEPPAM.Mvc.Extensions.Controllers;
using OSIS.PEPPAM.Mvc.Models;
using OSIS.PEPPAM.Mvc.Models.Shared;
using OSIS.PEPPAM.Mvc.UI;

namespace OSIS.PEPPAM.Mvc.Controllers
{
    [Authorize]
    public class MiPeppamController : BaseController
    {
        //
        // GET: /MiPeppam/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Personales()
        {

            var midatos = Personas_MasterModel.Load(User.UsuarioNumero);

            return View(midatos);

        }

        [HttpPost]
        public ActionResult Personales(Personas_MasterModel model)
        {
            if (ModelState.IsValid)
            {
               

                model.Registro_Fecha = DateTime.Now;
                model.Registro_Usuario = User.Identity.Name;
                model.Save();

                ShowMessages(MessagesType.Success, Messages.GetOrSetMensaje("MENSAJE_DATOS_PERSONALES_ACTUALIZADOS"));

            }

            return View(model);

        }

        public virtual ActionResult LoadContactoInformaciones(GridRequestViewModel gridRequest, int persona_Secuencia)
        {
            var contacto_Informaciones = Personas_MasterModel.LoadByEntityKey(persona_Secuencia.ToString());

            int count = contacto_Informaciones.ContactoInformaciones.Count;

            var dateFormat =  "dd/MM/yyyy";
            System.Globalization.DateTimeFormatInfo dtfi = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
            dtfi.DateSeparator = "/";

            return Json(new
            {
                iTotalDisplayRecords = count,
                iTotalRecords = count,
                sEcho = gridRequest.GridCustomData,
                aaData = contacto_Informaciones.ContactoInformaciones.Skip(gridRequest.RowStartIndex)
                                .Take(gridRequest.RowCount)
                                .Select(d => new
                                {
                                    d.EntityKey,
                                    d.Persona_Contacto_Informacion,
                                    d.Persona_Contacto_Nota,
                                    d.Registro_Estado,
                                    Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),
                                    d.Registro_Usuario,
                                    Persona_Secuencia = d.Persona != null ? d.Persona.EntityDisplayName : string.Empty,
                                    Contacto_Tipo_Secuencia = d.ContactoTipo != null ? d.ContactoTipo.EntityDisplayName : string.Empty
                                })
            });

        }

        public virtual ActionResult AddContactoInformaciones(int personaSecuencia)
        {
            var personasMaster = Personas_MasterModel.LoadByEntityKey(personaSecuencia.ToString());

            var contactoInformaciones = new Persona_Contactos_TransModel();

            contactoInformaciones.Persona_Secuencia = personasMaster.Persona_Secuencia;

            ViewBag.MasterProperty = "Personas_Master_Contacto_Informaciones";

            //relations

            ViewBag.Name = "AddPersona_Contactos_Trans";
            ViewBag.IsNew = true;
            contactoInformaciones.Registro_Estado = "A";

            return PartialView("_AddDatosContacto", contactoInformaciones);
        }


        [HttpPost]
        public virtual ActionResult AddContactoInformaciones(Persona_Contactos_TransModel contactoInformaciones)
        {
            if (ModelState.IsValid)
            {

                //Campos Auditorias
                contactoInformaciones.Registro_Fecha = DateTime.Now;
                contactoInformaciones.Registro_Usuario = User.Identity.Name;

                contactoInformaciones.Save();

                return new HttpStatusCodeResult(200);
            }
            return PartialView("_AddDatosContacto", contactoInformaciones);
            // return new HttpStatusCodeResult(500);
        }








        public ActionResult MisExperiencias()
        {
            
            return View("Experiencias");

        }


        [HttpPost]
        public virtual ActionResult LoadExperiencias(GridRequestViewModel gridRequest)
        {
            OrderByArgumentCollection orderByArguments = new OrderByArgumentCollection();
            orderByArguments.Add("[" + gridRequest.SortColumnName + "]", gridRequest.SortDirection);

            PageOptions pageOptions = new PageOptions();
            pageOptions.OrderByArguments = orderByArguments;

            var totalCount = 0;

            var allexperienciasMaster = Experiencias_MasterModel.PageLoadAllPagingPersona(1 + gridRequest.RowStartIndex / gridRequest.RowCount,
                gridRequest.RowCount, gridRequest.Search, pageOptions,User.UsuarioNumero, out totalCount);

            var displayRecords = allexperienciasMaster.Count;
            var totalRecords = totalCount;

            var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en"
                ? "MM/dd/yyyy"
                : "dd/MM/yyyy";
            System.Globalization.DateTimeFormatInfo dtfi =
                System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
            dtfi.DateSeparator = "/";

            return Json(new
            {
                iTotalDisplayRecords = totalRecords,
                iTotalRecords = totalRecords,
                sEcho = gridRequest.GridCustomData,
                aaData =
                    allexperienciasMaster.Select(
                        d =>
                            new
                            {
                                d.Experiencia_Secuencia,
                                d.Experiencia_Contenido,
                                d.Registro_Estado,
                                Registro_Fecha = d.Registro_Fecha.ToString(dateFormat, dtfi),
                                d.Registro_Usuario,
                                Persona_Secuencia = d.PersonasTurnosTrans != null ? d.PersonasTurnosTrans.EntityDisplayName : string.Empty
                            })
            });

        }

        public ActionResult LoadDisponibilidad()
        {

            var model = new DisponibilidadModel {Dias = Dias_CataModel.LoadAll()};

            var selected = Personas_DiponibilidadModel.Loadpersona(User.UsuarioNumero);

            foreach (Dias_CataModel diasCataModel in model.Dias)
                foreach (Horas_CataModel horasCataModel in diasCataModel.HorasDiponibilidad)
                {
                    if (selected.Any(x => x.Hora_Secuencia == horasCataModel.Hora_Secuencia && x.Dia_Secuencia == diasCataModel.Dia_Secuencia)) 
                        horasCataModel.IsSelected = true;
                }


            return View("Disponibilidad", model);
        }

        public ActionResult SaveDisponibilidad(DisponibilidadModel model)
        {

            Personas_DiponibilidadModel.Deletepersona(User.UsuarioNumero);


            foreach (Dias_CataModel diasCataModel in model.Dias)
                foreach (Horas_CataModel horasCataModel in diasCataModel.HorasDiponibilidad)
                {
                    if (horasCataModel.IsSelected)
                    {
                        var diponibilidad = new Personas_DiponibilidadModel()
                        {
                            Persona_Secuencia = User.UsuarioNumero, Dia_Secuencia = diasCataModel.Dia_Secuencia, Hora_Secuencia = horasCataModel.Hora_Secuencia, Registro_Estado = "A", Registro_Fecha = DateTime.Now, Registro_Usuario = User.Identity.Name
                        };
                        diponibilidad.Save();
                    }
                }

            ShowMessages(MessagesType.Success, Messages.GetOrSetMensaje("MENSAJE_DISPONIBILIDAD_ACTUALIZADAS"));

            return RedirectToAction("LoadDisponibilidad");
        }



        /*
         * TODO: Mejoras, impletar un paging
         */
        public ActionResult MisInformes()
        {
            var model = Personas_MasterModel.MisInformes(-999, User.UsuarioNumero);

            return View("Informes", model);

        }

        public ActionResult MisHistorialParticipacion()
        {
            var model = Personas_MasterModel.MisParticiapciones(User.UsuarioNumero);

            return View("Participaciones", model);

        }



        /*
         * TODO: Mejoras, impletar un paging
         */

        [HttpPost]
        public ActionResult MisHistorialParticipacionGrid()
        {
            var model = Personas_MasterModel.MisParticiapciones(User.UsuarioNumero);

            var displayRecords = model.Count;
            var totalRecords = displayRecords;

            var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en"
                ? "MM/dd/yyyy"
                : "dd/MM/yyyy";
            System.Globalization.DateTimeFormatInfo dtfi =
                System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
            dtfi.DateSeparator = "/";

            return Json(new
            {
                iTotalDisplayRecords = displayRecords,
                iTotalRecords = totalRecords,
                aaData =
                    model.Select(
                        d =>
                            new
                            {
                                d.Persona_Secuencia,
                                d.Horario_Turno_Secuencia,
                                d.Dia_Secuencia,
                                d.Persona_Turno_Hc,
                                d.Registro_Fecha,
                                Turno_Fecha = d.Turno_Fecha.Value.ToString("D"),
                                d.Horario_Secuencia,
                                Turno_Descripcion = d.Turno_Descripcion + "(" + d.Turno_Hora_Desde + " - " + d.Turno_Hora_Hasta + ")",
                                d.Turno_Hora_Desde,
                                d.Turno_Hora_Hasta,
                                d.Turno_Minutos_Cantidad,
                                d.Turno_Cantidad_Publicadores,
                                d.Ruta_Secuencia,
                                Horario_Fecha_Desde  = d.Horario_Fecha_Desde.Value.ToString("d") + " - " + d.Horario_Fecha_Hasta.Value.ToString("d"),
                                d.Horario_Fecha_Hasta,
                                d.Ruta_Descripcion
                            })
            });

        }

        public ActionResult MisNotificaciones()
        {
            var model = Personas_MasterModel.MisNotifaciones(User.UsuarioNumero);
            return View("Notificaciones", model);
        }


        //[HttpPost]
        //public ActionResult MisNotificacionesGrid()
        //{
        //    var model = Personas_MasterModel.MisNotifaciones(User.UsuarioNumero);

        //    var displayRecords = model.Count;
        //    var totalRecords = displayRecords;

        //    var dateFormat = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en"
        //        ? "MM/dd/yyyy"
        //        : "dd/MM/yyyy";
        //    System.Globalization.DateTimeFormatInfo dtfi =
        //        System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
        //    dtfi.DateSeparator = "/";

        //    return Json(new
        //    {
        //        iTotalDisplayRecords = displayRecords,
        //        iTotalRecords = totalRecords,
        //        aaData =
        //            model.Select(
        //                d =>
        //                    new
        //                    {
        //                        d.Persona_Secuencia,
        //                        d.Notificacion_Numero,
        //                        d.Notificacion_Vista,
        //                        d.Notificacion_Vista_Fecha,
        //                        d.Registro_Estado,
        //                        d.Registro_Fecha,
        //                        d.Registro_Usuario,
        //                        d.Prioridad_Numero,
        //                        d.Notificacion_Descripcion,
        //                        d.Notificacion_Mensaje,
        //                        d.Prioridad_Descripcion,
        //                        d.Prioridad_Color,
        //                    })
        //    });

        //}

    }
}