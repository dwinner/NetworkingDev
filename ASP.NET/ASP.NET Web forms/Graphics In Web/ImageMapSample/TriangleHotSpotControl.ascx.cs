using System;
using System.Web.UI;

namespace ImageMapSample
{
   public partial class TriangleHotSpotControl : /*HotSpot*/UserControl
   {
      private const string WidthViewStateName = "Width";
      private const string HeightViewStateName = "Height";
      private const string XViewStateName = "X";
      private const string YViewStateName = "Y";

      public TriangleHotSpotControl()
      {
         StartInit();
      }

      public int Width
      {
         get { return (int) ViewState[WidthViewStateName]; }
         set { ViewState[WidthViewStateName] = value; }
      }

      public int Height
      {
         get { return (int) ViewState[HeightViewStateName]; }
         set { ViewState[HeightViewStateName] = value; }
      }

      // X, Y - координаты центральной точки

      public int X
      {
         get { return (int) ViewState[XViewStateName]; }
         set { ViewState[XViewStateName] = value; }
      }

      public int Y
      {
         get { return (int) ViewState[YViewStateName]; }
         set { ViewState[YViewStateName] = value; }
      }

      protected string MarkupName
      {
         get { return "polygon"; }
      }

      protected void Page_Load(object sender, EventArgs e)
      {
         StartInit();
      }

      private void StartInit()
      {
         Width = 0;
         Height = 0;
         X = 0;
         Y = 0;
      }

      public string GetCoordinates()
      {
         // Координаты верхней точки
         var topX = X;
         var topY = Y - Height/2;

         // Координаты нижней левой точки
         var bottomLeftX = X - Width/2;
         var bottomLeftY = Y + Height/2;

         // Координаты нижней правой точки
         var bottomRightX = X + Width/2;
         var bottomRigthY = Y + Height/2;

         return
            string.Format("{0},{1},{2},{3},{4},{5}", topX, topY, bottomLeftX, bottomLeftY, bottomRightX, bottomRigthY);
      }
   }
}