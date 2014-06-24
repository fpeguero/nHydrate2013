using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Core.Security;
using OSIS.PEPPAM.Mvc.Models;

namespace OSIS.PEPPAM.Mvc.Infrastructure
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _funcionalityName;
        private readonly string _actionName;


        public CustomAuthorizeAttribute()
        {
        }
        public CustomAuthorizeAttribute(string funcionalityName)
        {
            _funcionalityName = funcionalityName;
        }

        public CustomAuthorizeAttribute(string funcionalityName, string actionName)
        {
            _funcionalityName = funcionalityName;
            _actionName = actionName;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!base.AuthorizeCore(httpContext))
            {
                return false;
            }
            var user = httpContext.User as IPrincipal;

            if (user == null) return false;

            if (string.IsNullOrEmpty(_actionName) && string.IsNullOrEmpty(_funcionalityName))
            {
                return true;
            }


            if (!string.IsNullOrEmpty(_actionName))
            {
                var permiso = Personas_MasterModel.FuncionalidadesAcciones(_actionName, _funcionalityName,
                    user.UsuarioNumero);

                if (permiso.Count < 1)
                {
                    return false;
                }

                return true;
            }

            var permisoFuncionalidad = Personas_MasterModel.Funcionalidades(_funcionalityName,null, user.UsuarioNumero);

            if (permisoFuncionalidad.Count < 1)
            {
                return false;
            }


            return true;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/Account/login");
                return;
            }

            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Account/AccessDenied");
            }
        }
    }
}