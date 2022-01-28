using System;
using System.Diagnostics;
using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
   public class HomeController : Controller
   {
      private Stopwatch _timer;

      [Authorize(Users = "admin")] // [CustomAuth(false)]
      public string Index()
      {
         return "This is the index action on the Home controller";
      }

      [GoogleAuth]
      [Authorize(Users = "bob@google.com")]
      public string List()
      {
         return "This is the List action on the Home controller";
      }

      [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")] //[RangeException]
      public string RangeTest(int id)
      {
         if (id > 100)
         {
            return string.Format("The id value is: {0}", id);
         }

         throw new ArgumentOutOfRangeException("id", id, "");
      }

      [CustomAction]
      public string FilterTest()
      {
         return "This is the filter test action";
      }

      [ProfileAction]
      [ProfileResult]
      [ProfileAll]
      public string ProfileTest()
      {
         return "This is the filter test action";
      }

      #region Фильтрация без атрибутов

      protected override void OnActionExecuting(ActionExecutingContext filterContext)
      {
         _timer = Stopwatch.StartNew();
      }

      protected override void OnResultExecuted(ResultExecutedContext filterContext)
      {
         _timer.Stop();
         filterContext.HttpContext.Response.Write(string.Format("<div>Total elapsed time: {0}</div>",
            _timer.Elapsed.TotalSeconds));
      }

      #endregion

   }
}