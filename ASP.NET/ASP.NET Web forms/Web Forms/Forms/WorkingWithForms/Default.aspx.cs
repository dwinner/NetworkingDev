using System;
using System.Web.UI;

namespace WorkingWithForms
{
   public partial class Default : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack)
         {
            result.InnerText = Request.Form["action"] == "click"
               ? "The button was clicked!"
               : "The button was not clicked";
         }
      }
   }
}