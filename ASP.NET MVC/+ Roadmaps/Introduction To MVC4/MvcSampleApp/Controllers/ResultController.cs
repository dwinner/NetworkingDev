/**
 * Действия, возвращающие результат
 */

using System.Web.Mvc;
using MvcSampleApp.Models;

namespace MvcSampleApp.Controllers
{
   public class ResultController : Controller
   {
      // GET: /Result/
      public ActionResult Index()
      {
         return View();
      }

      public ActionResult ContentDemo()   // Содержимое
      {
         return Content("Hello, World", "text/plain");
      }

      public ActionResult JavaScriptDemo()   // JavaScript
      {
         return JavaScript("<script>function foo { alert('foo'); }</script>");
      }

      public ActionResult JsonDemo()   // JSON
      {
         var menu = new Menu
         {
            Id = 3,
            Text = "Grilled sausage with sauerkraut und potatoes",
            Price = 12.90,
            Category = "Main"
         };

         return Json(menu, JsonRequestBehavior.AllowGet);
      }

      public ActionResult RedirectDemo()  // 301 HTTP Status Code
      {
         return Redirect("http://www.cninnovation.com");
      }

      public ActionResult RedirectRouteDemo()   // 301 К нужному маршруту
      {
         return RedirectToRoute(new { controller = "Home", action = "Hello" });
      }

      public ActionResult FileDemo()   // Файл
      {
         return File("~/Content/Images/Stephanie.jpg", "image/jpg");
      }
   }
}
