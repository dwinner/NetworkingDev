using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters
{
   /// <summary>
   ///    Класс регистрации глобальных фильтров
   /// </summary>
   public static class FilterConfig
   {
      public static void RegisterGlobalFilters(GlobalFilterCollection filters)
      {
         filters.Add(new HandleErrorAttribute());
         filters.Add(new ProfileAllAttribute());
      }
   }
}