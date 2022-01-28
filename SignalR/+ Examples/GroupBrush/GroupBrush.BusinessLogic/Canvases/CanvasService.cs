using System;
using GroupBrush.DataLayer.Canvases;
using GroupBrush.Entity;

namespace GroupBrush.BusinessLogic.Canvases
{
   public class CanvasService : ICanvasService
   {
      private readonly ICreateCanvasData _createCanvasData;
      private readonly ILookUpCanvasData _lookUpCanvasData;

      public CanvasService(ICreateCanvasData createCanvasData, ILookUpCanvasData lookUpCanvasData)
      {
         _createCanvasData = createCanvasData;
         _lookUpCanvasData = lookUpCanvasData;
      }

      public Guid? CreateCanvas(CanvasDescription aCanvasDescription)
      {
         Guid? canvasId = null;
         if (aCanvasDescription != null && !string.IsNullOrWhiteSpace(aCanvasDescription.Name) &&
             !string.IsNullOrWhiteSpace(aCanvasDescription.Description))
         {
            canvasId = _createCanvasData.CreateCanvas(aCanvasDescription.Name, aCanvasDescription.Description);
         }

         return canvasId;
      }

      public Guid? LookUpCanvas(string aCanvasName)
      {
         Guid? canvasId = null;
         if (!string.IsNullOrWhiteSpace(aCanvasName))
         {
            canvasId = _lookUpCanvasData.LookUpCanvas(aCanvasName);
         }

         return canvasId;
      }
   }
}