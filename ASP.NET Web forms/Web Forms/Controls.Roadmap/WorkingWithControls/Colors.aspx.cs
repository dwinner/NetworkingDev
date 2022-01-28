using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WorkingWithControls
{
   public partial class Colors : Page
   {
      private readonly string[] _colors = { "Red", "Green", "Blue" };

      protected void Page_Load(object sender, EventArgs e)
      {
         var genericControl = FindControl("buttonTarget") as HtmlGenericControl;
         if (genericControl == null)
            return;

         foreach (var newButton in _colors.Select(text => new Button { Text = text, EnableViewState = false }))
         {
            genericControl.Controls.Add(newButton);
         }
         
         ControlUtils.AddButtonClickHandlers(this, ControlUtils.ButtonAction);
      }
   }
}