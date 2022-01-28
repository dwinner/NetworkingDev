using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AjaxHelpers.Models;

namespace AjaxHelpers.Controllers
{
   public class PeopleController : Controller
   {
      private readonly Person[] _personData =
      {
         new Person {FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
         new Person {FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
         new Person {FirstName = "John", LastName = "Smith", Role = Role.User},
         new Person {FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
      };

      public ActionResult Index()
      {
         return View();
      }

      public ActionResult GetPeople(string selectedRole = "All")
      {
         return View((object) selectedRole);
      }

      public PartialViewResult GetPeopleData(string selectedRole = "All")  // Данные в виде разметки из частичного представления
      {
         return PartialView(GetData(selectedRole));
      }

      private IEnumerable<Person> GetData(string selectedRole) // Получение данных
      {
         IEnumerable<Person> data = _personData;
         if (selectedRole != "All")
         {
            var selected = (Role) Enum.Parse(typeof (Role), selectedRole);
            data = _personData.Where(person => person.Role == selected);
         }

         return data;
      }

      public JsonResult GetPeopleDataJson(string selectedRole = "All")  // Данные в JSON-формате
      {
         var data = GetData(selectedRole).Select(person => new
         {
            person.FirstName,
            person.LastName,
            Role = Enum.GetName(typeof (Role), person.Role)
         });

         return Json(data, JsonRequestBehavior.AllowGet);
      }

      #region Поддержка нескольких форматов данных

      public ActionResult GetPeopleDataMix(string selectedRole = "All")
      {
         IEnumerable<Person> data = _personData;
         if (selectedRole!="All")
         {
            var selected = (Role) Enum.Parse(typeof (Role), selectedRole);
            data = _personData.Where(person => person.Role == selected);
         }

         if (Request.IsAjaxRequest())
         {
            var formattedData = data.Select(person => new
            {
               person.FirstName,
               person.LastName,
               Role = Enum.GetName(typeof (Role), person.Role)
            });

            return Json(formattedData, JsonRequestBehavior.AllowGet);
         }

         return PartialView(data.ToString());
      }

      #endregion
   }
}