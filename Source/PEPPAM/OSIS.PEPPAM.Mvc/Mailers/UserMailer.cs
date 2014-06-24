using System.Collections.Generic;
using System.Net.Mail;
using System.Web.Mvc;
using Mvc.Mailer;
using OSIS.PEPPAM.Mvc.Models;

namespace OSIS.PEPPAM.Mvc.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
		public UserMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage Welcome()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "Welcome";
				x.ViewName = "Welcome";
				x.To.Add("some-email@example.com");
			});
		}
 
		public virtual MvcMailMessage PasswordReset()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "PasswordReset";
				x.ViewName = "PasswordReset";
				x.To.Add("some-email@example.com");
			});
		}

      public virtual MvcMailMessage Correo(string to,string cc,string title, string subtitle, string body)
      {
          //ViewBag.Data = someObject;
          ViewBag.Titulo = title;
          ViewBag.SubTitulo = subtitle;
          ViewBag.Cuerpo = body;
          var result = Populate(x =>
          {
               x.ViewName = "Correo";
               x.To.Add(to);
               x.From = new MailAddress("peppamdom@gmail.com", "PEPPAM");
              
          });

          if (!string.IsNullOrEmpty(cc))
          {
              result.CC.Add(cc);
          }

          return result;
      }

        public MvcMailMessage TurnosVacios(string to, string title, string subtitle, string body, List<Proc_Puestos_Horario_Turnos_Faltantes_NotificacionModel> turnosPuesto)
        {
            ViewBag.Titulo = title;
            ViewBag.SubTitulo = subtitle;
            ViewBag.Cuerpo = body;

            @ViewData["Turnos"] = new ViewDataDictionary(turnosPuesto);

            var result = Populate(x =>
            {
                x.ViewName = "TurnosVacios";
                x.To.Add(to);
                x.From = new MailAddress("peppamdom@gmail.com", "PEPPAM");

            });

           

            return result;
        }
	}
}