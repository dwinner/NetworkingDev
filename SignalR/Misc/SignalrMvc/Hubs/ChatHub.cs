using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using SignalrMvc.Models;

namespace SignalrMvc.Hubs
{
   public class ChatHub : Hub
   {
      private static readonly List<User> Users = new List<User>();

      public void Send(string name, string message) // Отправка сообщений
      {
         Clients.All.addMessage(name, message);
      }

      public void Connect(string userName) // Подключение нового пользователя
      {
         var id = Context.ConnectionId;

         if (Users.All(user => user.ConnectionId != id))
         {
            Users.Add(new User { ConnectionId = id, Name = userName });
            Clients.Caller.onConnected(id, userName, Users); // Посылаем сообщение текущему пользователю
            Clients.AllExcept(id).onNewUserConnected(id, userName);  // Посылаем сообщение всем пользователям, кроме текущего            
         }
      }

      public override Task OnDisconnected(bool stopCalled) // Отключение пользователя
      {
         var item = Users.FirstOrDefault(user => user.ConnectionId == Context.ConnectionId);
         if (item != null)
         {
            Users.Remove(item);
            var connectionId = Context.ConnectionId;
            Clients.All.OnUserDisconnected(connectionId, item.Name);
         }

         return base.OnDisconnected(stopCalled);
      }
   }
}