using System;
using System.Web.UI;

namespace WorkingWithControls
{
   public partial class Default : Page
   {      
      protected void Page_Load(object sender, EventArgs e)
      {
         var countVal = (int) (Session["counter"] ?? 0);
         if (IsPostBack)
         {
            Session["counter"] = ++countVal;
         }
         
         counter.InnerText = countVal.ToString();         
         ControlUtils.AddButtonClickHandlers(this, ControlUtils.ButtonAction);
      }

      protected void UiButton_OnClick(object sender, EventArgs e)
      {
         var count = (int) (Session["ui_counter"] ?? 0);
         Session["ui_counter"] = ++count;
         UiLabel.Text = count.ToString();
      }
   }
}