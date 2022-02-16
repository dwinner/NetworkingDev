using System.Web.Mvc;

namespace Filters.Infrastructure
{
   /// <summary>
   ///    Специальный фильтр действия
   /// </summary>
   public class CustomActionAttribute : FilterAttribute, IActionFilter
   {
      public void OnActionExecuting(ActionExecutingContext filterContext)
      {
         if (filterContext.HttpContext.Request.IsLocal)
         {
            filterContext.Result = new HttpNotFoundResult();
         }
      }

      public void OnActionExecuted(ActionExecutedContext filterContext)
      {
         //throw new System.NotImplementedException();
      }
   }
}