using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace I18n.Web.Infrastructure
{
   public class RouteBasedLocalizationController : Controller
   {
      protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
      {
         var cultureRouteSegment = RouteData.Values["culture"] as string;
         var cultureName = cultureRouteSegment ??
                           (Request.UserLanguages != null && Request.UserLanguages.Length > 0
                              ? Request.UserLanguages[0]
                              : null);

         cultureName = CultureHelper.GetImplementedCulture(cultureName);
         if (cultureRouteSegment != cultureName)
         {
            RouteData.Values["culture"] = cultureName.ToLowerInvariant();
            Response.RedirectToRoute(RouteData.Values);
         }

         Thread.CurrentThread.CurrentUICulture =
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName ?? CultureHelper.DefaultCulture);

         return base.BeginExecuteCore(callback, state);
      }      
   }
}