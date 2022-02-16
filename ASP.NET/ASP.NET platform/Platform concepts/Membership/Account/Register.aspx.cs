using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using UserManager = System.Web.Security.Membership;

namespace Membership.Account
{
   public partial class Register : Page
   {
      private const string UsersRoleName = "users";

      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
            return;

         string userName = Request["userName"];
         string userPass = Request["password"];
         string email = Request["email"];
         string question = Request["question"];
         string answer = Request["answer"];

         if (IsAnyEmpty(userName, userPass, email, question, answer))
         {
            ReportError("All fields must be filled");
         }
         else
         {
            MembershipCreateStatus status;
            /*MembershipUser membershipUser =*/
            UserManager.CreateUser(userName, userPass, email, question, answer, true, out status);
            if (status == MembershipCreateStatus.Success)
            {
               if (!Roles.RoleExists(UsersRoleName))
               {
                  Roles.CreateRole(UsersRoleName);
               }

               Roles.AddUserToRole(userName, UsersRoleName);
               FormsAuthentication.SetAuthCookie(userName, false);
               Response.Redirect(FormsAuthentication.LoginUrl);
            }
            else
            {
               ReportError(status.ToString());
            }
         }
      }

      private void ReportError(string errorMessage)
      {
         ErrorMessage.InnerText = string.Format("Error: {0}", errorMessage);
         ErrorPlaceHolder.Visible = true;
      }

      private static bool IsAnyEmpty(params string[] validationStrings)
      {
         return validationStrings.Any(string.IsNullOrEmpty);
      }
   }
}