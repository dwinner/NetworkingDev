using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Emso.WebUi.Infrastructure
{
   public static class CultureHelper
   {
      private static readonly IEnumerable<string> _ValidCultures =
         CultureInfo.GetCultures(CultureTypes.AllCultures).Select(cultureInfo => cultureInfo.Name);

      private static readonly List<string> _ImplementedCultures = new List<string>
      {
         "en",
         "ru"
      };

      static CultureHelper()
      {
         CurrentNeutralCulture = GetNeutralCulture(Thread.CurrentThread.CurrentCulture.Name);
         CurrentCulture = Thread.CurrentThread.CurrentUICulture.Name;
         DefaultCulture = _ImplementedCultures[0];
         IsRightToLeft = Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft;
      }

      public static bool IsRightToLeft { get; private set; }

      public static string DefaultCulture { get; private set; }

      public static string CurrentCulture { get; private set; }

      public static string CurrentNeutralCulture { get; private set; }

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