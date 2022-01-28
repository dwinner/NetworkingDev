using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace PersistentConnSample.PersistentConnections
{
   public sealed class SamplePersistentConnection : PersistentConnection
   {
      protected override Task OnReceived(IRequest request, string connectionId, string data)
      {
         var groupName = request.QueryString["roomName"];
         return Groups.Send(groupName, data, connectionId);
         //return Connection.Broadcast(data);
      }

      protected override Task OnConnected(IRequest request, string connectionId)
      {
         var groupName = request.QueryString["roomName"];   //request.User.Identity.Name;
         if (!string.IsNullOrWhiteSpace(groupName))
         {
            Groups.Add(connectionId, groupName);
         }

         return base.OnConnected(request, connectionId);
      }

      protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
      {
         var groupName = request.QueryString["roomName"];   //request.User.Identity.Name;
         if (!string.IsNullOrWhiteSpace(groupName))
         {
            Groups.Remove(connectionId, groupName);
         }

         return base.OnDisconnected(request, connectionId, stopCalled);
      }
   }
}