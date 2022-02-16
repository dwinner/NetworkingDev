using System;
using System.Web;

namespace Handlers
{
   /// <summary>
   ///    Специальный обработчик
   /// </summary>
   public class CustomHandler : IHttpHandler
   {
      public bool IsReusable
      {
         get { return true; }
      }

      public void ProcessRequest(HttpContext httpContext)
      {
         string time = DateTime.Now.ToShortTimeString();

         if (httpContext.Request.CurrentExecutionFilePathExtension == ".json")
         {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.Write(string.Format("{{\"time\": \"{0}\"}}", time));
         }
         else
         {
            httpContext.Response.ContentType = "text/html";
            httpContext.Response.Write(string.Format("<span>{0}</span>", time));
         }
      }
   }
}