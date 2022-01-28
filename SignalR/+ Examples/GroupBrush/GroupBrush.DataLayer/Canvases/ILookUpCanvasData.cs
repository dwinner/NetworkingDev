using System;

namespace GroupBrush.DataLayer.Canvases
{
   public interface ILookUpCanvasData
   {
      Guid? LookUpCanvas(string aCanvasName);
   }
}