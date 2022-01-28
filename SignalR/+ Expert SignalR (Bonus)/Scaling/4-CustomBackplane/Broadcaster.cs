using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace CustomBackplane
{
    public class Broadcaster: Hub
    {
        public override Task OnConnected()
        {
            var host = Context.Headers["host"];
            return Clients.All.Message("New connection at " + host);
        }

        public Task Broadcast(string message)
        {
            var host = Context.Headers["host"];
            return Clients.All.Message(message + " (from " + host + ")");
        }

        public override Task OnDisconnected()
        {
            var host = Context.Headers["host"];
            return Clients.All.Message("Closed connection at " + host);
        }

    }
}