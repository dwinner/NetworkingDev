using System;
using System.Collections.Generic;
using System.Web.UI;

namespace WorkingWithControls
{
   public partial class HtmlRepeaterButtons : Page
   {
      private readonly string[] _colors = {"Red", "Green","White"};

      protected void Page_Load(object sender, EventArgs e)
      {
         var action = Request.Form["action"];
         if (IsPostBack && action != null)
         {
            selectedValue.InnerText = string.Format("The {0} button was clicked", action);
         }
      }

      public IEnumerable<string> GetButtonDetails()
      {
         return _colors;
      }
   }
}