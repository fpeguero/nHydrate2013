using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace OSIS.PEPPAM.Mvc.Infrastructure.Common
{
    public class Util
    {
        public static string FormatName(string nombre)
        {
            string returnNombre = string.Empty;

            var nombre1 = nombre.TrimStart().TrimEnd().ToLower();

            string[] nombres = nombre1.Split(Convert.ToChar(" "));

            foreach (var nombreparcial in nombres)
            {
                if (nombreparcial.Length < 2)
                {
                    continue;
                }

                returnNombre = returnNombre + nombreparcial.Substring(0, 1).ToUpper();
                returnNombre = returnNombre + nombreparcial.Substring(1, nombreparcial.Length - 1);
                returnNombre = returnNombre + " ";
            }

            return returnNombre;
        }


        public static void EnviarCorreo(string to, string subject, string body)
        {
            EnviarCorreo(to, "", subject, body);
        }

        public static void EnviarCorreo(string to, string cc, string subject, string body)
        {
            MailMessage mail = new MailMessage();

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Credentials = new System.Net.NetworkCredential("peppamdom@gmail.com", "teocratico");
            smtpServer.Port = 587; // Gmail works on this port
            smtpServer.EnableSsl = true;

            mail.From = new MailAddress("peppamdom@gmail.com","PEPPAM");

            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;

            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(to);
            }

            mail.IsBodyHtml = true;

            smtpServer.Send(mail);
        }


        public static string StringFormarSexo(string text, string sexo)
        {
            var sexoletra = sexo.Trim() == "M" ? "o" : "a";

            text = text.Replace("{El_La}", sexo.Trim() == "M" ? "El":"La");

            return text.Replace("{@}", sexoletra);
        }

        public static string StringFormarDatos(string text, Dictionary<string,string> datos)
        {
            return datos.Aggregate(text, (current, dato) => current.Replace(dato.Key, dato.Value));
        }
    }
}