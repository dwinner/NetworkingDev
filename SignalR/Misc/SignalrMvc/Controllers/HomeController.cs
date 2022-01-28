using System.Web.Mvc;

namespace SignalrMvc.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }
   }
}