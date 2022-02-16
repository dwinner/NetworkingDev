using System;
using System.Web.UI;
using Events;

namespace PageEvents
{
   public partial class ViewCounter : UserControl
   {
      public event EventHandler<ViewCounterEventArgs> Count;

      private void OnCount(ViewCounterEventArgs e)
      {
         EventHandler<ViewCounterEventArgs> handler = Count;
         if (handler != null)
            handler(this, e);
      }

      protected void Page_Init(object sender, EventArgs e)
      {
         EventCollection.Add(EventSource.Control, "Init");
      }

      protected void Page_Load(object sender, EventArgs e)
      {
         EventCollection.Add(EventSource.Control, "PreRender");
         int count;
         Session["counter"] = count = ((int)(Session["counter"] ?? 0)) + 1;
         OnCount(new ViewCounterEventArgs { Counter = count });
      }

      protected override void Render(HtmlTextWriter writer)
      {
         EventCollection.Add(EventSource.Control, "Render");
         base.Render(writer);
      }

      protected void Page_Unload(object sender, EventArgs e)
      {
         EventCollection.Add(EventSource.Control, "Unload");
      }

      protected int? GetCounter()
      {
         return Session["counter"] as int? ?? 0;
      }
   }

   public class ViewCounterEventArgs : EventArgs
   {
      public int Counter { get; set; }
   }
}