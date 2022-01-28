using System;

namespace GroupBrush.DataLayer.Canvases
{
   public interface ICreateCanvasData
   {
      Guid? CreateCanvas(string aCanvasName, string aDescription);
   }
}