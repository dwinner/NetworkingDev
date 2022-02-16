using System;
using System.Net;
using System.Web.UI;
using AuthToken.Client.AuthService;
using AuthSvc = AuthToken.Client.AuthService.AuthWebServiceSoapClient;

namespace AuthToken.Client
{
   public partial class Default : Page
   {
      private const string ServiceCookieViewStateKey = "serviceCookie";
      private const string AuthTokenHeaderViewStateKey = "AuthenticationTokenHeader";
      private AuthSvc _authSvc;

      protected void Page_Load(object sender, EventArgs e)
      {
         _authSvc = new AuthSvc();
         var svcCookieContainer = ViewState[ServiceCookieViewStateKey] == null
            ? new CookieContainer()
            : (CookieContainer)ViewState[ServiceCookieViewStateKey];

         _authSvc.CookieContainer = svcCookieContainer;
         var header = new AuthenticationToken
         {
            InnerToken = (Guid?)ViewState[AuthTokenHeaderViewStateKey] ?? Guid.Empty
         };

         _authSvc.AuthenticationTokenValue = header;
      }

      protected void LoginButton_OnClick(object sender, EventArgs e)
      {
         var authTokenHeader = _authSvc.Login(UserNameTextBox.Text, PasswordTextBox.Text);
         TokenLabel.Text = authTokenHeader.ToString();
         if (ViewState[AuthTokenHeaderViewStateKey] != null)
         {
            ViewState.Remove(AuthTokenHeaderViewStateKey);
         }

         ViewState.Add(AuthTokenHeaderViewStateKey, authTokenHeader);
         if (ViewState[ServiceCookieViewStateKey] != null)
         {
            ViewState.Remove(ServiceCookieViewStateKey);
         }

         ViewState.Add(ServiceCookieViewStateKey, _authSvc.CookieContainer);
      }

      protected void InvokeButton_OnClick(object sender, EventArgs e)
      {
         ResultLabel.Text = _authSvc.DoSomethingAuth(_authSvc.AuthenticationTokenValue);
         if (ViewState[ServiceCookieViewStateKey] != null)
         {
            ViewState.Remove(ServiceCookieViewStateKey);
         }

         ViewState.Add(ServiceCookieViewStateKey, _authSvc.CookieContainer);
      }
   }
}