using System.Web.Mvc;
using Emso.WebUi.Infrastructure.ControllerExtensibility;

namespace Emso.WebUi.Controllers
{
   public class NavigationController : CookieRouteLocalizationController
   {
      public PartialViewResult HeaderBar()
      {
         return PartialView("HeaderBar");
      }

      public PartialViewResult LinkBar()
      {
         return PartialView("LinkBar");
      }

      public PartialViewResult FooterBar()
      {
         return PartialView("FooterBar");
      }
   }
}