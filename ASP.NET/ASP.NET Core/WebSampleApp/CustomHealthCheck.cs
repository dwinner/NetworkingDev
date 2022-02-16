using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using WebSampleApp.Services;

namespace WebSampleApp
{
   public class CustomHealthCheck : IHealthCheck
   {
      private readonly HealthSample _healthSample;

      public CustomHealthCheck(HealthSample healthSample) => _healthSample = healthSample;

      public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
         CancellationToken cancellationToken = default) =>
         Task.FromResult(_healthSample.IsHealthy
            ? HealthCheckResult.Healthy("healthy")
            : HealthCheckResult.Unhealthy("unhealthy"));
   }
}