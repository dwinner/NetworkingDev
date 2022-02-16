using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GraphicsControls.Handlers;

namespace GraphicsControls
{
   public class GradientLabelControl : WebControl
   {
      private const string TextVstName = "Text";
      private const string TextsizeVstName = "TextSize";
      private const string ColorstartVstName = "ColorStart";
      private const string ColorendVstName = "ColorEnd";
      private const string TextcolorVstName = "TextColor";

      public GradientLabelControl()
      {
         Text = string.Empty;
         TextColor = Color.White;
         GradientColorStart = Color.Blue;
         GradientColorEnd = Color.DarkBlue;
         TextSize = 14;
      }

      public string Text
      {
         get { return (string)ViewState[TextVstName]; }
         set { ViewState[TextVstName] = value; }
      }

      public int TextSize
      {
         get { return (int)ViewState[TextsizeVstName]; }
         set { ViewState[TextsizeVstName] = value; }
      }

      public Color GradientColorStart
      {
         get { return (Color)ViewState[ColorstartVstName]; }
         set { ViewState[ColorstartVstName] = value; }
      }

      public Color GradientColorEnd
      {
         get { return (Color)ViewState[ColorendVstName]; }
         set { ViewState[ColorendVstName] = value; }
      }

      public Color TextColor
      {
         get { return (Color)ViewState[TextcolorVstName]; }
         set { ViewState[TextcolorVstName] = value; }
      }

      protected override void RenderContents(HtmlTextWriter writer)
      {
         var context = HttpContext.Current;
         writer.Write("<img src='GradientHandler.grad?{0}={1}&{2}={3}&{4}={5}&{6}={7}&{8}={9}'>",
            GradientLabelHandler.TextQueryString, context.Server.UrlEncode(Text),
            GradientLabelHandler.TextSizeQueryString, TextSize,
            GradientLabelHandler.TextColorQueryString, TextColor.ToArgb(),
            GradientLabelHandler.GradientColorStartQueryString, GradientColorStart.ToArgb(),
            GradientLabelHandler.GradientColorEndQueryString, GradientColorEnd.ToArgb());
      }
   }
}