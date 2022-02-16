using System;
using System.Web.UI;

namespace OtherControls
{
   public partial class PlaceHolderDemo : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         SamplePh.Visible = show.Checked;
      }
   }
}