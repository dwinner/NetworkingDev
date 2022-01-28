using System;
using System.Diagnostics;
using System.Web;
using CommonModules;

namespace Events
{
   /// <summary>
   ///    Модуль для измерения среднего времени обработки запроса
   /// </summary>
   public class AverageTimeModule : IHttpModule
   {
      private static double _totalTime;
      private static int _requestCount;
      private static readonly object LockObject = new object();

      public void Init(HttpApplication httpApp)
      {
         for (int i = 0; i < httpApp.Modules.Count; i++)
         {
            if (httpApp.Modules[i] is TimerModule)
            {
               var timerModule = httpApp.Modules[i] as TimerModule;
               timerModule.RequestTimed += (sender, args) => AddNewDataPoint(args.Duration);
               break;
            }
         }
      }

      public void Dispose()
      {
      }

      public event EventHandler<AverageTimeEventArgs> NewAverage;

      protected virtual void OnNewAverage(AverageTimeEventArgs e)
      {
         EventHandler<AverageTimeEventArgs> handler = NewAverage;
         if (handler != null) handler(this, e);
      }

      private void AddNewDataPoint(double duration)
      {
         lock (LockObject)
         {
            double ave = (_totalTime += duration) / (++_requestCount);
            Debug.WriteLine("Average request duration: {0:F2}ms", ave);
            OnNewAverage(new AverageTimeEventArgs { AverageTime = ave });
         }
      }
   }

   public class AverageTimeEventArgs : EventArgs
   {
      public double AverageTime { get; set; }
   }
}