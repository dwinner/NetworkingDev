using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
   public class AdminController : Controller
   {
      // GET: Admin
      public ActionResult Index()
      {
         ViewBag.Controller = "Admin";
         ViewBag.Action = "Index";
         return View("ActionName");
      }
   }
}