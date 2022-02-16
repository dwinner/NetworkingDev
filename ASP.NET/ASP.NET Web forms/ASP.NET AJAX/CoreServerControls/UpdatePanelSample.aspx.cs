using System;
using System.Web.UI;

namespace CoreServerControls
{
   public partial class UpdatePanelSample : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         FirstLabel.Text = DateTime.Now.ToLongTimeString();
         SecondLabel.Text = DateTime.Now.ToLongTimeString();
         ThirdLabel.Text = DateTime.Now.ToLongTimeString();
      }
   }
}