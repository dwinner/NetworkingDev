using System.Web.Mvc;
using MenuPlanner.Filters;

namespace MenuPlanner.Controllers
{
   [Language]
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
         return View();
      }

      public ActionResult About()
      {
         ViewBag.Message = "Это самое обычное приложение, управляемое данными";
         return View();
      }

      public ActionResult Contact()
      {
         ViewBag.Message = "http://vk.com/hi_tech_denny";
         return View();
      }
   }
}
