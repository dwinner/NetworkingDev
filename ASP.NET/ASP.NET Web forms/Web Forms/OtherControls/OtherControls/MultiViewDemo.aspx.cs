using System;
using System.Web.UI;

namespace OtherControls
{
   public partial class MultiViewDemo : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         SampleMv.ActiveViewIndex = nameSelect.SelectedIndex;
      }
   }
}