using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OSIS.PEPPAM.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("elmah.axd");

            //MiPeppam/Personales

           // routes.MapRoute(
           //    name: "Zonas",
           //    url: "Zonas/{action}/{id}",
           //    defaults: new { controller = "Zonas_Master", action = "Index", id = UrlParameter.Optional }
           //);

            //mipeppam/MisInformes
            routes.MapRoute(
               name: "DatosPersonales",
               url: "DatosPersonales/{id}",
               defaults: new { controller = "MiPeppam", action = "Personales", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Informes",
              url: "Informes/{action}/{id}",
              defaults: new { controller = "Colocaciones", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Admin_Slides",
              url: "Admin/Slides/{id}",
              defaults: new { controller = "Sistemas_Slides_Master", action = "Index", id = UrlParameter.Optional }
          );

            //
            routes.MapRoute(
               name: "MisExperiencias",
               url: "MisExperiencias/{id}",
               defaults: new { controller = "MiPeppam", action = "MisExperiencias", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "midisponibilidad",
              url: "midisponibilidad/{id}",
              defaults: new { controller = "MiPeppam", action = "LoadDisponibilidad", id = UrlParameter.Optional }
          );
            routes.MapRoute(
               name: "MisInformes",
               url: "MisInformes/{id}",
               defaults: new { controller = "MiPeppam", action = "MisInformes", id = UrlParameter.Optional }
           );

            
          //  routes.MapRoute(
          //    name: "circuitos",
          //    url: "circuitos/{action}/{id}",
          //    defaults: new { controller = "Circuitos_Cata", action = "Index", id = UrlParameter.Optional }
          //);

          //  routes.MapRoute(
          //    name: "Congregaciones",
          //    url: "Congregaciones/{action}/{id}",
          //    defaults: new { controller = "Congregaciones_Master", action = "Index", id = UrlParameter.Optional }
          //);

               routes.MapRoute(
              name: "ContactoTipo",
              url: "ContactoTipo/{action}/{id}",
              defaults: new { controller = "Contacto_Tipo_Cata", action = "Index", id = UrlParameter.Optional }
          );

               routes.MapRoute(
                name: "Dias",
                url: "Dias/{action}/{id}",
                defaults: new { controller = "Dias_Cata", action = "Index", id = UrlParameter.Optional }
            );


             routes.MapRoute(
                name: "Idiomas",
                url: "Idiomas/{action}/{id}",
                defaults: new { controller = "Idiomas_Cata", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "NotificacionPrioridad",
                url: "NotificacionPrioridad/{action}/{id}",
                defaults: new { controller = "Notificaciones_Prioridades_Cata", action = "Index", id = UrlParameter.Optional }
            );


             routes.MapRoute(
                name: "Roles",
                url:  "Roles/{action}/{id}",
                defaults: new { controller = "Personas_Tipo_Cata", action = "Index", id = UrlParameter.Optional }
            );

             routes.MapRoute(
                name: "Publicaciones",
                url: "Publicaciones/{action}/{id}",
                defaults: new { controller = "Publicaciones_Cata", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Personas",
                url: "Personas/{action}/{id}",
                defaults: new { controller = "Personas_Master", action = "Index", id = UrlParameter.Optional }
            );


             routes.MapRoute(
                name: "Puestos",
                url: "Puestos/{action}/{id}",
                defaults: new { controller = "Rutas_Master", action = "Index", id = UrlParameter.Optional }
            );

             routes.MapRoute(
                name: "HorarioPlantilla",
                url: "HorarioPlantilla/{action}/{id}",
                defaults: new { controller = "Horarios_Master", action = "Index", id = UrlParameter.Optional }
            );
            
             //Horario_Trans
             routes.MapRoute(
                name: "Horarios",
                url: "Horarios/{action}/{id}",
                defaults: new { controller = "Horario_Trans", action = "Index", id = UrlParameter.Optional }
            );
            
            




            //ADMINISTRACION
             routes.MapRoute(
               name: "Admin_Experiencias",
               url: "Admin-Experiencias/{action}/{id}",
               defaults: new { controller = "Experiencias_Master", action = "Index", id = UrlParameter.Optional }
           );

             routes.MapRoute(
               name: "Admin_Avisos",
               url: "Admin-Avisos/{action}/{id}",
               defaults: new { controller = "Notificaciones_Master", action = "Index", id = UrlParameter.Optional }
           );


             routes.MapRoute(
              name: "Admin_Documentos",
              url: "Admin-Documentos/{action}/{id}",
              defaults: new { controller = "Documentos_Master", action = "Index", id = UrlParameter.Optional }
          );



             routes.MapRoute(
              name: "Admin_Sliders",
              url: "Admin-Sliders/{action}/{id}",
              defaults: new { controller = "Sistemas_Slides_Master", action = "Index", id = UrlParameter.Optional }
          );

             routes.MapRoute(
              name: "Admin_Congregaciones",
              url: "Admin-Congregaciones/{action}/{id}",
              defaults: new { controller = "Congregaciones_Master", action = "Index", id = UrlParameter.Optional }
          );

             routes.MapRoute(
            name: "Admin_Circuito",
            url: "Admin-Circuitos/{action}/{id}",
            defaults: new { controller = "Circuitos_Cata", action = "Index", id = UrlParameter.Optional }
        );

             routes.MapRoute(
            name: "Admin_Zonas",
            url: "Admin-Zonas/{action}/{id}",
            defaults: new { controller = "Zonas_Master", action = "Index", id = UrlParameter.Optional }
        );

             routes.MapRoute(
            name: "Admin_Puestos",
            url: "Admin-Puestos/{action}/{id}",
            defaults: new { controller = "Rutas_Master", action = "Index", id = UrlParameter.Optional }
        );

             routes.MapRoute(
            name: "Admin_Reportes_detallado",
            url: "admin-reportedetalle/{id}",
            defaults: new { controller = "Reportes", action = "Detalles", id = UrlParameter.Optional }
        );
             routes.MapRoute(
             name: "Admin_Reportes_general",
             url: "admin-reportes/{action}/{id}",
             defaults: new { controller = "Reportes", action = "Index", id = UrlParameter.Optional }
         );

             //Reportes

             //Circuitos_Cata
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}