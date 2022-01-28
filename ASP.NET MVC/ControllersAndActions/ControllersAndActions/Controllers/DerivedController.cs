using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
   public class DerivedController : Controller
   {
      public ActionResult Index()
      {
         ViewBag.Message = "Hello from the DerivedController Index method";
         return View("MyView");
      }

      public ActionResult ProduceOutput()
      {
         return Redirect("/Basic/Index");

         /*if (Server.MachineName == "TINY")
         {
            return new CustomRedirectResult { Url = "/Basic/Index" };
         }

         Response.Write("Controller: Derived, Action: ProduceOutput");
         return null;*/
      }
   }
}