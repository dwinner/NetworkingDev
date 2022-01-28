using System.Diagnostics;
using System.Threading.Tasks;
using HubsSample.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace HubsSample.Hubs
{
   [HubName("FirstHub")]
   public class FirstHub : Hub
   {
      public void BroadcastMessage(Person person)
      {
         Clients.Group(Clients.Caller.GroupName).displayText(person.Name, person.Message); //Clients.All.displayText(person.Name, person.Message);

         // Использование контекста
         Debug.WriteLine(Context.Headers["Date"]);
      }

      public Task Join(string groupName)
      {
         return Groups.Add(Context.ConnectionId, groupName);
      }

      public Task Leave(string groupName)
      {
         return Groups.Remove(Context.ConnectionId, groupName);
      }

      public override Task OnConnected()
      {
         return base.OnConnected();
      }

      public override Task OnDisconnected(bool stopCalled)
      {
         return base.OnDisconnected(stopCalled);
      }

      public override Task OnReconnected()
      {
         return base.OnReconnected();
      }
   }
}