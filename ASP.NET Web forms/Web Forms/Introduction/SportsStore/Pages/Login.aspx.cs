using System;
using System.Web.Security;
using System.Web.UI;

namespace SportsStore.Pages
{
   public partial class Login : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack)
         {
            string name = Request.Form["name"];
            string password = Request.Form["password"];
            if (name != null && password != null && FormsAuthentication.Authenticate(name, password))
            {
               FormsAuthentication.SetAuthCookie(name, false);
               Response.Redirect(Request["ReturnUrl"] ?? "/");
            }
            else
            {
               ModelState.AddModelError("fail", "Login failed. Please try again");
            }
         }
      }
   }
}