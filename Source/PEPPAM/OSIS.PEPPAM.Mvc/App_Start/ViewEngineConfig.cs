using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OSIS.PEPPAM.Mvc
{
    public static class ViewEngineConfig
    {
        public static void SetupViewEngines()
        {
            var webformViewEngine = ViewEngines.Engines.OfType<WebFormViewEngine>().SingleOrDefault();
            if (webformViewEngine != null)
            {
                ViewEngines.Engines.Remove(webformViewEngine);
            }
            var razorViewEngine = ViewEngines.Engines.OfType<RazorViewEngine>().FirstOrDefault();
            razorViewEngine.AreaViewLocationFormats = new string[]
                                                          {
                                                              "~/Areas/{2}/Views/{1}/{0}.cshtml",
                                                              "~/Areas/{2}/Views/{1}/{0}.gen.cshtml",
                                                              "~/Areas/{2}/Views/Shared/{0}.cshtml",
                                                              "~/Areas/{2}/Views/Shared/{0}.gen.cshtml",
                                                          };
            razorViewEngine.AreaPartialViewLocationFormats = new string[]
                                                                 {
                                                                     "~/Areas/{2}/Views/{1}/{0}.cshtml",
                                                                     "~/Areas/{2}/Views/{1}/{0}.gen.cshtml",
                                                                     "~/Areas/{2}/Views/Shared/{0}.cshtml",
                                                                     "~/Areas/{2}/Views/Shared/{0}.gen.cshtml",
                                                                 };
            razorViewEngine.ViewLocationFormats = new string[]
                                                      {
                                                          "~/Views/{1}/{0}.cshtml",
                                                          "~/Views/{1}/{0}.gen.cshtml",
                                                          "~/Views/Shared/{0}.cshtml",
                                                          "~/Views/Shared/{0}.gen.cshtml",
                                                      };
            razorViewEngine.PartialViewLocationFormats = new string[]
                                                             {
                                                                 "~/Views/{1}/{0}.cshtml",
                                                                 "~/Views/{1}/{0}.gen.cshtml",
                                                                 "~/Views/Shared/{0}.cshtml",
                                                                 "~/Views/Shared/{0}.gen.cshtml",
                                                             };
        }
    }
}