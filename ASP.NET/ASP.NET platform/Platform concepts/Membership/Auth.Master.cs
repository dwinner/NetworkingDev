using System;
using System.Web.Security;
using System.Web.UI;

namespace Membership
{
   public partial class Auth : MasterPage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
         {
            if (Request.IsAuthenticated)
            {
               authAction.InnerText = "Log Out";
            }
            else
            {
               authGreeting.Visible = false;
               authAction.InnerText = "Log In";
            }
         }
         else if (IsPostBack && Request["authAction"] == "auth")
         {
            if (Request.IsAuthenticated)
            {
               FormsAuthentication.SignOut();
               Response.Redirect(Request.Path);
            }
            else
            {
               FormsAuthentication.RedirectToLoginPage();
            }
         }
      }

      protected string GetGreeting()
      {
         return string.Format("Hello, {0}!", Context.User.Identity.Name);
      }
   }
}