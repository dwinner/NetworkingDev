using System.Web.Mvc;
using Emso.WebUi.Infrastructure.ControllerExtensibility;

namespace Emso.WebUi.Controllers
{
   public class RssFeedController : CookieRouteLocalizationController
   {
      public PartialViewResult RssFeed()
      {
         return PartialView("RssFeed");
      }
   }
}