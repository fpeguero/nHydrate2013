using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFluent.Runtime.Compression;
using OSIS.PEPPAM.Mvc.Extensions.Controllers;
using OSIS.PEPPAM.Mvc.Models;
using OSIS.PEPPAM.Mvc.UI;

namespace OSIS.PEPPAM.Mvc.Controllers
{
    [Authorize]
    public class ColocacionesController : BaseController
    {
        //
        // GET: /Colocaciones/
        public ActionResult Index(string keyTurnos)
        {
            return CargarColocacion(keyTurnos);
        }

         [HttpPost]
        public ActionResult CargarColocacion(string keyTurnos)
        {
           // Horario_Turno_Informe_TransModel

            var model = new ColocacionesModel();
             model.EntityKey = keyTurnos;


            var turnos = Personas_MasterModel.MisTurnosInformes(User.UsuarioNumero);


            if (turnos == null || turnos.Count <= 0)
            {
                return RedirectToAction("NoInforme");
            }
            model.Turnos = turnos;

            model.Publicaciones = Publicaciones_CataModel.LoadAll();

            //var idiomas = Idiomas_CataModel.LoadAll();
            
           
            string horario = string.Empty;
            string dia = string.Empty;

            if (!string.IsNullOrEmpty(keyTurnos))
            {
                var keysTurnos = keyTurnos.Split(Convert.ToChar("|"));
               
                 horario = keysTurnos[0];
                 dia = keysTurnos[1];
            
            }

            foreach (var publicacion in model.Publicaciones)
            {
                publicacion.Idiomas = Idiomas_CataModel.LoadAll(); 
            }

            var misInformes = Personas_MasterModel.MisInformes(-999, User.UsuarioNumero);

            if (misInformes != null && misInformes.Count > 0 && misInformes.Any(x => turnos.Any( y => y.Horario_Turno_Secuencia ==  x.Horario_Turno_Secuencia)))
            {
                if (string.IsNullOrEmpty(horario))
                {
                    //var procPersonaInformesModel = misInformes.FirstOrDefault(x => turnos.Any(y => y.Horario_Turno_Secuencia == x.Horario_Turno_Secuencia));
                    //if (
                    //    procPersonaInformesModel != null)
                    //{
                    //    if (procPersonaInformesModel.Horario_Turno_Secuencia != null)
                    //    {
                    //        model.Horario_Turno_Secuencia = procPersonaInformesModel.Horario_Turno_Secuencia.Value;
                    //        model.Dia_Secuencia = misInformes.FirstOrDefault(x => turnos.Any(y => y.dia == x.Horario_Turno_Secuencia)).Dia_Secuencia.Value;
                    //    }
                    //}
                    var turno = turnos.FirstOrDefault();
                    if (turno != null)
                    {
                        if (turno.Dia_Secuencia != null) model.Dia_Secuencia = turno.Dia_Secuencia.Value;
                        if (turno.Horario_Turno_Secuencia != null)
                            model.Horario_Turno_Secuencia = turno.Horario_Turno_Secuencia.Value;
                    }
                }
                else
                {
                    model.Horario_Turno_Secuencia = Convert.ToInt32(horario);
                    model.Dia_Secuencia = Convert.ToInt32(dia);
                }

                foreach (var publicacion in model.Publicaciones)
                {
                    foreach (var idioma in publicacion.Idiomas)
                    {
                        Idiomas_CataModel idioma1 = idioma;
                        var colocacion =
                            misInformes.FirstOrDefault(x => x.Horario_Turno_Secuencia == model.Horario_Turno_Secuencia
                                                            && x.Dia_Secuencia == model.Dia_Secuencia
                                                            && x.Publicacion_Numero == publicacion.Publicacion_Numero
                                                            &&
                                                            x.Idioma_Numero ==
                                                            idioma1.Idioma_Numero);


                        idioma.Publicacion_Idioma = publicacion.Publicacion_Numero + "|" + idioma.Idioma_Numero;
                        if (colocacion != null)
                        {
                            TempData["InformeEnviado"] = "SI";
                            if (colocacion.Publicacion_Cantidad != null)
                                idioma.Cantidad = colocacion.Publicacion_Cantidad.Value;
                        }
                        else
                        {
                            idioma.Cantidad = 0;
                        }
                    }
                }
                


            }

            return View("Colocaciones", model);

        }

        [HttpPost]
        public ActionResult AddColocacion(ColocacionesModel model)
        {
            
            Horario_Turno_Informe_TransModel.Deleteinforme(model.Horario_Turno_Secuencia, model.Dia_Secuencia);


            foreach (var publicacion in model.Publicaciones)
            {
                foreach (var idiomasCataModel in publicacion.Idiomas)
                {
                    var informe = new Horario_Turno_Informe_TransModel()
                    {
                        Horario_Turno_Secuencia = model.Horario_Turno_Secuencia,
                        Dia_Secuencia = model.Dia_Secuencia,
                        Publicacion_Numero = publicacion.Publicacion_Numero,
                        Idioma_Numero = idiomasCataModel.Idioma_Numero,
                        Publicacion_Cantidad = idiomasCataModel.Cantidad,
                        Registro_Estado = "A",
                        Registro_Fecha = DateTime.Now,
                        Registro_Usuario = User.Identity.Name,
                        Persona_Secuencia = User.UsuarioNumero
                    };

                    informe.Save();
                }
            }

            ShowMessages(MessagesType.Success, Messages.GetOrSetMensaje("MENSAJE_INFORME_ENVIADO"));


            return RedirectToAction("Index", new { keyTurnos = model.Horario_Turno_Secuencia + "|"+ model.Dia_Secuencia });
            
        }

        public ActionResult NoInforme()
        {
            return View();
        }
        /*public List<Proc_Persona_Turnos_PasadosModel> TurnosPasados { get; set; }


             public virtual string EntityKeyTurnos
             {
                 get
                 {
                     object[] keys = new object[] {
                         this.Persona_Secuencia,
                         this.Horario_Turno_Secuencia,
                         this.Dia_Secuencia
                  };
                     string v = CodeFluentPersistence.BuildEntityKey(keys);
                     return v;
                 }
                 set
                 {
                     System.Type[] types = new System.Type[] {
                         typeof(int),
                         typeof(int),
                         typeof(int)
                         };
                     object[] defaultValues = new object[] {
                         -1,
                         -1,
                         -1
                         };
                     object[] v1 = CodeFluentPersistence.ParseEntityKey(value, types, defaultValues);
                     this.Persona_Secuencia = ((int)(v1[0]));
                     this.Horario_Turno_Secuencia = ((int)(v1[1]));
                     this.Dia_Secuencia = ((int)(v1[2]));
                 }
             }
         */




    }
}