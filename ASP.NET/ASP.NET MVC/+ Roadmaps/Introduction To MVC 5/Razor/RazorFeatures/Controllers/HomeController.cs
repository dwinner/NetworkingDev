using System.Web.Mvc;
using RazorFeatures.Models;

namespace RazorFeatures.Controllers
{
   public class HomeController : Controller
   {
      private readonly Product _demoProduct = new Product
      {
         ProductId = 1,
         Name = "Kayak",
         Description = "A boat for one person",
         Category = "Watersports",
         Price = 275M
      };

      public ActionResult Index()
      {
         return View(_demoProduct);
      }

      public ActionResult NameAndPrice()
      {
         return View(_demoProduct);
      }

      public ActionResult DemoExpression()
      {
         ViewBag.ProductCount = 1;
         ViewBag.ExpressShip = true;
         ViewBag.ApplyDiscount = false;
         ViewBag.Supplier = null;

         return View(_demoProduct);
      }

      public ActionResult DemoArray()
      {
         Product[] array =
         {
            new Product {Name = "Kayak", Price = 275M},
            new Product {Name = "Lifejacket", Price = 48.95M},
            new Product {Name = "Soccer ball", Price = 19.50M},
            new Product {Name = "Corner flag", Price = 34.95M}
         };

         return View(array);
      }
   }
}