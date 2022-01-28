using Emso.Configuration;

namespace Emso.WebUi.Controllers
{
   using System.Web.Mvc;

   using Infrastructure.ControllerExtensibility;

   public class OurContactsController : CookieRouteLocalizationController
   {
      private readonly IRecipientCollection _recipients;

      public OurContactsController(IRecipientCollection recipients)
      {
         _recipients = recipients;
      }

      public ActionResult Index()
      {
         return View(_recipients);
      }
   }
}