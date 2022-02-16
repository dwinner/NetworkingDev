using System;
using System.Threading;
using Emso.WebUi.Infrastructure.Auth;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Emso.WebUi
{
   public class IdentityConfig
   {
      public void Configuration(IAppBuilder app)
      {
         app.CreatePerOwinContext(AppIdentityDbContext.Create);
         app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
         app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);

         string langName = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;         
         app.UseCookieAuthentication(new CookieAuthenticationOptions
         {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString(string.Format("/{0}/Account/Login", langName))
         });

         app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
      }
   }
}