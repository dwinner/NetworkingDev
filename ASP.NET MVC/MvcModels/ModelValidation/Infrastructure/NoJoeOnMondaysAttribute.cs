using System;
using System.ComponentModel.DataAnnotations;
using ModelValidation.Models;
using ModelValidation.Properties;

namespace ModelValidation.Infrastructure
{
   /// <summary>
   /// Атрибут проверки достоверности для всей модели
   /// </summary>
   public class NoJoeOnMondaysAttribute : ValidationAttribute
   {
      public NoJoeOnMondaysAttribute()
      {
         ErrorMessage = Resources.NoJoeOnMondays;
      }

      public override bool IsValid(object value)
      {
         var app = value as Appointment;
         // Отсутствует модель правильного типа для проверки или
         // нет значений для обязательных свойств ClientName и Date
         return app == null || string.IsNullOrEmpty(app.ClientName) ||
                !(app.ClientName == "Joe" && app.Date.DayOfWeek == DayOfWeek.Monday);  // Или никаких Joe по Понедельникам
      }
   }
}