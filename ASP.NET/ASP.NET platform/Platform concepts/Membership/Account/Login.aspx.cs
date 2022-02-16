using System;
using System.Web.Security;
using System.Web.UI;
using UserManager = System.Web.Security.Membership;

namespace Membership.Account
{
   public partial class Login : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack)
         {
            string user = Request["userName"];
            string pass = Request["pass"];
            string action = Request["action"];
            if (action == "login" && UserManager.ValidateUser(user, pass))
            {
               FormsAuthentication.RedirectFromLoginPage(user, false);
            }
            else
            {
               message.Style["visibility"] = "visible";
            }
         }
         else if (Request.IsAuthenticated)
         {
            Response.StatusCode = 403;
            Response.SuppressContent = true;
            Context.ApplicationInstance.CompleteRequest();
         }
      }
   }
}