using System;
using System.Threading;

namespace WebSampleApp.Services
{
   public class HealthSample : IDisposable
   {
      private bool _isReady;
      private Timer? _timer;

      public bool IsHealthy { get; private set; }
      public bool IsReady => IsHealthy && _isReady;

      public void Dispose() => _timer?.Dispose();

      public void SetHealthy(bool healthy = true)
      {
         if (IsHealthy == healthy)
         {
            return;
         }

         _isReady = false;
         IsHealthy = healthy;

         if (IsHealthy)
         {
            _timer?.Dispose();
            _timer = new Timer(_ => { _isReady = true; }, null, TimeSpan.FromSeconds(10), Timeout.InfiniteTimeSpan);
         }
      }
   }
}