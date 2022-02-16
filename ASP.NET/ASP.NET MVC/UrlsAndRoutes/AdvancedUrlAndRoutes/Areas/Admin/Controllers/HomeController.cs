using System.Web.Mvc;

namespace AdvancedUrlAndRoutes.Areas.Admin.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }
   }
}