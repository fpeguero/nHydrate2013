using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Core.Security;
using OSIS.PEPPAM.Mvc.UI;

namespace OSIS.PEPPAM.Mvc.Extensions.Controllers
{

    public enum MessagesType
    {
        Success,
        Info,
        Warning,
        Error
    }

    public abstract class BaseController : Controller
    {
        protected virtual new IPrincipal User
        {
            get { return HttpContext.User as IPrincipal; }
        }

        public void AddNoEditarbleMessages()
        {
            @TempData["ErrorValidateMessage"] = Messages.GetOrSetMensaje("PRECAUCION_ESTE_REGISTRO_NO_SE_DEBE_EDITAR");
        }

        public void AddSusccesMessages(string messages)
        {
            @TempData["SuccessMessage"] = messages;
        }

        public void AddErrorMessages(string messages)
        {
            @TempData["ErrorValidateMessage"] = messages;
        }

        public void AddWaringMessages(string messages)
        {
            @TempData["UserMessage"] = messages;
        }


        public void ShowMessages(MessagesType type, string messages)
        {
            switch (type)
            {
                case MessagesType.Success:
                    @TempData["ShowMessageCss"] = "success";
                    @TempData["ShowMessageHeader"] = Messages.GetOrSetMensaje("MENSAJE_OPERACION_REALIZDA_SASTIFACTORIAMENTE_HEADER");
                    break;
                case MessagesType.Info:
                    @TempData["ShowMessageCss"] = "info";
                    @TempData["ShowMessageHeader"] = Messages.GetOrSetMensaje("MENSAJE_INFORMACION_HEADER");
                    break;
                case MessagesType.Warning:
                    @TempData["ShowMessageCss"] = "warning";
                    @TempData["ShowMessageHeader"] = Messages.GetOrSetMensaje("MENSAJE_PRECAUSION_HEADER");
                    break;
                case MessagesType.Error:
                    @TempData["ShowMessageCss"] = "error";
                    @TempData["ShowMessageHeader"] = Messages.GetOrSetMensaje("MENSAJE_ERROR_HEADER");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }

            @TempData["ShowMessage"] = messages;
        }

        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

    }
}
