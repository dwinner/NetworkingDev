using System.Collections.Generic;
using GroupBrush.Entity;

namespace GroupBrush.BusinessLogic.Storage
{
   public interface IMemStorage
   {
      CanvasBrushAction AddBrushAction(string aCanvasId, CanvasBrushAction aBrushData);
      List<CanvasBrushAction> GetBrushActions(string aCanvasId, int currentPosition);
      List<string> GetCanvasUsers(string aCanvasId);
      void AddUserToCanvas(string aCanvasId, string anId);
      void RemoveUserFromCanvas(string aCanvasId, string anId);
      string GetUserName(int anId);
      void StoreUserName(int anId, string aUserName);
   }
}