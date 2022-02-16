using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using WebSampleApp.Services;

namespace WebSampleApp
{
   public class CustomReadyCheck : IHealthCheck
   {
      private readonly HealthSample _healthSample;

      public CustomReadyCheck(HealthSample healthSample) => _healthSample = healthSample;

      public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
         CancellationToken cancellationToken = default) =>
         Task.FromResult(_healthSample.IsReady
            ? HealthCheckResult.Healthy("healthy")
            : HealthCheckResult.Unhealthy("unhealthy"));
   }
}