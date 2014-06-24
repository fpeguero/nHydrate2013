using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSIS.PEPPAM.Mvc
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers:

            /**** Microsoft Account authentication ****
                // Requires NuGet package: Microsoft.Owin.Security.MicrosoftAccount
                app.UseMicrosoftAccountAuthentication(
                    clientId: "",
                    clientSecret: ""
                );
            */

            /**** Twitter authentication ****
                // Requires NuGet package: Microsoft.Owin.Security.Twitter
                app.UseTwitterAuthentication(
                   consumerKey: "",
                   consumerSecret: ""
                );
            */

            /**** Facebook authentication ****
                // Requires NuGet package: Microsoft.Owin.Security.Facebook
                app.UseFacebookAuthentication(
                   appId: "",
                   appSecret: ""
                );
            */

            /**** Google authentication ****
                // Requires NuGet package: Microsoft.Owin.Security.Google
                app.UseGoogleAuthentication();
            */
        }
    }
}