using GroupBrush.Entity;

namespace GroupBrush.BusinessLogic.Canvases
{
   public interface ICanvasRoomService
   {
      void AddUserToCanvas(string aCanvasId, string aUserName);
      void RemoveUserFromCanvas(string aCanvasId, string aUserName);
      CanvasBrushAction AddBrushAction(string aCanvasId, CanvasBrushAction aBrushData);
      CanvasSnapshot SyncToRoom(string aCanvasId, int aPosition);
   }
}