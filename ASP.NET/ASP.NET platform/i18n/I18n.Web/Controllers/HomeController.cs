using System;
using System.Web;
using System.Web.Mvc;
using I18n.Web.Infrastructure;
using I18n.Web.Models;

namespace I18n.Web.Controllers
{
   public class HomeController : RouteBasedLocalizationController//CookieBasedLocalizationController
   {
      [HttpGet]
      public ActionResult Index()
      {
         return View();
      }

      [HttpPost]
      public ActionResult Index(Person person)
      {
         return View(person);
      }

      public ActionResult SetRouteCulture(string culture)
      {
         RouteData.Values["culture"] = CultureHelper.GetImplementedCulture(culture);
         return RedirectToAction("Index");
      }

      public ActionResult SetCookieCulture(string culture)
      {         
         var implementedCulture = CultureHelper.GetImplementedCulture(culture);
         var cookie = Request.Cookies["_culture"];
         if (cookie != null)
         {
            cookie.Value = implementedCulture;
         }
         else
         {
            cookie = new HttpCookie("_culture") { Value = implementedCulture, Expires = DateTime.Now.AddYears(1) };
         }

         Response.Cookies.Add(cookie);
         return RedirectToAction("Index");
      }
   }
}