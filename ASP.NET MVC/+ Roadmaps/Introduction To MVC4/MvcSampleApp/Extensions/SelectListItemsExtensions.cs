using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace MvcSampleApp.Extensions
{
   public static class SelectListItemsExtensions
   {
      public static IEnumerable<SelectListItem> ToSelectListItems(this IDictionary<int, string> dictionary,
         int selectedId)
      {
         return dictionary.Select(pair => new SelectListItem
         {
            Selected = pair.Key == selectedId,
            Text = pair.Value,
            Value = pair.Key.ToString(CultureInfo.InvariantCulture)
         });
      }
   }
}