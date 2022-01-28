using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HttpClientSample
{
   public class LimitCallsHandler : DelegatingHandler
   {
      private readonly int _limitCount;
      private readonly ILogger _logger;
      private int _numberCalls;

      public LimitCallsHandler(IOptions<LimitCallsHandlerOptions> options, ILogger<LimitCallsHandler> logger)
      {
         _limitCount = options.Value.LimitCalls;
         _logger = logger;
      }

      protected override Task<HttpResponseMessage> SendAsync(
         HttpRequestMessage request,
         CancellationToken cancellationToken)
      {
         if (_numberCalls >= _limitCount)
         {
            _logger.LogInformation("limit reached, returning too many requests");
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.TooManyRequests));
         }

         Interlocked.Increment(ref _numberCalls);
         _logger.LogTrace("SendAsync from within LimitCallsHandler");

         return base.SendAsync(request, cancellationToken);
      }
   }
}