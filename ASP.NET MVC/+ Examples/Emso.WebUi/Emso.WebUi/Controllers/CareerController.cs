using System.Web.Mvc;
using Emso.WebUi.Infrastructure.ControllerExtensibility;

namespace Emso.WebUi.Controllers
{
   public class CareerController : CookieRouteLocalizationController
   {
      public ActionResult Index()
      {
         return View();
      }

      public PartialViewResult Default()
      {
         return PartialView();
      }

      public PartialViewResult AsEmployers()
      {
         return PartialView();
      }
   }
}