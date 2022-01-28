using System;
using System.Web.Security;
using System.Web.UI;
using UserManager = System.Web.Security.Membership;

namespace Membership.Account
{
   public partial class Recover : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
            return;

         switch (task.Value)
         {
            case "Next":
               MembershipUser membershipUser = UserManager.GetUser(Request["userName"]);
               if (membershipUser != null)
               {
                  QuestionPlaceHolder.Visible = true;
                  questionLabel.InnerText = membershipUser.PasswordQuestion;
                  if (Request["answer"] != null)
                  {
                     try
                     {
                        string newPass = membershipUser.ResetPassword(Request["answer"]);
                        Session[Change.OldPasswordSessionKey] = newPass;
                        FormsAuthentication.SetAuthCookie(membershipUser.UserName, false);
                        Response.Redirect("/Account/Change.aspx");
                        
                        //UsernamePlaceHolder.Visible = false;
                        //QuestionPlaceHolder.Visible = false;
                        //NewPasswordPlaceHolder.Visible = true;
                        //newPassword.InnerText = newPass;
                        //task.Value = "Log In";
                     }
                     catch (MembershipPasswordException)
                     {
                        ReportError("Wrong answer");
                     }
                  }
               }
               else
               {
                  ReportError("Unknown username");
               }
               break;
            case "Restart":
               Response.Redirect(Request.Path);
               break;
            case "Log In":
               Response.Redirect(FormsAuthentication.LoginUrl);
               break;
            default:
               Response.Redirect(FormsAuthentication.LoginUrl);
               break;
         }
      }

      private void ReportError(string errorMessage)
      {
         message.InnerText = string.Format("Error: {0}", errorMessage);
         ErrorPlaceHolder.Visible = true;
         task.Value = "Restart";
      }
   }
}