using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace TestableSignalrApp
{
    public class EchoConnection : PersistentConnection
    {
        private IConnectionWrapper _connection;

        public EchoConnection()
        {
            _connection = new ConnectionWrapper(this);
        }

        public EchoConnection(IConnectionWrapper connection)
        {
            _connection = connection;
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            var message = request.User.Identity.IsAuthenticated
                ? request.User.Identity.Name + "> " + data
                : connectionId + "> "+data;
            return _connection.Send(connectionId, message);
        }

        protected override Task OnConnected(IRequest request, string connectionId)
        {
            var newConnMsg = "New connection " + connectionId + "!";
            return _connection.Send("2"+connectionId, "Welcome, dude!")
                                .ContinueWith(_ =>
                                    _connection.Broadcast(newConnMsg)
                                );
        }
    }

}