using System;
using System.Web.UI;

namespace CoreServerControls
{
   public partial class TimerSample : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         DefLabel.Text = DateTime.Now.ToLongTimeString();
      }

      protected void DefTimer_OnTick(object sender, EventArgs e)
      {
         var tickCount = 0;
         if (ViewState["TickCount"] != null)
         {
            tickCount = (int)ViewState["TickCount"];
         }

         tickCount++;
         ViewState["TickCount"] = tickCount;
         if (tickCount > 10)
         {
            DefTimer.Enabled = false;
         }
      }
   }
}