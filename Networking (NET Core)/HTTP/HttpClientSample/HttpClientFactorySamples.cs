using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace HttpClientSample
{
   public class HttpClientFactorySamples
   {
      private readonly HttpClient _httpClient;
      private readonly ILogger _logger;

      public HttpClientFactorySamples(
         IHttpClientFactory httpClientFactory,
         ILogger<HttpClientFactorySamples> logger)
      {
         _httpClient = httpClientFactory.CreateClient("cni");
         _logger = logger;
      }
   }
}