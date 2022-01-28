/**
 * Модуль, обходящий авторизацию
 */

using System.Web;

namespace AuthUsers
{
   public class AuthModule : IHttpModule
   {
      public void Init(HttpApplication httpApp)
      {
         httpApp.PostAuthenticateRequest += (sender, args) =>
         {
            if (httpApp.Request.Path == "/Admin/Open.aspx")
            {
               httpApp.Context.SkipAuthorization = true;
            }
         };
      }

      public void Dispose()
      {
      }
   }
}