using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using Membership.AppCode;
using UserManager = System.Web.Security.Membership;

namespace Membership.Admin
{
   public partial class Manage : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
            return;

         if (Request["unlock"] != null)
         {
            MembershipUser membershipUser = UserManager.GetUser(Request["unlock"]);
            if (membershipUser != null)
            {
               membershipUser.UnlockUser();
            }
         }
         else if (Request["delete"] != null)
         {
            MembershipUser currentUser = UserManager.GetUser();
            if (currentUser != null && Request["delete"] != currentUser.UserName)
            {
               UserManager.DeleteUser(Request["delete"]);
            }
         }
      }

      public IEnumerable<UserDetails> GetUsers()
      {
         return UserManager.GetAllUsers().Cast<MembershipUser>().Select(user => new UserDetails
         {
            Name = user.UserName,
            Roles = string.Join(", ", Roles.GetRolesForUser(user.UserName)),
            Locked = user.IsLockedOut,
            Online = user.IsOnline
         });
      }
   }
}