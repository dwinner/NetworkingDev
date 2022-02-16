using System;
using System.Diagnostics;
using System.Web;

namespace CommonModules
{
   /// <summary>
   ///    HTTP-модуль логирования запросов
   /// </summary>
   public class LogModule : IHttpModule
   {
      public void Init(HttpApplication httpApp)
      {
         httpApp.LogRequest += HandleEvent;
      }

      public void Dispose()
      {
         // Ничего не делаем
      }

      private static void HandleEvent(object sender, EventArgs e)
      {
         var httpApp = sender as HttpApplication;
         if (httpApp != null)
         {
            Debug.WriteLine("Request for {0} - code {1}", httpApp.Request.RawUrl, httpApp.Response.StatusCode);
         }
      }
   }
}