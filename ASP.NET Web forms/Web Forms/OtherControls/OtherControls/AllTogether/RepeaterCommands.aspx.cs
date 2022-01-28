using System;
using System.Collections.Generic;
using System.Web.UI;

namespace OtherControls.AllTogether
{
   public partial class RepeaterCommands : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         Rep.ItemCommand += (source, args) =>
         {
            if (args.CommandName == "Select")
            {
               selectedValue.InnerText = args.CommandArgument.ToString();
            }
         };
      }

      public IEnumerable<string> GetData()
      {
         return new[]
         {
            "Red",
            "Green",
            "Blue",
            "Black",
            "White"
         };
      }
   }
}