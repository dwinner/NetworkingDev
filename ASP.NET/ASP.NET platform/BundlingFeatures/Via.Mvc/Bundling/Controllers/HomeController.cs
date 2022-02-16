using System.Web.Mvc;
using Bundling.Models;

namespace Bundling.Controllers
{
   public class HomeController : Controller
   {
      public ViewResult MakeBooking()
      {
         return View(new Appointment { ClientName = "Adam", TermsAccepted = true });
      }

      [HttpPost]
      public JsonResult MakeBooking(Appointment appt)
      {
         return Json(appt, JsonRequestBehavior.AllowGet);
      }
   }
}