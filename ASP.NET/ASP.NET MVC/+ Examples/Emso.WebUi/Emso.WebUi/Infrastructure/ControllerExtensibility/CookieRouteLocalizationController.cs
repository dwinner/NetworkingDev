using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Emso.WebUi.Utils;

namespace Emso.WebUi.Infrastructure.ControllerExtensibility
{
   /// <summary>
   ///    i18n implementation via both cookie and route values
   /// </summary>
   public class CookieRouteLocalizationController : Controller
   {
      protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
      {
         HttpCookie cultureCookie = Request.Cookies[CookieConstants.CultureKey];
         var cultuteRouteSegment = RouteData.Values[RouteConstants.CultureKey] as string;

         string cultureName = cultureCookie != null
            ? cultureCookie.Value
            : (Request.UserLanguages != null && Request.UserLanguages.Length > 0
               ? Request.UserLanguages[0]
               : null);

         cultureName = CultureHelper.GetImplementedCulture(cultureName);
         Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);

         if (cultuteRouteSegment != cultureName)
         {
            RouteData.Values[RouteConstants.CultureKey] = cultureName.ToLowerInvariant();
            Response.RedirectToRoute(RouteData.Values);
         }

         return base.BeginExecuteCore(callback, state);
      }
   }
}