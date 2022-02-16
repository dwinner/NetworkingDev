using System.Web.Mvc;

namespace Spa.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }
   }
}
