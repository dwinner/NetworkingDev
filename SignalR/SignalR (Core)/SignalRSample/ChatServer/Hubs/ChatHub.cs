using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.SignalR;

namespace ChatServer.Hubs
{
   public class ChatHub : Hub
   {
      public Task Send(string name, string message) =>
         Clients.All.SendAsync("BroadcastMessage", HttpUtility.HtmlEncode(name), HttpUtility.HtmlEncode(message));
   }
}