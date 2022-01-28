using System;
using GroupBrush.Entity;

namespace GroupBrush.BusinessLogic.Canvases
{
   public interface ICanvasService
   {
      Guid? CreateCanvas(CanvasDescription aCanvasDescription);
      Guid? LookUpCanvas(string aCanvasName);
   }
}