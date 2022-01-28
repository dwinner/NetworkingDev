using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using PersistentConMvc.Models;

namespace PersistentConMvc.Connection
{
   public class ChatConnection : PersistentConnection
   {
      protected override Task OnConnected(IRequest request, string connectionId)
      {
         var messageData = new MessageData
         {
            Name = "Server message",
            Message = string.Format("User {0} enter the room", connectionId)
         };

         return Connection.Broadcast(messageData);
      }

      protected override Task OnReceived(IRequest request, string connectionId, string data)
      {
         var messageData = JsonConvert.DeserializeObject<MessageData>(data);
         return Connection.Broadcast(messageData);
      }

      protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
      {
         var messageData = new MessageData
         {
            Name = "Server message",
            Message = string.Format("User {0} left the room", connectionId)
         };

         return Connection.Broadcast(messageData);
         //return base.OnDisconnected(request, connectionId, stopCalled);
      }
   }
}