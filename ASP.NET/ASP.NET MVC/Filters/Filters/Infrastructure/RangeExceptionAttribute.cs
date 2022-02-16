using System;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
   /// <summary>
   ///    Фильтр исключения
   /// </summary>
   public class RangeExceptionAttribute : FilterAttribute, IExceptionFilter
   {
      public void OnException(ExceptionContext filterContext)
      {
         if (!filterContext.ExceptionHandled && filterContext.Exception is ArgumentOutOfRangeException)
         {
            var val = (int)(((ArgumentOutOfRangeException)filterContext.Exception).ActualValue);
            filterContext.Result = new ViewResult { ViewName = "RangeError", ViewData = new ViewDataDictionary<int>(val) };
            //filterContext.Result = new RedirectResult("~/Content/RangeErrorPage.html");
            filterContext.ExceptionHandled = true;
         }
      }
   }
}