using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlState.Custom
{
   public class SimpleTime : WebControl
   {
      private bool _stateful;
      private string _timestamp;

      public SimpleTime()
      {
         Load += (sender, args) =>
         {
            if ((_timestamp = ViewState["time"] as string) != null)
            {
               _stateful = true;
            }
            else
            {
               _timestamp = DateTime.Now.ToLongTimeString();
            }
         };

         PreRender += (sender, args) => ViewState["time"] = _timestamp;
      }

      protected override void RenderContents(HtmlTextWriter writer)
      {
         writer.RenderBeginTag(HtmlTextWriterTag.Div);
         writer.Write("Time: {0} ({1})", _timestamp, _stateful ? "State" : "New");
         writer.RenderEndTag();
      }
   }
}