namespace Emso.WebUi.Controllers
{
   using System;
   using System.Web;
   using System.Web.Mvc;

   using Infrastructure;
   using Infrastructure.ControllerExtensibility;

   using Utils;

   public class LocalizationController : CookieRouteLocalizationController
   {
      public ActionResult SetCookieCulture(string culture)
      {
         string implementedCulture = CultureHelper.GetImplementedCulture(culture);
         RouteData.Values[RouteConstants.CultureKey] = implementedCulture;
         HttpCookie cookie = Request.Cookies[CookieConstants.CultureKey];

         if (cookie != null)
         {
            cookie.Value = implementedCulture;
         }
         else
         {
            cookie = new HttpCookie(CookieConstants.CultureKey)
            {
               Value = implementedCulture,
               Expires = DateTime.Now.AddYears(1)
            };
         }

         Response.Cookies.Add(cookie);

         return HttpContext.Request.UrlReferrer != null
                   ? (ActionResult) Redirect(HttpContext.Request.UrlReferrer.OriginalString)
                   : RedirectToAction("Index", "Home");
      }
   }
}