using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using TestableSignalrApp.Model;

namespace TestableSignalrApp
{
    public class Broadcaster : Hub
    {
        private readonly IDomain _domain;

        public Broadcaster(IDomain domain)
        {
            _domain = domain;
        }

        public override Task OnConnected()
        {
            var host = Context.Headers["host"];
            var id = Context.ConnectionId;
            var message = "New connection " + id + " at " + host;
            return Clients.All.Message(message);
        }

        [Authorize]
        public Task PrivateMessage(string destConnectionId, string text)
        {
            var sender = Context.User.Identity.Name;
            var message = new Message() { Sender = sender, Text = text };

            return Clients.Client(destConnectionId).PrivateMessage(message);
        }

        public Task Broadcast(string message)
        {
            return Clients.All.Message(message);
        }

        public int GetNumber(int a)
        {
            return _domain.GetNumber(a);
        }
    }

    public class Message
    {
        public string Text { get; set; }
        public string Sender { get; set; }
    }
}