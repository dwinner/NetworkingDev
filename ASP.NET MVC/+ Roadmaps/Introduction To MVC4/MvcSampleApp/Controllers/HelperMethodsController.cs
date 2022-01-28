using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcSampleApp.Extensions;
using MvcSampleApp.Models;

namespace MvcSampleApp.Controllers
{
   public class HelperMethodsController : Controller
   {
      // GET: /HelperMethods/
      public ActionResult Index()
      {
         return View();
      }

      // GET: /HelperMethods/SimpleHelper
      public ActionResult SimpleHelper()  // Простые вспомогательные методы
      {
         return View();
      }

      // GET: /HelperMethods/HelperWithMenu
      public ActionResult HelperWithMenu()   // Использование данных модели
      {
         var menu = new Menu
         {
            Id = 1,
            Text = "Шниццель из свинины",
            Price = 6.9,
            Date = new DateTime(2012, 10, 5),
            Category = "Main"
         };

         return View(menu);
      }

      // GET: /HelperMethods/StronglyTypedMenu
      public ActionResult StronglyTypedMenu()   // Строго типизированное представление
      {
         var menu = new Menu
         {
            Id = 1,
            Text = "Мясная жареха на сковородке",
            Price = 6.9,
            Date = new DateTime(2012, 10, 5),
            Category = "Main"
         };

         return View(menu);
      }

      // GET: /HelperMethods/Editor
      public ActionResult Editor()  // Расширенные возможности редактора
      {
         var menu = new Menu
         {
            Id = 1,
            Text = "Салат из крабовых палочек",
            Price = 6.9,
            Date = new DateTime(2012, 10, 5),
            Category = "Main"
         };

         return View(menu);
      }

      // GET: /HelperMethods/Display
      public ActionResult Display() // Вывод сразу всех сущностей для модели
      {
         var menu = new Menu
         {
            Id = 1,
            Text = "Салат Цезарь",
            Price = 6.9,
            Date = new DateTime(2012, 10, 5),
            Category = "Main"
         };

         return View(menu);
      }

      // GET: /HelperMethods/HelperList
      public ActionResult HelperList() // Создание списков
      {
         IDictionary<int, string> cars = new Dictionary<int, string>
         {
            {1, "Red Bull Racing"},
            {2, "McLaren"},
            {3, "Lotus"},
            {4, "Ferrari"}
         };

         return View(cars.ToSelectListItems(4));
      }

      // GET: /HelperMethods/EditorList
      public ActionResult EditorList() // Редактор модели
      {
         var menus = new List<Menu>
         {
            new Menu {Id = 1, Text = "Schweinsbraten mit Knödel und Sauerkraut", Price = 6.9, Category = "Main"},
            new Menu {Id = 2, Text = "Erdäpfelgulasch mit Tofu und Gebäck", Price = 6.9, Category = "Vegetarian"},
            new Menu
            {
               Id = 3,
               Text = "Tiroler Bauerngröst'l mit Spiegelei und Krautsalat",
               Price = 6.9,
               Category = "Main"
            }
         };

         return View(menus);
      }

      // GET: /HelperMethods/HelperWithModels
      public ActionResult HelperWithModels() // Редактор модели
      {
         var menus = new List<Menu>
         {
            new Menu {Id = 1, Text = "Schweinsbraten mit Knödel und Sauerkraut", Price = 6.9, Category = "Main"},
            new Menu {Id = 2, Text = "Erdäpfelgulasch mit Tofu und Gebäck", Price = 6.9, Category = "Vegetarian"},
            new Menu
            {
               Id = 3,
               Text = "Tiroler Bauerngröst'l mit Spiegelei und Krautsalat",
               Price = 6.9,
               Category = "Main"
            }
         };

         return View(menus);
      }

      public ActionResult Create()
      {
         throw new NotImplementedException();
      }

      public ActionResult Edit(int id)
      {
         throw new NotImplementedException();
      }

      public ActionResult Details(int id)
      {
         throw new NotImplementedException();
      }

      public ActionResult Delete(int id)
      {
         throw new NotImplementedException();
      }
   }
}
