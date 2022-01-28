using System.Net;

namespace AuthToken.Client.AuthService
{
   public partial class AuthWebServiceSoapClient
   {
      public CookieContainer CookieContainer { get; set; }
      public AuthenticationToken AuthenticationTokenValue { get; set; }
   }
}