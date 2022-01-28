using System.Diagnostics;
using System.Threading.Tasks;
using IocUnity.Model;
using Microsoft.AspNet.SignalR;

namespace IocUnity
{
    public class Broadcaster : Hub
    {
        private readonly IMessageFormatter _formatter;

        public Broadcaster(IMessageFormatter formatter)
        {
            Debug.WriteLine("    Creating hub");
            _formatter = formatter;
        }

        public override Task OnConnected()
        {
            var message = _formatter.Format("New connection!");
            return Clients.All.Message(message);
        }

        public Task Broadcast(string message)
        {
            var host = Context.Headers["host"];
            var formattedMsg = _formatter.Format(message + "(from " + host + ")");
            return Clients.All.Message(formattedMsg);
        }

        protected override void Dispose(bool disposing)
        {
            Debug.WriteLine("    Disposing hub");
            if (disposing)
                _formatter.Dispose();
            base.Dispose(disposing);
        }
    }
}