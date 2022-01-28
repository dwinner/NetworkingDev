using System;
using System.Web;

namespace Handlers
{
   /// <summary>
   ///    Реализация специального обобщенного обработчика
   /// </summary>
   public class Time : IHttpHandler, IRequestDurationData
   {
      public void ProcessRequest(HttpContext httpContext)
      {
         string time = DateTime.Now.ToShortTimeString();
         if (IsAjaxRequest(httpContext.Request))
         {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.Write(string.Format("{{\"time\": \"{0}\"}}", time));
         }
         else
         {
            httpContext.Response.ContentType = "text/html";
            httpContext.Response.Write(string.Format("<span>{0}</span>", time));
         }

         const string totalTimeKey = TotalDurationModule.TotalTimeKeyName;
         var totalTime = httpContext.Items[totalTimeKey] as double?;
         if (totalTime != null)
         {
            totalTime += DateTime.Now.Subtract(httpContext.Timestamp).TotalMilliseconds;
            httpContext.Items[totalTimeKey] = totalTime;
         }
      }

      public bool IsReusable
      {
         get { return false; }
      }

      private static bool IsAjaxRequest(HttpRequest request)
      {
         return request.Headers["X-Requested-With"] == "XMLHttpRequest" ||
                request["X-Requested-With"] == "XMLHttpRequest";
      }
   }
}