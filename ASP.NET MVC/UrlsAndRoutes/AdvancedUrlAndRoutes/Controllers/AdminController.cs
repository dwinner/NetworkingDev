using System.Web.Mvc;

namespace AdvancedUrlAndRoutes.Controllers
{
   public class AdminController : Controller
   {
      public ActionResult Index()
      {
         ViewBag.Controller = "Admin";
         ViewBag.Action = "Index";
         return View("ActionName");
      }
   }
}