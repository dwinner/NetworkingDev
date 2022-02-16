using System;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace AuthTokenService
{
   /// <summary>
   ///    WEB-служба аутентификации
   /// </summary>
   [WebService(Namespace = "http://bloodhound.com/")]
   [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
   [ScriptService]
   public class AuthWebService : WebService
   {
      private const string CurrentUserSessionKey = "currentUser";
      public AuthenticationToken AuthenticationTokenHeader;

      [WebMethod(EnableSession = true)]
      public Guid Login(string userName, string password)
      {
         if (userName == "Den" && password == "Winner")
         {
            var currentUser = Guid.NewGuid();
            Session[CurrentUserSessionKey] = currentUser;
            return currentUser;
         }

         Session[CurrentUserSessionKey] = null;
         return Guid.Empty;
      }

      [WebMethod(EnableSession = true)]
      [SoapHeader("AuthenticationTokenHeader", Direction = SoapHeaderDirection.In)]
      public string DoSomethingAuth()
      {
         return Session[CurrentUserSessionKey] != null && AuthenticationTokenHeader != null &&
                AuthenticationTokenHeader.InnerToken == (Guid) Session[CurrentUserSessionKey]
            ? "Auth Ok"
            : "Auth failed";
      }
   }
}