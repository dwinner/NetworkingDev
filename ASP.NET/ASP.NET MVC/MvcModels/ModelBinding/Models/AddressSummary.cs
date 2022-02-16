using System.Web.Mvc;
using ModelBinding.Infrastructure;

namespace ModelBinding.Models
{
   //[Bind(Include = "City")]   // NOTE: Избирательная привязка свойств
   [ModelBinder(typeof(AddressSummaryBinder))]  // NOTE: Регистрация специального связывателя модели с помощью атрибута
   public class AddressSummary
   {
      public string City { get; set; }
      public string Country { get; set; }
   }
}