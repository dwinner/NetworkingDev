using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageMapSample
{
   public partial class Default : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      protected void OnCoverShot(object sender, ImageMapEventArgs e)
      {
         PostBackLabel.Text = string.Format("You clicked: {0}", e.PostBackValue);
      }
   }
}