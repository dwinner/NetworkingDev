using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace I18n.Web.Infrastructure
{
   using System.Globalization;

   public static class CultureHelper
   {
      private static readonly IEnumerable <string> _ValidCultures =
         CultureInfo.GetCultures(CultureTypes.AllCultures).Select(cultureInfo => cultureInfo.Name);      

      private static readonly List<string> _ImplementedCultures = new List<string>
      {
         "en",
         "ru"
      };      

      public static bool IsRightToLeft
      {
         get { return Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft; }
      }

      public static string DefaultCulture
      {
         get { return _ImplementedCultures[0]; }
      }

      public static string CurrentCulture
      {
         get { return Thread.CurrentThread.CurrentUICulture.Name; }
      }

      public static string CurrentNeutralCulture
      {
         get { return GetNeutralCulture(Thread.CurrentThread.CurrentCulture.Name); }
      }

      public static string GetImplementedCulture(string name)
      {
         return string.IsNullOrEmpty(name)
            ? DefaultCulture
            : (_ValidCultures.Any(clt => clt.Equals(name, StringComparison.InvariantCultureIgnoreCase))
               ? (_ImplementedCultures.Any(clt => clt.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                  ? name
                  : (_ImplementedCultures.FirstOrDefault(culture => culture.StartsWith(GetNeutralCulture(name))) ??
                     DefaultCulture))
               : DefaultCulture);
      }

      private static string GetNeutralCulture(string name)
      {
         return !name.Contains("-") ? name : name.Split('-')[0];
      }
   }
}