using System.Net;
using System.Net.Http.Headers;

public class AuthenticationMessageHandler : DelegatingHandler
{
   private readonly ClientAuthentication _clientAuthentication;

   public AuthenticationMessageHandler(ClientAuthentication clientAuthentication) =>
      _clientAuthentication = clientAuthentication;

   protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
      CancellationToken cancellationToken)
   {
      var token = await _clientAuthentication.GetAccesstokenAsync().ConfigureAwait(false);
      request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
      var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
      if (response.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
      {
         token = await _clientAuthentication.GetAccesstokenAsync(true).ConfigureAwait(false);
         request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
         response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
      }

      return response;
   }
}