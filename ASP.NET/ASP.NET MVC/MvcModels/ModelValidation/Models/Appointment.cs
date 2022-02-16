using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ModelValidation.Infrastructure;
using ModelValidation.Properties;

namespace ModelValidation.Models
{
   [NoJoeOnMondays]
   public class Appointment //: IValidatableObject
   {
      [Required]
      [StringLength(10, MinimumLength = 3)]
      public string ClientName { get; set; }

      [DataType(DataType.Date)]
      [FutureDate(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "EnterDate")]
      [Remote("ValidateDate", "Home")]
      public DateTime Date { get; set; }

      //[Range(typeof (bool), "true", "true", ErrorMessageResourceType = typeof (Resources),
      //   ErrorMessageResourceName = "AccepTerms")]
      [MustBeTrue(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "AcceptTerms")]
      public bool TermsAccepted { get; set; }

      #region Определение самопроверяемой модели

      //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      //{
      //   var errors = new List<ValidationResult>();

      //   if (string.IsNullOrEmpty(ClientName))
      //   {
      //      errors.Add(new ValidationResult("Please enter your name"));
      //   }

      //   if (DateTime.Now > Date)
      //   {
      //      errors.Add(new ValidationResult("Please enter a date in the future"));
      //   }

      //   if (errors.Count == 0 && ClientName == "Joe" && Date.DayOfWeek == DayOfWeek.Monday)
      //   {
      //      errors.Add(new ValidationResult("Joe cannot appointments on Mondays"));
      //   }

      //   if (!TermsAccepted)
      //   {
      //      errors.Add(new ValidationResult("You must accept the terms"));
      //   }

      //   return errors;
      //}

      #endregion
   }
}