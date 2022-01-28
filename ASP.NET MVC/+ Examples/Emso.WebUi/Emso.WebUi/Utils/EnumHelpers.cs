using System;
using System.Linq;

namespace Emso.WebUi.Utils
{
   /// <summary>
   ///    Enum extension methods
   /// </summary>
   public static class EnumHelpers
   {
      /// <summary>
      ///    Get enum values
      /// </summary>
      /// <typeparam name="T">Underlying enumeration type</typeparam>
      /// <returns>Enum values</returns>
      public static T[] GetEnumValues<T>()
      {
         if (!typeof (T).IsEnum)
         {
            throw new ArgumentException("enumType", string.Format("{0} is not Enum", typeof(T).FullName));
         }

         var enumValues = typeof (T).GetEnumValues().Cast<T>().ToArray();
         return enumValues;
      }
   }
}