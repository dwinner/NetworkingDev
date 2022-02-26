using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.SignalR;

namespace ChatServer.Hubs
{
   public class GroupChatHub : Hub<IGroupClient>
   {
      public Task AddGroup(string groupName)
         => Groups.AddToGroupAsync(Context.ConnectionId, groupName);

      public Task LeaveGroup(string groupName)
         => Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

      public Task Send(string group, string name, string message) =>
         Clients.Group(group).MessageToGroup(group, HttpUtility.HtmlEncode(name), HttpUtility.HtmlEncode(message));
   }
}