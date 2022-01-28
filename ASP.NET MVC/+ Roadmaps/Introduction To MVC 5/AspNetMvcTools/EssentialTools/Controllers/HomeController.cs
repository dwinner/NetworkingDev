using System.Web.Mvc;
using EssentialTools.Models;

namespace EssentialTools.Controllers
{
   public class HomeController : Controller
   {
      private readonly IValueCalculator _calculator;

      private readonly Product[] _products =
      {
         new Product
         {
            Name = "Kayak",
            Category = "Watersports",
            Price = 275M
         },
         new Product
         {
            Name = "Lifejacket",
            Category = "Watersports",
            Price = 48.95M
         },
         new Product
         {
            Name = "Soccer ball",
            Category = "Soccer",
            Price = 19.50M
         },
         new Product
         {
            Name = "Corner flag",
            Category = "Soccer",
            Price = 34.95M
         }
      };

      public HomeController(IValueCalculator calculator)
      {
         _calculator = calculator;
      }

      // GET: Home
      public ActionResult Index()
      {
         var cart = new ShoppingCart(_calculator) { Products = _products };
         var totalValue = cart.CalculateProductTotal();
         return View(totalValue);
      }
   }
}