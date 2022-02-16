using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ServerHtmlControls
{
   public partial class CreateForm : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         var inputText = new HtmlInputText { ID = "name", Value = "Bob" };
         nameDiv.Controls.Add(inputText);

         var inputPassword = new HtmlInputPassword { ID = "pass", Value = "secret" };
         passDiv.Controls.Add(inputPassword);

         hiddenAndButtonDiv.InnerHtml = "<input id=\"button\" type=\"submit\" value=\"Submit\" />";
         var inputHidden = new HtmlInputHidden { ID = "hiddenValue", Value = "true" };

         hiddenAndButtonDiv.Controls.Add(inputHidden);
      }
   }
}