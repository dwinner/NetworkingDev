using System.Collections.Generic;
using System.Web.Mvc;
using MvcSampleApp.Models;

namespace MvcSampleApp.Controllers
{
   public class ViewsDemoController : Controller
   {
      // GET: /ViewsDemo/
      public ActionResult Index()   // Передача данных в представление
      {
         ViewBag.MyData = "Hello from the controller";
         return View();
      }

      // GET: /ViewsDemo/PassingModel
      public ActionResult PassingModel()  // Передача данных в строго типизированное представление
      {
         var menus = new List<Menu>
         {
            new Menu {Id = 1, Text = "Борщ", Price = 6.9, Category = "Main"},
            new Menu {Id = 2, Text = "Салат овошной", Category = "Vegetarian"},
            new Menu {Id = 3, Text = "Мясная жареха", Category = "Main"}
         };

         return View(menus);
      }

      // GET: /ViewsDemo/LayoutSample
      public ActionResult LayoutSample()  // Действие, возвращающее представление в стандартной компоновке
      {
         return View();
      }

      // GET: /ViewsDemo/LayoutUsingSections
      public ActionResult LayoutUsingSections() // Действие, возвращающее представление с определением секции
      {
         return View();
      }

      // GET: /ViewsDemo/UsePartialView1
      public ActionResult UsePartialView1()  // Использование частичных представлений
      {
         return View(new EventsAndMenus());
      }

      // GET /ViewsDemo/UsePartialView2
      public ActionResult UsePartialView2()  // Использование частичных представлений с вызовом действий
      {
         return View();
      }
      
      public ActionResult ShowEvents() // Явное частичное представление
      {
         ViewBag.Title = "Live Events";
         return PartialView(new EventsAndMenus().Events);
      }

      // GET /ViewsDemo/UsePartialView3
      public ActionResult UsePartialView3()  // Вывод частичных представлений через JavaScript
      {
         return View();
      }
   }
}
