using System.Web.Mvc;

namespace MenuPlanner.Filters
{
   /// <summary>
   /// Фильтр действия
   /// </summary>
   public class LanguageAttribute : ActionFilterAttribute
   {
      public override void OnActionExecuting(ActionExecutingContext filterContext)
      {
         // TODO: Перед вызовом метода действия
         base.OnActionExecuting(filterContext);
      }

      public override void OnActionExecuted(ActionExecutedContext filterContext)
      {
         // TODO: Метод действия завершен
         base.OnActionExecuted(filterContext);
      }

      public override void OnResultExecuting(ResultExecutingContext filterContext)
      {
         // TODO: Метод действия завершен, но результат еще не получен
         base.OnResultExecuting(filterContext);
      }

      public override void OnResultExecuted(ResultExecutedContext filterContext)
      {
         // TODO: Результат получен
         base.OnResultExecuted(filterContext);
      }
   }
}