using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scaffold
{
   public partial class SiteMaster : MasterPage
   {
      private const string AntiXsrfTokenKey = "__AntiXsrfToken";
      private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
      private string _antiXsrfTokenValue;

      protected void Page_Init(object sender, EventArgs e)
      {
         // Код ниже защищает от XSRF-атак
         var requestCookie = Request.Cookies[AntiXsrfTokenKey];
         Guid requestCookieGuidValue;
         if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
         {
            // Использование маркера Anti-XSRF из файла cookie
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
         }
         else
         {
            // Создание нового маркера Anti-XSRF и его сохранение в файле cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
               HttpOnly = true,
               Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
               responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
         }

         Page.PreLoad += master_Page_PreLoad;
      }

      protected void master_Page_PreLoad(object sender, EventArgs e)
      {
         if (!IsPostBack)
         {
            // Задание маркера Anti-XSRF
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
         }
         else
         {
            // Проверка маркера Anti-XSRF
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
               throw new InvalidOperationException("Ошибка проверки маркера Anti-XSRF.");
            }
         }
      }

      protected void Page_Load(object sender, EventArgs e)
      {

      }

      protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
      {
         Context.GetOwinContext().Authentication.SignOut();
      }
   }

}