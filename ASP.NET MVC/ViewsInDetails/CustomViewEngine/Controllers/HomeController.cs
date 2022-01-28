using System;
using System.Web.Mvc;

namespace CustomViewEngine.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         ViewBag.Message = "Hello, World";
         ViewBag.Time = DateTime.Now.ToShortTimeString();
         // ReSharper disable once Mvc.ViewNotResolved
         return View("DebugData");
      }

      public ActionResult List()
      {
         // ReSharper disable Mvc.ViewNotResolved
         return View();
         // ReSharper restore Mvc.ViewNotResolved
      }
   }
}