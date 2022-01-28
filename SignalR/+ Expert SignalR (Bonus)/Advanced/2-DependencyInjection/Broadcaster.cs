using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace DependencyResolver
{
    public class Broadcaster: Hub
    {
        public Broadcaster()
        {
            Debug.WriteLine("####### Creating hub");          
        }
        public override Task OnConnected()
        {
            return Clients.All.Message("New connection!");
        }

        public Task Broadcast(string message)
        {
            return Clients.All.Message(">> " + message);
        }

        protected override void Dispose(bool disposing)
        {
            Debug.WriteLine("####### Disposing hub");
            base.Dispose(disposing);
        }
    }
}