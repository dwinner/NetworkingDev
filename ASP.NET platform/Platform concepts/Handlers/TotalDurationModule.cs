/**
 * Координация между модулями и обработчиками: создание модуля
 */

using System;
using System.Diagnostics;
using System.Web;

namespace Handlers
{
   public class TotalDurationModule : IHttpModule
   {
      public const string TotalTimeKeyName = "total_time";
      private int _requestCount;
      private double _totalTime;

      public void Init(HttpApplication httpApp)
      {
         httpApp.PreRequestHandlerExecute += HandleEvent;
         httpApp.PostRequestHandlerExecute += HandleEvent;
      }

      public void Dispose()
      {
      }

      private void HandleEvent(object sender, EventArgs e)
      {
         var httpApp = sender as HttpApplication;
         if (httpApp != null)
         {
            HttpContext context = httpApp.Context;
            if (!context.IsPostNotification)
            {
               context.Items[TotalTimeKeyName] = _totalTime;
            }
            else if (context.Handler is IRequestDurationData)
            {
               _totalTime = (double)context.Items[TotalTimeKeyName];
               _requestCount++;
               Debug.WriteLine("Total Duration is {0}ms for {1} requests", _totalTime, _requestCount);
            }
         }
      }
   }

   public class TotalDurationHandlerArgs : EventArgs
   {
      public double TotalTime { get; set; }

      public int Requests { get; set; }
   }
}