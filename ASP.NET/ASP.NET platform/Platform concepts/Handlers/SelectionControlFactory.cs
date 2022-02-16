using System;
using System.Web;

namespace Handlers
{
   /// <summary>
   ///    Фабрика для динамического выбора обработчиков
   /// </summary>
   public class SelectionControlFactory : IHttpHandlerFactory
   {
      public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
      {
         return url.ToLower().StartsWith("/time") ? (IHttpHandler) new CurrentTimeHandler() : new CurrentDayHandler();
      }

      public void ReleaseHandler(IHttpHandler handler)
      {
         // Ничего не делать - обработчики не используются повторно
      }

      #region Обработчики

      private class CurrentDayHandler : IHttpHandler
      {
         public void ProcessRequest(HttpContext context)
         {
            context.Response.ContentType = "text/plain";
            context.Response.Write(string.Format("Today is: {0}", DateTime.Now.DayOfWeek));
         }

         public bool IsReusable
         {
            get { return false; }
         }
      }

      private class CurrentTimeHandler : IHttpHandler
      {
         public void ProcessRequest(HttpContext context)
         {
            context.Response.ContentType = "text/plain";
            context.Response.Write(string.Format("The time is: {0}", DateTime.Now.ToShortTimeString()));
         }

         public bool IsReusable
         {
            get { return false; }
         }
      }

      #endregion
   }
}