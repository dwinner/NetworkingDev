using System;
using System.Web.ModelBinding;
using System.Web.Security;
using System.Web.UI;
using FreelanceUnique.Web.Model;
using UserManager = System.Web.Security.Membership;

namespace FreelanceUnique.Web.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var loginVm = new LoginVm();
                if (TryUpdateModel(loginVm, new FormValueProvider(ModelBindingExecutionContext)) &&
                    (UserManager.ValidateUser(loginVm.Username, loginVm.Password) && ModelState.IsValid))
                {
                    FormsAuthentication.RedirectFromLoginPage(loginVm.Username, false);
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