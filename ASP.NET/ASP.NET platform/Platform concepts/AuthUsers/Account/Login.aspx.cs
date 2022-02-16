using System;
using System.Web.Security;
using System.Web.UI;

namespace AuthUsers.Account
{
   public partial class Login : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack)
         {
            string user = Request["user"];
            string pass = Request["pass"];
            string action = Request["action"];
            if (action == "login" && user == "Joe" && pass == "secret")
            {
               FormsAuthentication.RedirectFromLoginPage(user, false);
               //FormsAuthentication.SetAuthCookie(user, false);
            }
            else
            {
               message.Style["visibility"] = "visible";
               //FormsAuthentication.SignOut();
               //Response.Redirect(Request.Path);
            }            
         }

         if (Request.IsAuthenticated)
         {
            Response.StatusCode = 403;
            Response.SuppressContent = true;
            Context.ApplicationInstance.CompleteRequest();
         }
      }

      //protected bool GetRequestStatus()
      //{
      //   return Request.IsAuthenticated;
      //}

      //protected string GetUser()
      //{
      //   return Context.User.Identity.Name;
      //}
   }
}