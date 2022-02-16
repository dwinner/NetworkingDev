using System;
using System.Web.Mvc;
using ModelValidation.Models;

namespace ModelValidation.Controllers
{
   public class HomeController : Controller
   {
      public ViewResult MakeBooking()
      {
         return View(new Appointment {Date = DateTime.Now});
      }

      [HttpPost]
      public ViewResult MakeBooking(Appointment appt)
      {
         #region Явная проверка достоверности модели

         //if (string.IsNullOrEmpty(appt.ClientName))
         //{
         //   ModelState.AddModelError("ClientName", "Please enter your name");
         //}

         //if (ModelState.IsValidField("Date") && DateTime.Now > appt.Date)
         //{
         //   ModelState.AddModelError("Date", "Please enter a date in the future");
         //}

         //if (!appt.TermsAccepted)
         //{
         //   ModelState.AddModelError("TermsAccepted", "You must accept the terms");
         //}

         //// Ошибки проверки достоверности уровня модели
         //if (ModelState.IsValidField("ClientName") && ModelState.IsValidField("Date") && appt.ClientName == "Joe" &&
         //    appt.Date.DayOfWeek == DayOfWeek.Monday)
         //{
         //   ModelState.AddModelError(string.Empty, "Joe cannot book appointments on Mondays");
         //}         

         #endregion

         return ModelState.IsValid ? View("Completed", appt) : View();
      }

      #region Выполнение удаленной проверки достоверности

      public JsonResult ValidateDate(string date)
      {
         DateTime parsedDate;

         return !DateTime.TryParse(date, out parsedDate)
            ? Json("Please enter a valid date (mm/dd/yyyy)", JsonRequestBehavior.AllowGet)
            : (DateTime.Now > parsedDate
               ? Json("Please enter a date in the future", JsonRequestBehavior.AllowGet)
               : Json(true, JsonRequestBehavior.AllowGet));
      }

      #endregion

   }
}