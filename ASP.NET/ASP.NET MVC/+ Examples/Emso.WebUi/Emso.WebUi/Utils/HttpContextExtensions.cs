using System;
using System.Web;
using Emso.WebUi.Infrastructure.Auth;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Emso.WebUi.Utils
{
   /// <summary>
   ///    Http context extension methods
   /// </summary>
   public static class HttpContextExtensions
   {
      public const string DummySessionId = "123456789";

      /// <summary>
      ///    Getting the root server Url from the Http context
      /// </summary>
      /// <param name="context">Http context</param>
      /// <returns>The root server Url</returns>
      public static string GetRootUrl(this HttpContext context)
      {
         if (context == null)
            throw new ArgumentNullException("context");

         var currentRequest = context.Request;
         var currentUrl = currentRequest.Url;
         var rootUrl = string.Format("{0}://{1}:{2}/", currentUrl.Scheme, currentUrl.Host, currentUrl.Port);
         return rootUrl;
      }

      /// <summary>
      ///    Get session id
      /// </summary>
      /// <param name="context">Http Context</param>
      /// <returns>Session Guid</returns>
      public static string GetSessionId(this HttpContext context)
      {
         return context != null && context.Session != null ? context.Session.SessionID : DummySessionId;
      }

      /// <summary>
      ///    Get session id
      /// </summary>
      /// <param name="context">Http Context</param>
      /// <returns>Session Guid</returns>
      public static string GetSessionId(this HttpContextBase context)
      {
         return context != null && context.Session != null ? context.Session.SessionID : DummySessionId;
      }

      /// <summary>
      ///    Get the App user manager instance from OWIN context
      /// </summary>
      /// <param name="context">Http context</param>
      /// <returns>App user manager instance</returns>
      public static AppUserManager GetAppUserManager(this HttpContextBase context)
      {
         return context != null ? context.GetOwinContext().GetUserManager<AppUserManager>() : null;
      }

      /// <summary>
      ///    Get the authentication manager
      /// </summary>
      /// <param name="context">Http context</param>
      /// <returns>The authentication manager</returns>
      public static IAuthenticationManager GetAuthManager(this HttpContextBase context)
      {
         return context != null ? context.GetOwinContext().Authentication : null;
      }
   }
}