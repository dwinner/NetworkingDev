namespace Emso.WebUi.Controllers
{
   using System.Web.Mvc;

   using Infrastructure.ControllerExtensibility;

   public class HomeController : CookieRouteLocalizationController
   {      
      public ActionResult Index()
      {
         return View();
      }

      public PartialViewResult BgCarousel()
      {
         return PartialView("BgCarousel");
      }

      public PartialViewResult SummaryFeatures()
      {
         return PartialView("SummaryFeatures");
      }
   }
}