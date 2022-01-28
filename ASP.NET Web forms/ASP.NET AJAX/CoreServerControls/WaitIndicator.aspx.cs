using System;
using System.Threading;
using System.Web.UI;

namespace CoreServerControls
{
   public partial class WaitIndicator : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      protected void RefreshTimeButton_OnClick(object sender, EventArgs e)
      {
         Thread.Sleep(TimeSpan.FromSeconds(10));
         TimeLabel.Text = DateTime.Now.ToLongTimeString();
      }
   }
}