using System;
using System.Web.UI;

namespace OtherControls
{
   public partial class Default : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      protected void SampleLinkButton_OnClick(object sender, EventArgs e)
      {
         result.InnerText = (int.Parse(result.InnerText) + 1).ToString();
      }
   }
}