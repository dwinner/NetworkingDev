using GroupBrush.BusinessLogic.Canvases;
using GroupBrush.BusinessLogic.Users;
using GroupBrush.Entity;
using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace GroupBrush.Web.Hubs
{
   public class CanvasHub : Hub
   {
      private readonly ICanvasRoomService _canvasRoomService;
      private readonly IUserService _userService;

      public CanvasHub(IUserService userService, ICanvasRoomService canvasRoomService)
      {
         _userService = userService;
         _canvasRoomService = canvasRoomService;
      }

      #region Hub-методы

      public void MoveCursor(double x, double y)
      {
         Clients.Group(GetCanvasIdFromQueryString()).MoveOtherCursor(GetUserNameFromContext(), x, y);
      }

      public void SendChatMessage(string message)
      {
         var completeMessage = string.Format("{0}: {1}", GetUserNameFromContext(), message);
         Clients.Group(GetCanvasIdFromQueryString()).UserChatMessage(completeMessage);
      }

      public void SendDrawCommand(CanvasBrushAction brushData)
      {
         var canvasBrushAction = _canvasRoomService.AddBrushAction(GetCanvasIdFromQueryString(), brushData);
         Clients.Group(GetCanvasIdFromQueryString()).DrawCanvasBrushAction(canvasBrushAction);
      }

      public CanvasSnapshot SyncToRoom(int currentPosition)
      {
         return _canvasRoomService.SyncToRoom(GetCanvasIdFromQueryString(), currentPosition);
      }

      #endregion

      #region Инфраструктурные методы

      public override Task OnConnected()
      {
         var canvasId = GetCanvasIdFromQueryString();
         var userName = GetUserNameFromContext();
         _canvasRoomService.AddUserToCanvas(canvasId, userName);
         Groups.Add(Context.ConnectionId, canvasId);
         Clients.Group(canvasId).UserConnected(userName);

         return base.OnConnected();
      }

      public override Task OnDisconnected(bool stopCalled)
      {
         var canvasId = GetCanvasIdFromQueryString();
         var userName = GetUserNameFromContext();
         _canvasRoomService.RemoveUserFromCanvas(canvasId, userName);
         Groups.Remove(Context.ConnectionId, canvasId);
         Clients.Group(canvasId).UserDisconnected(userName);

         return base.OnDisconnected(stopCalled);
      }

      #endregion

      #region Служебные методы

      private string GetCanvasIdFromQueryString()
      {
         Guid validationGuid; // = Guid.Empty;
         var groupId = Context.QueryString["canvasid"];
         if (!string.IsNullOrWhiteSpace(groupId) && Guid.TryParse(groupId, out validationGuid))
         {
            return groupId;
         }

         throw new ArgumentException("Invalid Canvas Id");
      }

      private string GetUserNameFromContext()
      {
         var strUserId = Context.Request.User.Identity.Name;
         int userId;
         return int.TryParse(strUserId, out userId) ? _userService.GetUserNameFromId(userId) : string.Empty;
      }

      #endregion
   }
}