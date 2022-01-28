using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Filters.Infrastructure
{
   /// <summary>
   ///    Атрибут, переопределяющий фильтр IActionFilter
   /// </summary>
   [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
   public class CustomOverrideActionFiltersAttribute : FilterAttribute, IOverrideFilter
   {
      public Type FiltersToOverride
      {
         get { return typeof(IActionFilter); }
      }
   }
}