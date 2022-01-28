using System;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ServerHtmlControls
{
   public partial class Container : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         //outerDiv.InnerText = "<b>This is the inner div element</b>";
         ProcessContainerControl(outerDiv);
      }

      private void ProcessContainerControl(HtmlContainerControl htmlContainerControl)
      {
         var isLiteral = IsLiteralContent(htmlContainerControl);
         Debug.WriteLine("ID: {0} Literal: {1}, InnerText: {2}", htmlContainerControl.ID, isLiteral,
            isLiteral ? htmlContainerControl.InnerText.Trim() : "N/A");
         foreach (var child in htmlContainerControl.Controls.OfType<HtmlContainerControl>())
         {
            ProcessContainerControl(child);
         }
      }

      private static bool IsLiteralContent(Control control)
         => control.Controls.Count == 1 && control.Controls[0] is LiteralControl;
   }
}