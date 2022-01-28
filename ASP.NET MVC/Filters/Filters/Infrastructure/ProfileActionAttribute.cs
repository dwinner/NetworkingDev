using System.Diagnostics;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
   /// <summary>
   ///    Фильтр для измерения времени выполнения метода действия
   /// </summary>
   public class ProfileActionAttribute : FilterAttribute, IActionFilter
   {
      private Stopwatch _timer;

      public void OnActionExecuting(ActionExecutingContext filterContext)
      {
         _timer = Stopwatch.StartNew();
      }

      public void OnActionExecuted(ActionExecutedContext filterContext)
      {
         _timer.Stop();
         if (filterContext.Exception == null)
         {
            filterContext.HttpContext.Response.Write(string.Format("<div>Action method elapsed time: {0:F6}</div>",
               _timer.Elapsed.TotalSeconds));
         }
      }
   }
}