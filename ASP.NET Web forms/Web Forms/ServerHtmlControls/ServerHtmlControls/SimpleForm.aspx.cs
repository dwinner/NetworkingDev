using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using static System.Diagnostics.Debug;

namespace ServerHtmlControls
{
   public partial class SimpleForm : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         foreach (var htmlInputControl in Form.Controls.OfType<HtmlInputControl>())
         {
            WriteLine("Name: {0}, Value: {1}", htmlInputControl.Name, htmlInputControl.Value);
         }
      }
   }
}