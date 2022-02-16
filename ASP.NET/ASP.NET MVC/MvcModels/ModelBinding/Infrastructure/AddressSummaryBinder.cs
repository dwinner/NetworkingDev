using System.Web.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Infrastructure
{
   /// <summary>
   ///    Специальный связыватель модели
   /// </summary>
   public class AddressSummaryBinder : IModelBinder
   {
      public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
      {
         var model = (bindingContext.Model as AddressSummary) ?? new AddressSummary();
         model.City = GetValue(bindingContext, "City");
         model.Country = GetValue(bindingContext, "Country");

         return model;
      }

      private static string GetValue(ModelBindingContext bindingContext, string name)
      {
         name = (bindingContext.ModelName == string.Empty
            ? string.Empty
            : string.Format("{0}.", bindingContext.ModelName)) + name;
         var providerResult = bindingContext.ValueProvider.GetValue(name);
         return providerResult == null || providerResult.AttemptedValue == string.Empty
            ? "<Not specified>"
            : providerResult.AttemptedValue;
      }
   }
}