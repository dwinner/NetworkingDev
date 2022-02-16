using System.Web.Mvc;
using TemplatedHelpers.Models;

namespace TemplatedHelpers.Controllers
{
   public class HomeController : Controller
   {      
      public ActionResult CreatePerson()
      {
         return View(new Person());
      }

      [HttpPost]
      public ActionResult CreatePerson(Person person)
      {
         return View("DisplayPerson", person);
      }
   }
}