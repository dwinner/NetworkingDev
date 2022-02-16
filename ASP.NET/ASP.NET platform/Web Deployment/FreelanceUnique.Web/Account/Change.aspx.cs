using System;
using System.Web.Security;
using System.Web.UI;
using UserManager = System.Web.Security.Membership;

namespace FreelanceUnique.Web.Account
{
   public partial class Change : Page
   {
      public const string OldPasswordSessionKey = "oldpass";

      protected void Page_Load(object sender, EventArgs e)
      {
         UsernamePlaceHolder.Visible = !Request.IsAuthenticated;
         OldPasswordPlaceHolder.Visible = Session[OldPasswordSessionKey] == null;

         if (IsPostBack)
         {
            MembershipUser user = Request.IsAuthenticated
               ? UserManager.GetUser()
               : UserManager.GetUser(Request["userName"]);
            string newPass = Request["firstNewPass"];

            if (user == null || newPass != Request["secondNewPass"] || Server.HtmlEncode(newPass) != newPass)
            {
               ReportError();
            }
            else
            {
               try
               {
                  /*bool changePasswordSuccess =*/
                  user.ChangePassword(
                     (Session[OldPasswordSessionKey] ?? Request["oldPass"]).ToString(), newPass);
                  Session.Remove(OldPasswordSessionKey);
                  FormsAuthentication.SignOut();
                  Response.Redirect(FormsAuthentication.LoginUrl);
               }
               catch (Exception)
               {
                  ReportError();
               }
            }
         }
      }

      private void ReportError()
      {
         message.InnerText = "Error: Unknown username or incorrect/invalid password";
         ErrorPlaceHolder.Visible = true;
      }
   }
}