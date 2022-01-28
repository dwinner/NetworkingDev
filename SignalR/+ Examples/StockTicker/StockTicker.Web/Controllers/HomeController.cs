using System.Web.Mvc;

namespace StockTicker.Web.Controllers
{
   public class HomeController : Controller
   {
      // GET: Home
      public ActionResult Index()
      {
         return View();
      }
   }
}