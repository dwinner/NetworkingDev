using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
   public class HomeController : Controller
   {
      private readonly Person[] _personData =
      {
         new Person {PersonId = 1, FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
         new Person {PersonId = 2, FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
         new Person {PersonId = 3, FirstName = "John", LastName = "Smith", Role = Role.User},
         new Person {PersonId = 4, FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
      };

      public ActionResult Index(int id = 0)
      {
         var dataItem = _personData.FirstOrDefault(person => person.PersonId == id);
         var foundPerson = dataItem ?? Person.Empty;
         return View(foundPerson);
      }

      public ActionResult CreatePerson()
      {
         return View(new Person());
      }

      [HttpPost]
      public ActionResult CreatePerson(Person model)
      {
         return View("Index", model);
      }

      public ActionResult DisplaySummary(
         [Bind( /*NOTE: Префикс для поиска модели*/Prefix = "HomeAddress",
            /*NOTE: Исключение свойства из процесса привязки модели*/Exclude = "Country")] AddressSummary summary)
      {
         return View(summary);
      }

      public ActionResult Names(string[] names) // NOTE: Привязка массивов
      {
         names = names ?? new string[0];
         return View(names);
      }

      public ActionResult ColNames(IList<string> names)  // NOTE: Привязка коллекций
      {
         names = names ?? new List<string>();
         return View(names);
      }

      public ActionResult Address(IList<AddressSummary> addresses)   // NOTE: Привязка коллекций специальных типов моделей
      {         
         return View(addresses ?? new List<AddressSummary>());
      }

      #region Вызов привязки моделей вручную

      public ActionResult AddressByHand(FormCollection formData)
      {
         IList<AddressSummary> addresses = new List<AddressSummary>();
         if (TryUpdateModel(addresses, formData))
         {
            return View(addresses);
         }

         throw new NotImplementedException();   // Предоставить пользователю обратную связь

         #region Другой подход

         /*try
         {
            UpdateModel(addresses, formData);
         }
         catch (InvalidOperationException)
         {
            throw new NotImplementedException();   // Предоставить пользователю обратную связь
         }*/

         #endregion
        
      }

      /*public ActionResult AddressByHand()
      {
         IList<AddressSummary> addresses = new List<AddressSummary>();
         IValueProvider valueProvider = new FormValueProvider(ControllerContext); // Ограничение связывателя
         UpdateModel(addresses, valueProvider);
         return View(addresses);
      }*/

      #endregion

   }
}