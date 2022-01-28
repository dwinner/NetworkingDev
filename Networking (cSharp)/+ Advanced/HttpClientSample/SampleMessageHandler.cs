using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Net.HttpStatusCode;

namespace HttpClientSample
{
   /// <summary>
   ///    Message handler for special handling of http pipeline
   /// </summary>
   public sealed class SampleMessageHandler : HttpClientHandler
   {
      private readonly string _displayMessage;

      public SampleMessageHandler(string displayMessage) => _displayMessage = displayMessage;

      protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
         CancellationToken cancellationToken)
      {
         WriteLine($"In SampleMessageHandler {_displayMessage}");
         return _displayMessage == "error"
            ? Task.FromResult(new HttpResponseMessage(BadRequest))
            : base.SendAsync(request, cancellationToken);
      }
   }
}