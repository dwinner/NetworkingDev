using System.Web.Mvc;
using ControllerExtensibility.Infrastructure;
using ControllerExtensibility.Models;

namespace ControllerExtensibility.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View("Result", new Result {ControllerName = "Home", ActionName = "Index"});
      }

      [Local]  // NOTE: Разрешение неоднозначности для локальных запусков
      [ActionName("Index")]
      public ActionResult LocalIndex()
      {
         return View("Result", new Result {ControllerName = "Home", ActionName = "LocalIndex"});
      }

      protected override void HandleUnknownAction(string actionName) // NOTE: Обработка неизвестных действий
      {
         Response.Write(string.Format("You requested the {0} action", actionName));
      }
   }
}