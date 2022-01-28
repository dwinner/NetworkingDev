using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorkingWithControls
{
   public partial class RepeaterButtons : Page
   {
      private readonly string[] _colors = { "Red", "Green", "Blue" };

      protected void Page_Load(object sender, EventArgs e)
      {
      }

      public IEnumerable<string> GetButtonDetails()
      {
         return _colors;
      }

      protected void HandleClick(object source, RepeaterCommandEventArgs e)
      {
         selectedValue.InnerHtml = string.Format("The {0} button was clicked", ((Button)e.CommandSource).Text);
      }
   }
}