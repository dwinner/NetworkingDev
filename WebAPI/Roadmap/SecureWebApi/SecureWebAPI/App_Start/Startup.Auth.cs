using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SecureWebAPI.Providers;

namespace SecureWebAPI
{
   public partial class Startup
   {
      static Startup()
      {
         PublicClientId = "self";

         UserManagerFactory = () => new UserManager<IdentityUser>(new UserStore<IdentityUser>());

         OAuthOptions = new OAuthAuthorizationServerOptions
         {
            TokenEndpointPath = new PathString("/Token"),
            Provider = new ApplicationOAuthProvider(PublicClientId, UserManagerFactory),
            AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
            AllowInsecureHttp = true
         };
      }

      public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

      public static Func<UserManager<IdentityUser>> UserManagerFactory { get; set; }

      public static string PublicClientId { get; private set; }

      // Дополнительные сведения о настройке проверки подлинности см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301864
      public void ConfigureAuth(IAppBuilder app)
      {
         // Enable the application to use a cookie to store information for the signed in user
         // and to use a cookie to temporarily store information about a user logging in with a third party login provider
         app.UseCookieAuthentication(new CookieAuthenticationOptions());
         app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

         // Включение использования приложением маркера-носителя для проверки подлинности пользователей
         app.UseOAuthBearerTokens(OAuthOptions);

         // Раскомментируйте приведенные далее строки, чтобы включить вход с помощью сторонних поставщиков входа
         //app.UseMicrosoftAccountAuthentication(
         //    clientId: "",
         //    clientSecret: "");

         //app.UseTwitterAuthentication(
         //    consumerKey: "",
         //    consumerSecret: "");

         //app.UseFacebookAuthentication(
         //    appId: "",
         //    appSecret: "");

         //app.UseGoogleAuthentication();
      }
   }
}