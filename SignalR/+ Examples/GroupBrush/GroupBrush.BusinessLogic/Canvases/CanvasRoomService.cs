using System;
using System.Collections.Generic;
using GroupBrush.BusinessLogic.Storage;
using GroupBrush.DataLayer.Canvases;
using GroupBrush.Entity;

namespace GroupBrush.BusinessLogic.Canvases
{
   public class CanvasRoomService : ICanvasRoomService
   {
      private readonly IMemStorage _memStorage;
      private readonly IGetCanvasDescriptionData _canvasDescriptionData;

      public CanvasRoomService(IMemStorage memStorage, IGetCanvasDescriptionData canvasDescriptionData)
      {
         _memStorage = memStorage;
         _canvasDescriptionData = canvasDescriptionData;
      }

      public void AddUserToCanvas(string aCanvasId, string aUserName)
      {
         _memStorage.AddUserToCanvas(aCanvasId, aUserName);
      }

      public void RemoveUserFromCanvas(string aCanvasId, string aUserName)
      {
         _memStorage.RemoveUserFromCanvas(aCanvasId, aUserName);
      }

      public CanvasBrushAction AddBrushAction(string aCanvasId, CanvasBrushAction aBrushData)
      {
         return _memStorage.AddBrushAction(aCanvasId, aBrushData);
      }

      public CanvasSnapshot SyncToRoom(string aCanvasId, int aPosition)
      {
         var canvasDescription = _canvasDescriptionData.GetCanvasDescription(Guid.Parse(aCanvasId));
         var actions = new List<CanvasBrushAction>(_memStorage.GetBrushActions(aCanvasId, aPosition));
         var users = new List<string>(_memStorage.GetCanvasUsers(aCanvasId));
         return new CanvasSnapshot()
         {
            Users=users,
            Actions = actions,
            CanvasName = canvasDescription.Name,
            CanvasDescription = canvasDescription.Description
         };
      }
   }
}