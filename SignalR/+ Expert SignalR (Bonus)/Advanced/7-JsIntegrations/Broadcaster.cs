using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace JsIntegrations
{
    public class Broadcaster : Hub
    {
        public override Task OnConnected()
        {
            return Clients.All.Message("New connection " + Context.ConnectionId);
        }
        public Task Broadcast(string message)
        {
            return Clients.All.Message(Context.ConnectionId + "> " + message);
        }
    }
}