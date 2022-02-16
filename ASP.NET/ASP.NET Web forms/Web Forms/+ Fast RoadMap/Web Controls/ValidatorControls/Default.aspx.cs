using System;
using System.Web.UI;

public partial class Default : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
   }

   protected void postBackButton_Click(object sender, EventArgs e)
   {
      validationCompleteLabel.Text = "You passed validation!";
   }
}