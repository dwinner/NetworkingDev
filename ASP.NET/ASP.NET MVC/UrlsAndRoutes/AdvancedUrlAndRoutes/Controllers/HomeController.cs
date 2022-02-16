using System.Web.Mvc;

namespace AdvancedUrlAndRoutes.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         ViewBag.Controller = "Home";
         ViewBag.Action = "Index";
         return View("ActionName");
      }

      public ActionResult CustomVariable(string id = "DefaultId")
      {
         ViewBag.Controller = "Home";
         ViewBag.Action = "CustomVariable";

         ViewBag.CustomVariable = id;
         return View();
      }

      public RedirectToRouteResult MyActionMethod()
      {
         string myActionUrl = Url.Action("Index", new { id = "MyId" });
         string myRouteUrl = Url.RouteUrl(new { controller = "Home", action = "Index" });
         // NOTE: Сделать что-нибудь с Url...
         return RedirectToRoute(new { controller = "Home", action = "Index", id = "MyId" }); //return RedirectToAction("Index");
      }
   }
}