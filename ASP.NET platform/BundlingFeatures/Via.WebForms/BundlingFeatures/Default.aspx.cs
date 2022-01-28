using System;
using System.Web.UI;

namespace BundlingFeatures
{
   public partial class Default : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         string selectedColor;
         if (IsPostBack && (selectedColor = Request.Form["color"]) != null)
         {
            selectedValue.InnerText = selectedColor;
         }
      }
   }
}