using System.Web.Mvc;

namespace Emso.WebUi
{
   /// <summary>
   ///    Class for global filter registration
   /// </summary>
   public static class FilterConfig
   {
      /// <summary>
      ///    Register the global filters
      /// </summary>
      /// <param name="filters">Global filters</param>
      public static void RegisterGlobalFilters(GlobalFilterCollection filters)
      {
         filters.Add(new HandleErrorAttribute());
      }
   }
}