using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using FreelanceUnique.Web.Model;
using UserManager = System.Web.Security.Membership;

namespace FreelanceUnique.Web.Admin
{
    public partial class Manage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                return;

            if (Request["unlock"] != null)
            {
                var membershipUser = UserManager.GetUser(Request["unlock"]);
                if (membershipUser != null)
                {
                    membershipUser.UnlockUser();
                }
            }
            else if (Request["delete"] != null)
            {
                var currentUser = UserManager.GetUser();
                if (currentUser != null && Request["delete"] != currentUser.UserName)
                {
                    UserManager.DeleteUser(Request["delete"]);
                }
            }
        }

        public IEnumerable<UserDetails> GetUsers()  // TODO: Следует исключить вошедшего
        {
            return UserManager.GetAllUsers().Cast<MembershipUser>().Select(user => new UserDetails
            {
                Name = user.UserName,
                Email = user.Email,
                Roles = string.Join(", ", Roles.GetRolesForUser(user.UserName)),
                Locked = user.IsLockedOut,
                Online = user.IsOnline
            });
        }
    }
}