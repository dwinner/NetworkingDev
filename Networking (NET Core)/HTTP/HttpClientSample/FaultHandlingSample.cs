using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HttpClientSample
{
   public class FaultHandlingSample
   {
      private readonly ILogger _logger;
      private readonly HttpClient _httpClient;
      private readonly string _url;

      public FaultHandlingSample(
         IOptions<HttpClientSampleOptions> options,
         HttpClient httpClient,
         ILogger<HttpClientSamples> logger)
      {
         _logger = logger;
         _url = options.Value.InvalidUrl ?? "localhost:5052";
         _httpClient = httpClient;
      }

      public async Task RunAsync()
      {
         try
         {
            var response = await _httpClient.GetAsync(_url);
            response.EnsureSuccessStatusCode();
            Console.WriteLine($"Response Status Code: {(int)response.StatusCode} {response.ReasonPhrase}");
         }
         catch (HttpRequestException httpReqEx)
         {
            _logger.LogError(httpReqEx, httpReqEx.Message);
         }
      }
   }
}