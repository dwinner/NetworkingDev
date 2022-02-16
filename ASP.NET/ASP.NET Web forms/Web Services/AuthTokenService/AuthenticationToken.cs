using System;
using System.Web.Services.Protocols;

namespace AuthTokenService
{
   /// <summary>
   /// Токен аутентификации в виде SOAP-заголовка
   /// </summary>
   public sealed class AuthenticationToken : SoapHeader
   {
      public Guid InnerToken { get; set; }
   }
}