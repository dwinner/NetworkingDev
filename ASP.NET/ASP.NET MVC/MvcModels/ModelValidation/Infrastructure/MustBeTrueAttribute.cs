using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Infrastructure
{
   /// <summary>
   ///    Специальный атрибут проверки достоверности свойства
   /// </summary>
   public class MustBeTrueAttribute : ValidationAttribute
   {
      public override bool IsValid(object value)
      {
         return value is bool && (bool) value;
      }
   }
}