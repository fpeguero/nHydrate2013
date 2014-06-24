using System.Collections.Generic;
using Mvc.Mailer;
using OSIS.PEPPAM.Mvc.Models;

namespace OSIS.PEPPAM.Mvc.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage Welcome();
			MvcMailMessage PasswordReset();

         MvcMailMessage Correo(string to,string cc, string title, string subtitle, string body);

         MvcMailMessage TurnosVacios(string to, string title, string subtitle, string body, List<Proc_Puestos_Horario_Turnos_Faltantes_NotificacionModel> turnosPuesto);
    }
}