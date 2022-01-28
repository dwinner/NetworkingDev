using System;
using System.Web;

namespace Events
{
   public class ParamsModule : IHttpModule
   {
      public void Dispose()
      {
      }

      public void Init(HttpApplication httpApp)
      {
         httpApp.PostAuthenticateRequest += (sender, args) =>
         {
            if (httpApp.Context.Request.Url.LocalPath == "/Params.aspx" &&
                !httpApp.Context.User.Identity.IsAuthenticated)
            {
               httpApp.Context.AddError(new UnauthorizedAccessException());
            }
         };
      }
   }
}