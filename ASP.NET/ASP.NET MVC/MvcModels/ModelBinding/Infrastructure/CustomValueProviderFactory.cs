using System;
using System.Globalization;
using System.Web.Mvc;

namespace ModelBinding.Infrastructure
{
   /// <summary>
   ///    Фабрика поставщика значений
   /// </summary>
   public class CustomValueProviderFactory : ValueProviderFactory
   {
      public override IValueProvider GetValueProvider(ControllerContext controllerContext)
      {
         return new CountryValueProvider();
      }

      /// <summary>
      ///    Специальный поставщик значений
      /// </summary>
      private class CountryValueProvider : IValueProvider
      {
         public bool ContainsPrefix(string prefix)
         {
            return prefix.ToLower().IndexOf("country", StringComparison.Ordinal) > -1;
         }

         public ValueProviderResult GetValue(string key)
         {
            return ContainsPrefix(key) ? new ValueProviderResult("USA", "USA", CultureInfo.InvariantCulture) : null;
         }
      }
   }
}