using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using FluentScheduler;
using FluentScheduler.Model;
using FluentValidation.Mvc;
using OSIS.PEPPAM;
using OSIS.PEPPAM.Mvc;
using OSIS.PEPPAM.Mvc;
using OSIS.PEPPAM.Mvc.Infrastructure.ScheduleTask;
using OSIS.PEPPAM.Mvc.Infrastructure.Security;
using FluentScheduler;

namespace OSIS.PEPPAM.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           // Database.SetInitializer<EntitiesDB>(null);

            AreaRegistration.RegisterAllAreas();

            ViewEngineConfig.SetupViewEngines();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
			BinderConfig.RegisterModelBinders();

            System.Web.Optimization.BundleTable.EnableOptimizations = false;
            
          
            
            FluentValidationModelValidatorProvider.Configure();

            TaskManager.UnobservedTaskException += TaskManager_UnobservedTaskException;
            TaskManager.Initialize(new TaskRegistry()); 

        }

        static void TaskManager_UnobservedTaskException(TaskExceptionInformation sender, UnhandledExceptionEventArgs e)
        {
            throw new Exception(e.ExceptionObject.ToString());
        }

        protected void Application_AcquireRequestState(object sender, System.EventArgs e)
        {
            // Globalization
            var curlture = new CultureInfo("es-DO");
            
            if (HttpContext.Current.Session != null)
            {
                Thread.CurrentThread.CurrentUICulture = curlture;
                Thread.CurrentThread.CurrentCulture = curlture;
            }
        }
        //protected void Application_AcquireRequestState(object sender, System.EventArgs e)
        //{
        //    // Globalization
        //    // Change this if you want to add a new culture
        //    //string[] acceptedCultures = new string[] { "es-ES", "en-US" };
        //    string[] acceptedCultures = new string[] { "es-ES" };
        //    IEnumerable<CultureInfo> cultures = acceptedCultures.Select(c => new CultureInfo(c));
            

        //    if (HttpContext.Current.Session != null)
        //    {
        //        RouteData route = HttpContext.Current.Request.RequestContext.RouteData;
        //        var lang = HttpContext.Current.Request.QueryString["lang"];

        //        if (lang != null && !string.IsNullOrEmpty(lang.ToString()))
        //        {
        //            Culture = CultureInfo.CreateSpecificCulture(lang);
        //        }
        //        else if (Culture == null)
        //        {
        //            IEnumerable<CultureInfo> preferredCultures = HttpContext.Current.Request.UserLanguages.Select(c => new CultureInfo(c.Split(';')[0]));

        //            foreach (CultureInfo preferredCulture in preferredCultures)
        //            {
        //                // Find exact culture
        //                Culture = cultures.FirstOrDefault(c => c.Equals(preferredCulture));

        //                // Find two letters culture
        //                if (Culture == null)
        //                    Culture = cultures.FirstOrDefault(c => c.TwoLetterISOLanguageName == preferredCulture.TwoLetterISOLanguageName);

        //                // Culture found
        //                if (Culture != null)
        //                    break;
        //            }

        //            // Default culture
        //            if (Culture == null)
        //                Culture = cultures.First();
        //        }
        //        Thread.CurrentThread.CurrentUICulture = Culture;
        //        Thread.CurrentThread.CurrentCulture = Culture;
        //    }
        //}


        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            //HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            

            HttpCookie authCookie = Request.Cookies["peppam"];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                PrincipalSerializeModel serializeModel =
                    serializer.Deserialize<PrincipalSerializeModel>(authTicket.UserData);

                if (authTicket.UserData == "OAuth") return;

                Principal newUser = new Principal(authTicket.Name)
                {
                    UsuarioApellido = serializeModel.UsuarioApellido,
                    UsuarioCorreo = serializeModel.UsuarioCorreo,

                    UsuarioNombres = serializeModel.UsuarioNombres,
                    UsuarioNumero = serializeModel.UsuarioNumero,
                    UsuarioSexo = serializeModel.UsuarioSexo,
                    UsuarioCongregacion = serializeModel.UsuarioCongregacion,
                    UsuarioZona = serializeModel.UsuarioZona
                };
                newUser.Roles.AddRange(serializeModel.Roles);




                HttpContext.Current.User = newUser;
            }
            else
            {
                FormsAuthentication.SignOut();
            }
        }

        private CultureInfo Culture
        {
            get
            {
                return HttpContext.Current.Session["Culture"] as CultureInfo;
            }
            set
            {
                HttpContext.Current.Session["Culture"] = value;
            }
        }
    }
}
