using System;
using System.Web.Security;
using System.Web.UI;

namespace FreelanceUnique.Web
{
    public partial class Auth : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoggedInPlaceholder.Visible = Request.IsAuthenticated;
                AnonymPlaceHolder.Visible = !LoggedInPlaceholder.Visible;
                AuthLinkButton.Text = Request.IsAuthenticated ? "Выход" : string.Empty/*"Вход"*/;
            }
        }

        protected string GetGreeting()
        {
            return string.Format("Привет, {0}!", Context.User.Identity.Name);
        }

        protected void AuthLinkButton_OnClick(object sender, EventArgs e)
        {            
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Response.Redirect(Request.Path);
            }
            else
            {
                Response.Redirect(FormsAuthentication.LoginUrl);
            }
        }
    }
}