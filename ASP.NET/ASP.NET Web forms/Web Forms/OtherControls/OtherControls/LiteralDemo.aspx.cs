using System;
using System.Web.UI;

namespace OtherControls
{
   public partial class LiteralDemo : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack && colorInput.Value != string.Empty)
         {
            colorLiteral.Text = colorInput.Value;
         }
      }
   }
}