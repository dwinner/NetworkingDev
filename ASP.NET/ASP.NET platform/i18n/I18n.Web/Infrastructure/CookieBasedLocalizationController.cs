using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace I18n.Web.Infrastructure
{
   public class CookieBasedLocalizationController : Controller
   {
      protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
      {
         var cultureCookie = Request.Cookies["_culture"];
         var cultureName = cultureCookie != null
            ? cultureCookie.Value
            : (Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null);
         cultureName = CultureHelper.GetImplementedCulture(cultureName);
         Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);

         return base.BeginExecuteCore(callback, state);
      }
   }
}