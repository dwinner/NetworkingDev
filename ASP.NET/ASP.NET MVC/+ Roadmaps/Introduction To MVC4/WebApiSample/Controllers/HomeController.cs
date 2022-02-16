using System.Web.Mvc;

namespace WebApiSample.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }

      public ActionResult Menus()
      {
         ViewBag.Title = "Menu card";
         return View();
      }
   }
}
