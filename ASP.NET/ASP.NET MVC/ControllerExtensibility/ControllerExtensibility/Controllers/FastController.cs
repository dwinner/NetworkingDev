using System.Web.Mvc;
using System.Web.SessionState;
using ControllerExtensibility.Models;

namespace ControllerExtensibility.Controllers
{
   /// <summary>
   ///    Контроллер без поддержки состояния сеанса
   /// </summary>
   [SessionState(SessionStateBehavior.Disabled)]
   public class FastController : Controller
   {
      // GET: Fast
      public ActionResult Index()
      {
         return View("Result", new Result {ControllerName = "Fast", ActionName = "Index"});
      }
   }
}