using System;
using System.Web.ModelBinding;
using System.Web.Security;
using System.Web.UI;
using FreelanceUnique.Web.Model;
using UserManager = System.Web.Security.Membership;

namespace FreelanceUnique.Web.Account
{
    public partial class Register : Page
    {
        private const string UsersRoleName = "users"; // NOTE: Извлечь эту инфу из конфига

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                return;

            var registerVm = new RegisterVm();
            if (!TryUpdateModel(registerVm, new FormValueProvider(ModelBindingExecutionContext)))
                return;

            if (registerVm.Password != registerVm.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Пароли не совпадают");
            }
            else
            {
                MembershipCreateStatus status;
                var membershipUser =
                    UserManager.CreateUser(
                        registerVm.Username, registerVm.Password, registerVm.Email, null, null, true, out status);
                if (status == MembershipCreateStatus.Success && membershipUser != null && ModelState.IsValid)
                {
                    Roles.AddUserToRole(membershipUser.UserName, UsersRoleName);
                    FormsAuthentication.SetAuthCookie(membershipUser.UserName, false);
                    Response.Redirect("~/Default.aspx");
                }
                else
                {                    
                    ModelState.AddModelError(string.Empty,
                        string.Format("Создание пользователя завершилось неудачей. Возможная причина: {0}", status));
                }
            }
        }
    }
}