using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Management;
using CodeFluent.Runtime.BinaryServices;
using FluentScheduler;
using OSIS.PEPPAM.Mvc.Mailers;
using OSIS.PEPPAM.Mvc.Models;
using OSIS.PEPPAM.Mvc.UI;

using System.Web.Hosting;
using RazorEngine;

namespace OSIS.PEPPAM.Mvc.Infrastructure.ScheduleTask
{
    public class ScheduleTask : ITask, IRegisteredObject
    {
        private readonly object _lock = new object();
		private bool _shuttingDown;

      public ScheduleTask()
		{
			// Register this task with the hosting environment. Allows for a more graceful stop of the task, in the case of IIS shutting down.
			HostingEnvironment.RegisterObject(this);
		}

		public void Execute()
		{
			lock (_lock)
			{
				if (_shuttingDown)
					return;

				// TODO: Do work, son!
			 
              InformesFaltantes();
             TurnosVaciosEncargadosPuestos();
             TurnosVaciosEncargadosZonas();
			}
		}

		public void Stop(bool immediate)
		{
			// Locking here will wait for the lock in Execute to be released until this code can continue.
			lock (_lock)
			{
				_shuttingDown = true;
			}
			HostingEnvironment.UnregisterObject(this);
		}

      private IUserMailer _userMailer = new UserMailer();
      public IUserMailer UserMailer
      {
          get { return _userMailer; }
          set { _userMailer = value; }
      }

      static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

      public static string StripTagsRegex(string source)
      {
          return Regex.Replace(source, "<.*?>", string.Empty);
      }
        public void InformesFaltantes()
        {
            
            var enviado = Proc_Correo_Enviado_HoyModel.LoadOne(1);

            if (enviado != null && enviado.Correo_Enviado_Fecha >= DateTime.Now.AddDays(-1)) return;

            var informes = OSIS.PEPPAM.Mvc.Models.Proc_Informes_FaltantesModel.Load();

            if (informes != null && informes.Count > 0)
            {
                foreach (var informe in informes)
                {
                   

                    var titulo = Sistemas_Mensaje_TransModel.Load("CORREO_INFOMES_FALTANTES_TITULO").Mensaje_Descripcion;
                    var subTitulo =
                        Messages.GetOrSetMensaje("CORREO_INFOMES_FALTANTES_SUBTITULO")
                            .Replace("{Nombre_Completo}", informe.Auxiliar_Persona_Apellidos);

                    var cuerpo = Sistemas_Mensaje_TransModel.Load("CORREO_INFOMES_FALTANTES_MENSAJE").Mensaje_Descripcion.Replace("{Datos_del_puesto}", 
                        informe.Ruta_Descripcion + " del " +
                        informe.Turno_Fecha.Value.ToString("D",new CultureInfo("es-DO")) + " en el " +
                        informe.Turno_Descripcion + " (" + informe.Turno_Hora_Desde + " - " + informe.Turno_Hora_Hasta + ")");


                    var correo = informe.Persona_Correo;
                    var cc = correo;
                    if (informe.Turno_Fecha.Value.AddDays(2) > DateTime.Now)
                    {
                        cc = string.Empty;
                        cc += informe.Encargado_Persona_Correo;
                        cc += "," + informe.Auxiliar_Persona_Correo;
                    }

                   // UserMailer.Correo(correo,cc, titulo, subTitulo, cuerpo).Send();

                    dynamic model = new ExpandoObject();

                    model.Titulo = titulo;
                    model.SubTitulo = subTitulo;
                    model.Cuerpo = cuerpo;

                    var templateLocation =
                        Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory,
                            @"Views/UserMailer/Correo1.cshtml");

                    string template = File.ReadAllText(templateLocation);
                    string emailBody = Razor.Parse(template, model);
                    string noHTML = Regex.Replace(titulo, @"<[^>]+>|&nbsp;", "").Trim().Replace("&aacute;", "á").Replace("&eacute;", "é").Replace("&iacute;", "í").Replace("&oacute;", "ó").Replace("&uacute;", "ú");

                    Common.Util.EnviarCorreo(correo,cc, StripTagsRegex(noHTML), emailBody);
                   
                   Thread.Sleep(1000);
                }

                var registrarEnvio = new Sistema_Correos_Enviado_TransModel("")
                {
                    Correo_Enviado_Fecha = DateTime.Now,
                    Correo_Enviado_Texto = "Correo Enviado",
                    Registro_Estado = "A",
                    Registro_Fecha = DateTime.Now,
                    Correos_Secuencia = 1,
                    Registro_Usuario = "Automatico",
                    
                };
                registrarEnvio.Save();
            }

        }


        public void TurnosVaciosEncargadosPuestos()
        {
            var enviado = Proc_Correo_Enviado_HoyModel.LoadOne(2);

            if (enviado != null && enviado.Correo_Enviado_Fecha > DateTime.Now.AddDays(-1)) return;

            var turnosVacios = Proc_Puestos_Horario_Turnos_Faltantes_NotificacionModel.Load(-99, -99, -99);

            if (turnosVacios != null && turnosVacios.Count > 0)
            {

                var titulo = Messages.GetOrSetMensaje("CORREO_TURNOS_VACANTES_TITULO");
             
                var cuerpo = Messages.GetOrSetMensaje("CORREO_TURNOS_VACANTES_MENSAJE");

                foreach (var turnoVacio in turnosVacios.Select(x => new {x.Ruta_Secuencia, x.Ruta_Persona_Encargado,x.Ruta_Persona_Auxiliar}).Distinct())
                {
                    var vacio = turnoVacio;
                    var turnosPuesto = turnosVacios.Where(x => x.Ruta_Secuencia == vacio.Ruta_Secuencia).ToList();
                    var encargado = Personas_MasterModel.Load(vacio.Ruta_Persona_Encargado.Value);
                    var auxiliar = Personas_MasterModel.Load(vacio.Ruta_Persona_Auxiliar.Value);
                    var correo = encargado.Persona_Correo;
                    
                    if (string.IsNullOrEmpty(encargado.Persona_Correo) && string.IsNullOrEmpty(auxiliar.Persona_Correo))
                    {
                        continue;
                    }
                    

                    if (string.IsNullOrEmpty(encargado.Persona_Correo))
                    {
                        correo = auxiliar.Persona_Correo;
                        continue;
                    }

                    var subTitulo =
                   Messages.GetOrSetMensaje("CORREO_TURNOS_VACANTES_SUBTITULO")
                       .Replace("{Nombre_Completo}", encargado.Persona_Apellidos);

                    dynamic model = new ExpandoObject();

                    model.Titulo = titulo;
                    model.SubTitulo = subTitulo;
                    model.Cuerpo = cuerpo;
                    model.Turnos = turnosPuesto.OrderBy(x => x.Turno_Fecha);

                    var templateLocation =
                        Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory,
                            @"Views/UserMailer/TurnosVacios.cshtml");

                    string template = File.ReadAllText(templateLocation);
                    string emailBody = Razor.Parse(template, model);
                    string noHTML = Regex.Replace(titulo, @"<[^>]+>|&nbsp;", "").Trim().Replace("&aacute;", "á").Replace("&eacute;", "é").Replace("&iacute;", "í").Replace("&oacute;", "ó").Replace("&uacute;", "ú");

                    Common.Util.EnviarCorreo(correo, auxiliar.Persona_Correo, StripTagsRegex(noHTML), emailBody);


                    Thread.Sleep(1000);
                    //UserMailer.TurnosVacios(encargado.Persona_Correo + "," + auxiliar.Persona_Correo, titulo, subTitulo, cuerpo, turnosPuesto).Send();
                }


                var registrarEnvio = new Sistema_Correos_Enviado_TransModel("")
                {
                    Correo_Enviado_Fecha = DateTime.Now,
                    Correo_Enviado_Texto = "Correo Enviado",
                    Registro_Estado = "A",
                    Registro_Fecha = DateTime.Now,
                    Correos_Secuencia = 2,
                    Registro_Usuario = "Automatico",

                };
                registrarEnvio.Save();
                
            }
        }


        public void TurnosVaciosEncargadosZonas()
        {
            var enviado = Proc_Correo_Enviado_HoyModel.LoadOne(3);

            if (enviado != null && enviado.Correo_Enviado_Fecha > DateTime.Now.AddDays(-1)) return;

            var turnosVacios = Proc_Puestos_Horario_Turnos_Faltantes_NotificacionModel.Load(-99, -99, -99);

            if (turnosVacios != null && turnosVacios.Count > 0)
            {

                var titulo = Messages.GetOrSetMensaje("CORREO_TURNOS_VACANTES_TITULO");

                var cuerpo = Messages.GetOrSetMensaje("CORREO_TURNOS_VACANTES_MENSAJE");

                foreach (var turnoVacio in turnosVacios.Select(x => new { x.Zona_Secuencia}).Distinct())
                {
                    var vacio = turnoVacio;
                    var turnosPuesto = turnosVacios.Where(x => x.Zona_Secuencia == vacio.Zona_Secuencia).ToList();
                    
                    string correos = string.Empty;
                    foreach (var encargado in Zonas_MasterModel.Load(vacio.Zona_Secuencia.Value).Encargados)
                    {
                        if (!string.IsNullOrEmpty(correos))
                        {
                            correos += ",";
                        }
                        correos += encargado.Persona.Persona_Correo;
                    }

                    //No hay encargado
                    if (string.IsNullOrEmpty(correos))
                    {
                       continue;
                    }

                    var subTitulo =
                        Messages.GetOrSetMensaje("CORREO_TURNOS_VACANTES_SUBTITULO").Replace("{Nombre_Completo}", "");
                       

                    dynamic model = new ExpandoObject();

                    model.Titulo = titulo;
                    model.SubTitulo = subTitulo;
                    model.Cuerpo = cuerpo;
                    model.Turnos = turnosPuesto.OrderBy(x => x.Turno_Fecha);

                    var templateLocation =
                        Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory,
                            @"Views/UserMailer/TurnosVacios.cshtml");

                    string template = File.ReadAllText(templateLocation);
                    string emailBody = Razor.Parse(template, model);
                    string noHTML = Regex.Replace(titulo, @"<[^>]+>|&nbsp;", "").Trim().Replace("&aacute;", "á").Replace("&eacute;", "é").Replace("&iacute;", "í").Replace("&oacute;", "ó").Replace("&uacute;", "ú");

                    Common.Util.EnviarCorreo(correos, StripTagsRegex(noHTML), emailBody);
                    

                    Thread.Sleep(1000);
                }

                var registrarEnvio = new Sistema_Correos_Enviado_TransModel("")
                {
                    Correo_Enviado_Fecha = DateTime.Now,
                    Correo_Enviado_Texto = "Correo Enviado",
                    Registro_Estado = "A",
                    Registro_Fecha = DateTime.Now,
                    Correos_Secuencia = 3,
                    Registro_Usuario = "Automatico",

                };
                registrarEnvio.Save();
            }
        }

    }
}