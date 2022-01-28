using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Binding.Properties;

namespace Binding.Models
{
   [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
   public sealed class Person : IValidatableObject
   {
      [Required(
         ErrorMessageResourceType = typeof(Resources),
         ErrorMessageResourceName = "EnterYourName")]
      [StringLength(
         20,
         MinimumLength = 3,
         ErrorMessageResourceType = typeof(Resources),
         ErrorMessageResourceName = "NameLength")]
      [RegularExpression(
         @"^[A-Za-z\s]+$",
         ErrorMessageResourceType = typeof(Resources),
         ErrorMessageResourceName = "AlphaCharacters")]
      public string Name { get; set; }

      [Required(
         ErrorMessageResourceType = typeof(Resources),
         ErrorMessageResourceName = "EnterYourAge")]
      [Range(
         5,
         100,
         ErrorMessageResourceType = typeof(Resources),
         ErrorMessageResourceName = "AgeRange")]
      public int Age { get; set; }

      public string Cell { get; set; }

      [CustomValidation(typeof(CustomChecks), "CheckZip")]
      public string Zip { get; set; }

      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)  // Самопроверяемая модель
      {
         var errors = new List<ValidationResult>();
         if (Name == "Bob" && Age < 20)
         {
            errors.Add(new ValidationResult($"People called {Name} under {Age} are not allowed"));
         }

         return errors;
      }
   }

   /// <summary>
   ///    Класс для специального метода проверки достоверности
   /// </summary>
   [SuppressMessage("ReSharper", "UnusedMember.Global")]
   public class CustomChecks
   {
      public static ValidationResult CheckZip(string zipCode)
      {
         return zipCode != null && zipCode.ToLower().StartsWith("ny")
            ? ValidationResult.Success
            : new ValidationResult(Resources.NyZip);
      }
   }
}