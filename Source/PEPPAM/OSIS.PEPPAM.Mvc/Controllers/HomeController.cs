using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSIS.PEPPAM.Mvc.Extensions.Controllers;
using OSIS.PEPPAM.Mvc.Infrastructure;

namespace OSIS.PEPPAM.Mvc.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult TurnosDisponibles()
        {
            return PartialView("_TurnosDisponibles");
        }
    }
}
