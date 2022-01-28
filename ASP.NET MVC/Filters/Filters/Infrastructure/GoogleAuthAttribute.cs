using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Security;

namespace Filters.Infrastructure
{
   /// <summary>
   ///    Фильтр аутентификации
   /// </summary>
   public class GoogleAuthAttribute : FilterAttribute, IAuthenticationFilter
   {
      public void OnAuthentication(AuthenticationContext filterContext)
      {
         var identity = filterContext.Principal.Identity;
         if (!identity.IsAuthenticated || !identity.Name.EndsWith("@google.com"))
         {
            filterContext.Result = new HttpUnauthorizedResult();
         }
      }

      public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
      {
         if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
         {
            filterContext.Result =
               new RedirectToRouteResult(new RouteValueDictionary
               {
                  {"controller", "GoogleAccount"},
                  {"action", "Login"},
                  {"returnUrl", filterContext.HttpContext.Request.RawUrl}
               });
         }
         else
         {
            FormsAuthentication.SignOut();
         }
      }
   }
}