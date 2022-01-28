using System;
using System.Diagnostics;
using System.Web;

namespace CommonModules
{
   /// <summary>
   /// Модуль, профилирующий время обработки запроса
   /// </summary>
   public class TimerModule : IHttpModule
   {
      public event EventHandler<TimerEventArgs> RequestTimed;

      protected virtual void OnRequestTimed(TimerEventArgs e)
      {
         EventHandler<TimerEventArgs> handler = RequestTimed;
         if (handler != null) handler(this, e);
      }

      private DateTime _startTime;

      public void Init(HttpApplication httpApp)
      {
         httpApp.BeginRequest += HandleEvent;
         httpApp.EndRequest += HandleEvent;
      }

      public void Dispose()
      {
      }

      private void HandleEvent(object sender, EventArgs e)
      {
         var httpApp = sender as HttpApplication;
         if (httpApp != null)
         {
            switch (httpApp.Context.CurrentNotification)
            {
               case RequestNotification.BeginRequest:
                  _startTime = httpApp.Context.Timestamp;
                  break;
               case RequestNotification.EndRequest:
                  double elapsed = DateTime.Now.Subtract(_startTime).TotalMilliseconds;
                  Debug.WriteLine("Duration: {0} {1}ms", httpApp.Request.RawUrl, elapsed);
                  OnRequestTimed(new TimerEventArgs() { Duration = elapsed });
                  break;
            }
         }
      }
   }

   public class TimerEventArgs : EventArgs
   {
      public double Duration { get; set; }
   }
}