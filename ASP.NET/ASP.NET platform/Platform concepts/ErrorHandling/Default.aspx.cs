using System;
using System.Web.UI;

namespace ErrorHandling
{
   public partial class Default : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack && Request.Form["pageAction"] == "error")
            throw new ArgumentNullException();
      }

      protected void Page_Error(object sender, EventArgs e)
      {
         if (Context.Error is FormatException)
         {
            Response.Redirect(string.Format("/ComponentError.aspx?errorSource={0}&errorType={1}", Request.Path,
               Context.Error.GetType()));
         }
      }
   }
}