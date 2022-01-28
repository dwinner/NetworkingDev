using System;
using GroupBrush.Entity;

namespace GroupBrush.DataLayer.Canvases
{
   public interface IGetCanvasDescriptionData
   {
      CanvasDescription GetCanvasDescription(Guid aCanvasId);
   }
}