using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static System.Diagnostics.Debug;

namespace ServerHtmlControls
{
   public partial class SelectForm : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         var htmlSelect = new HtmlSelect { ID = "colorSelect2" };
         htmlSelect.Items.Add(new ListItem { Text = "Red", Value = "red" });
         htmlSelect.Items.Add(new ListItem { Text = "Green", Value = "green", Selected = true });
         htmlSelect.Items.Add(new ListItem { Text = "Blue", Value = "blue" });
         container.Controls.Add(htmlSelect);

         if (IsPostBack)
         {
            WriteLine($"color select: {colorSelect.Value}");
            WriteLine($"selected color: {colorSelect.Items[colorSelect.SelectedIndex].Text}");
            WriteLine($"selected color 2: {Request.Form["colorSelect2"]}");
         }
      }
   }
}