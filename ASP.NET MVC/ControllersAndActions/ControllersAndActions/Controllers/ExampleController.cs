using System;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
   public class ExampleController : Controller
   {
      public ViewResult Index()
      {
         ViewBag.Message = TempData["Message"];
         ViewBag.Date = TempData["Date"];
         return View(DateTime.Now);
      }

      public RedirectResult Redirect() // Перенаправление на точный URL
      {
         return Redirect("/Example/Index");
      }

      public RedirectToRouteResult RouteRedirect() // Перенаправление на URL системы маршрутизации
      {
         TempData["Message"] = "Hello";
         TempData["Date"] = DateTime.Now;
         return RedirectToAction("Index"/*, "Basic"*/);
         // return RedirectToRoute(new { controller = "Example", action = "Index", id = "MyId" });
      }

      public HttpStatusCodeResult StatusCode()
      {
         return HttpNotFound();  // return new HttpStatusCodeResult(404, "URL cannot be serviced");
      }
   }
}