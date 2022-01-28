using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace Books.Web.Helpers
{
   public static class EnumHelpers
   {
      public static IEnumerable<SelectListItem> GetItems(this Type enumType, int? selectedValue)
      {
         if (!typeof(Enum).IsAssignableFrom(enumType))
         {
            throw new ArgumentException("Type must be an enum");
         }

         string[] names = Enum.GetNames(enumType);
         IEnumerable<int> values = Enum.GetValues(enumType).Cast<int>();
         IEnumerable<SelectListItem> items = names.Zip(values,
            (name, value) => new SelectListItem
            {
               Text = GetName(enumType, name),
               Value = value.ToString(CultureInfo.InvariantCulture),
               Selected = value == selectedValue
            });

         return items;
      }

      private static string GetName(Type enumType, string name)
      {
         DisplayAttribute displayAttribute =
            enumType.GetField(name).GetCustomAttributes(false).OfType<DisplayAttribute>().FirstOrDefault();
         return displayAttribute != null ? displayAttribute.GetName() : name;
      }
   }
}