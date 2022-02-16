using System;
using System.Web.UI;

namespace RequestControl
{
   public partial class SxSView : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         var html = Context.Items["htmlResponse"] as string;
         var src = Context.Items["sourceResponse"] as string;
         if (!string.IsNullOrEmpty(html) && !string.IsNullOrEmpty(src))
         {
            HtmlPanel.InnerHtml = html;
            SrcPanel.InnerHtml = src;
         }
      }
   }
}