using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace ConsoleHosting
{
    public class PingConnection : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            Console.WriteLine("[Connection] Client connected");
            return base.OnConnected(request, connectionId);
        }

        protected override Task OnDisconnected(IRequest request, string connectionId)
        {
            Console.WriteLine("[Connection] Client disconnected");
            return base.OnDisconnected(request, connectionId);
        }

        protected override Task OnReceived(
            IRequest request, string connectionId, string data)
        {
            if (data == "Ping")
            {
                Console.WriteLine("[Connection] Ping received");
                return Connection.Send(
                    connectionId,
                    "Ping received at " + DateTime.Now.ToLongTimeString()
                    );
            }
            return base.OnReceived(request, connectionId, data);
        }
    }
}