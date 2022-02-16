using System.Web.Mvc;
using MvcSampleApp.Models;

namespace MvcSampleApp.Controllers
{
   public class SubmitDataController : Controller
   {      
      // GET: /SubmitData/
      public ActionResult Index()   // Действие по умолчанию
      {
         return View();
      }

      // GET /SubmitData/CreateMenu
      public ActionResult CreateMenu() // Получение формы
      {
         return View();
      }

      // POST: /SubmitData/CreateMenu
      [HttpPost]
      public ActionResult CreateMenu(Menu menu) // Отправка формы
      {
         ViewBag.Info = ModelState.IsValid
            ? string.Format("menu created: {0}, Price: {1}, category: {2}", menu.Text, menu.Price, menu.Category)
            : "not valid";

         return View("Index");
      }

      /*[HttpPost]
      public ActionResult CreateMenu(int id, string text, double price, string category)
      {
         var m = new Menu { Id = id, Text = text, Price = price };
         ViewBag.Info = string.Format("menu created: {0}, Price: {1}, category: {2}", m.Text, m.Price, m.Category);
         return View("Index");
      }

      [HttpPost]
      public ActionResult CreateMenu2()
      {
         var m = new Menu();
         UpdateModel(m);
         ViewBag.Info = string.Format("menu created: {0}, Price: {1}, category: {2}", m.Text, m.Price, m.Category);
         return View("Index");
      }*/
   }
}
