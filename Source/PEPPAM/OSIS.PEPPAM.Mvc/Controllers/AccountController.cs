using System;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Microsoft.AspNet.Identity;
//using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Mvc.Mailer;
using OSIS.PEPPAM.Mvc.Extensions.Controllers;
using OSIS.PEPPAM.Mvc.Infrastructure.Common;
using OSIS.PEPPAM.Mvc.Infrastructure.Security;
using OSIS.PEPPAM.Mvc.Mailers;
using OSIS.PEPPAM.Mvc.Models;
using OSIS.PEPPAM.Mvc.Models.Account;
using OSIS.PEPPAM.Mvc.UI;

namespace OSIS.PEPPAM.Mvc.Controllers
{
 
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // Replace with your own logic:
                var username = model.UserName;
                var fullName = model.UserName;
                var roles = new[] { "member" };

                var userExist = Personas_MasterModel.LoadByPersona_Correo(username);
                if (userExist == null || !Encript.VerifyHashedPassword(userExist.Persona_Clave, model.Password) ||
                    userExist.Persona_Estado_Secuencia == 3 || userExist.Registro_Estado != "A")
                {
                    @TempData["ErrorValidateMessage"] =
                        UI.Messages.GetMensaje("MENSAJE_ERROR_USUARIO_O_CONTRASENIA_NO_EXISTEN", true);

                    return View(model);
                }

                if (userExist.Persona_Estado_Secuencia == 1)
                {
                    @TempData["ErrorValidateMessage"] =
                        UI.Messages.GetMensaje("MENSAJE_ERROR_USUARIO_NO_APROBADO", true);

                    return View(model);
                }




                CreateAuthenticationTicket(userExist);


                return RedirectToLocal(returnUrl);
            }
            return View(model);
        }


        public ActionResult AccessDenied()
        {
            
            return View("AccesDenied");
        }

        public ActionResult CambiarContrasenia()
        {
            var model = new PersonaRegistro();
            return View("_ChangePasswordPartial", model);
        }

        [HttpPost]
        public ActionResult CambiarContrasenia(PersonaCambiarContrasenia model)
        {

            if (ModelState.IsValid)
            {
                var userExist = Personas_MasterModel.LoadByPersona_Correo(User.UsuarioCorreo);
                if (userExist == null || userExist.Persona_Clave != model.Clave_Actual)
                {
                    @TempData["ErrorValidateMessage"] =
                        UI.Messages.GetMensaje("MENSAJE_ERROR_CONTRASENIA_NO_CORRESPONDE");

                    return View("_ChangePasswordPartial", model);
                }

                userExist.Persona_Clave = model.Nueva_Clave;
                userExist.Save();


                TempData["successMsg"] = UI.Messages.GetMensaje("MENSAJE_CONTRASENIA_CAMBIADA");
                return View("_successMsg");
            }



            return View("_ChangePasswordPartial");
        }

        [AllowAnonymous]
        public ActionResult Recuperar()
        {
            
            return View("_RecuperarClave");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Recuperar(string correo)
        {
            if (string.IsNullOrEmpty(correo))
            {
                ModelState.AddModelError("",Messages.GetMensaje("MENSAJE_ERROR_DEBE_INDICAR_CORREO",true));
                return View("_RecuperarClave");
            }

            var usuario = Personas_MasterModel.LoadByPersona_Correo(correo);

            if (usuario == null)
            {
                ModelState.AddModelError("", Messages.GetMensaje("MENSAJE_ERROR_CORREO_NO_EXISTE", true));
                return View("_RecuperarClave");
            }

            var code = Guid.NewGuid().ToString().Substring(0, 15);
            usuario.Persona_Verificacion_Numero = code;
            usuario.Save();
            string hostUrl;

#if DEBUG
              hostUrl= Request.Url.Scheme + "://" + Request.Url.Host + "/" + Request.Url.Segments[1] + "Account/Recuperando?id=" + correo + "&code=" + code;    
#else
             hostUrl= Request.Url.Scheme + "://" + Request.Url.Host + "/" + "Account/Recuperando?id=" + correo + "&code=" + code;
#endif
           



          //  Util.EnviarCorreo(correo,"Recuperar",hostUrl);

            var titulo = Messages.GetOrSetMensaje("CORREO_RECUPERAR_CLAVE_TITULO");
            var subTitulo = Messages.GetOrSetMensaje("CORREO_RECUPERAR_CLAVE_SUBTITULO").Replace("{Nombre_Completo}", usuario.Persona_Nombres);
            var cuerpo = Messages.GetOrSetMensaje("CORREO_TITULO_RECUPERAR_CLAVE_MENSAJE").Replace("{Link}", hostUrl);

            UserMailer.Correo(correo, "", titulo, subTitulo, cuerpo).Send();

            @TempData["correoenviado"] = Messages.GetMensaje("RECUPARAR_CORREO_ENVIADO_REVISAR", true);

            return View("_RecuperarClave");
            
        }

        private IUserMailer _userMailer = new UserMailer();
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }
        

        [AllowAnonymous]
        public ActionResult Recuperando(string id, string code)
        {

            var usuario = Personas_MasterModel.LoadByPersona_Correo(id);
            if (usuario != null)
            {
                if (code == usuario.Persona_Verificacion_Numero)
                {
                    var nuevaClave = Guid.NewGuid().ToString().Substring(0, 10);
                    usuario.Persona_Clave =nuevaClave ;
                    usuario.Save();
                    
                    Util.EnviarCorreo(usuario.Persona_Correo, "Nueva Clave", string.Format(Messages.GetMensaje("CORREO_NUEVA_CLAVE_CAMBIADA"), nuevaClave));

                    @TempData["correoenviado"] = Messages.GetMensaje("MENSAJE_NUEVA_CLAVE_CAMBIADA");

                    return View("_Confirmacion");
                }
            }

            return new HttpStatusCodeResult(500);

        }

        [AllowAnonymous]
        public ActionResult Registro()
        {
            var model = new PersonaRegistro();


            var respuestas = Proc_Registro_Pregunta_RespuestasModel.Load();
            var correcta = respuestas.FirstOrDefault(x => x.Respuesta_Correcta == "S");

            model.Respuesta_Correcta = correcta.Respuesta_Secuencia2;
            model.Pregunta_Descripcion = correcta.Pregunta_Descripcion;
            model.Respuestas = respuestas;



            return View("_RegistroCreate", model);
        }

        //_RecuperarClave
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registro(PersonaRegistro model)
        {
            if (ModelState.IsValid)
            {
                if (model.Respuesta_Correcta.Trim() == model.Respuesta_Secuencia.Trim())
                {
                    var userExist = Personas_MasterModel.LoadByPersona_Correo(model.Persona_Correo);
                    if (userExist == null)
                    {
                        var userNew = new Personas_MasterModel()
                        {
                            Registro_Fecha = DateTime.Now,
                            Registro_Estado = "A",
                            Registro_Usuario = model.Persona_Correo,
                            Persona_Correo = model.Persona_Correo,
                            Persona_Congregacion = model.Congregacion_Nombre,
                            Congregacion_Secuencia = -999,
                            Persona_Apellidos = model.Persona_Apellidos,
                            Persona_Clave = Encript.HashPassword(model.Persona_Clave, null, HashAlgorithm.Create("MD5")),
                            Persona_Nombres = model.Persona_Nombres,
                            Persona_Sexo = model.Persona_Sexo,
                            Persona_Tipo_Secuencia = 8, //Precursor
                            Persona_Conyuge_Apellido = "N/A",
                            Persona_Verificacion_Numero = Guid.NewGuid().ToString().Substring(0, 10),
                            Persona_Estado_Secuencia = 1
                        };

                        userNew.Save();
                        
                        var addRoles = new Persona_Roles_TransModel()
                        {
                            Registro_Estado = "A",
                            Registro_Fecha = DateTime.Now,
                            Registro_Usuario = model.Persona_Correo,
                            Persona_Secuencia = userNew.Persona_Secuencia,
                            Role_Numero = 1, // Precursor

                        };
                        addRoles.Save();

                        Task.Factory.StartNew(() =>
                        {
                        var encargadosZona =
                            Proc_Personas_RoleModel.Load(4);

                            if (encargadosZona != null && encargadosZona.Count > 0)
                            {

                                var titulo = Messages.GetOrSetMensaje("CORREO_NUEVO_REGISTRO_TITULO");
                                var subTitulo =
                                    Messages.GetOrSetMensaje("CORREO_NUEVO_REGISTRO_SUBTITULO")
                                        .Replace("{Nombre_Completo}", "");

                                var cuerpo =
                                    Util.StringFormarDatos(
                                        Util.StringFormarSexo(Messages.GetOrSetMensaje("CORREO_NUEVO_REGISTRO_MENSAJE"),
                                            userNew.Persona_Sexo), new Dictionary<string, string>()
                                            {
                                                {
                                                    "{Nombre_Completo}", userNew.Nombre_Completo
                                                },
                                                {
                                                    "{Nombre_Congregacion}", userNew.Persona_Congregacion
                                                },
                                                {
                                                    "{Fecha_Registro}", userNew.Registro_Fecha.ToString("D")
                                                }
                                            });

                                UserMailer.Correo(string.Join(",", encargadosZona.Select(x => x.Persona_Correo)),
                                    string.Join(",", encargadosZona.Select(x => x.Persona_Correo)),
                                    titulo, subTitulo, cuerpo).Send();
                            }
                        });




                        return View("_msg","_Layout", Util.StringFormarDatos(Util.StringFormarSexo(UI.Messages.GetMensaje("MENSAJE_REGISTRO_COMPLETADO", true), userNew.Persona_Sexo), new Dictionary<string, string>()
                        {
                            {
                               "{Apellidos}", userNew.Persona_Apellidos
                            }
                        }));


                       

                        //return RedirectToAction("Login");
                     
                    }
                    @TempData["ErrorValidateMessage"] =
                        UI.Messages.GetMensaje("MENSAJE_ERROR_CORREO_EXISTE", true);
                }
                else
                {
                    @TempData["ErrorValidateMessage"] =
                       UI.Messages.GetMensaje("MENSAJE_ERROR_RESPUESTA_INCORRECTA", true);
                }
                
            }
            ModelState.Remove("Respuesta_Correcta");  

            var respuestas = Proc_Registro_Pregunta_RespuestasModel.Load();
            var correcta = respuestas.FirstOrDefault(x => x.Respuesta_Correcta == "S");

            model.Respuesta_Correcta = correcta.Respuesta_Secuencia2;
            model.Pregunta_Descripcion = correcta.Pregunta_Descripcion;
            model.Respuestas = respuestas;
            
            model.Respuesta_Secuencia = string.Empty;

            return View("_RegistroCreate", model);
        }




        public void CreateAuthenticationTicket(Personas_MasterModel userExist)
        {
            var serializeModel = new PrincipalSerializeModel()
            {
                UsuarioApellido = userExist.Persona_Apellidos,
                UsuarioCorreo = userExist.Persona_Correo,


                UsuarioNombres = userExist.Persona_Nombres + " " + userExist.Persona_Apellidos,
                UsuarioNumero = userExist.Persona_Secuencia,
                UsuarioSexo = userExist.Persona_Sexo,
                UsuarioCongregacion = userExist.Congregacion_Secuencia,
                UsuarioZona = userExist.Congregacion.Zona_Secuencia
            };

            if (string.IsNullOrEmpty(serializeModel.UsuarioNombres))
            {
                serializeModel.UsuarioNombres = userExist.Persona_Correo;
            }

            //var usuariosLocalidadTransModel = userExist.UsuariosLocalidadTrans.FirstOrDefault();
            //if (usuariosLocalidadTransModel != null)
            //{
            //    serializeModel.UsuarioLocalidadNombre =
            //        usuariosLocalidadTransModel.UsuariosLocalidadCata.Localidad_Nombre;
            //    serializeModel.UsuarioLocalidadNumero =
            //        usuariosLocalidadTransModel.UsuariosLocalidadCata.Localidad_Secuencia;
            //}

            var usuariosRolesTransModel = userExist.PersonaRolesTrans.FirstOrDefault();
            if (usuariosRolesTransModel != null)
                serializeModel.Roles.Add(usuariosRolesTransModel.RolesCata.Role_Descripcion);


            var serializer = new JavaScriptSerializer();

            string userData = serializer.Serialize(serializeModel);


            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1, userExist.Persona_Correo, DateTime.Now, DateTime.Now.AddHours(8), false, userData);
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            //HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            HttpCookie faCookie = new HttpCookie("peppam", encTicket);
            
            Response.Cookies.Add(faCookie);
        }



        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut();

            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }


        #region Private helpers

        /// <summary>
        /// Gets the authentication manager from the OWIN context
        /// </summary>
        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Authentication;
        //    }
        //}

        /// <summary>
        /// Redirects the browser to the specified URL, if it is local.
        /// </summary>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Creates a simple ClaimsIdentity object
        /// </summary>
        private ClaimsIdentity CreateIdentity(string username, string fullName, IEnumerable<string> roles)
        {
            var identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.NameIdentifier, ClaimTypes.Role);
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, username));
            identity.AddClaim(new Claim(ClaimTypes.Name, fullName));
            if (roles != null && roles.Any())
            {
                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }
            }
            return identity;
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }
            private const string XsrfKey = "XsrfId";

            public override void ExecuteResult(ControllerContext context)
            {
                //var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                //if (UserId != null)
                //{
                //    properties.Dictionary[XsrfKey] = UserId;
                //}
                //context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}
