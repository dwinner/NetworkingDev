using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace TestableSignalrApp
{
    public interface IConnectionWrapper
    {
        Task Send(string connectionId, object value);
        Task Broadcast(object value, params string[] excludeConnectionIds);
    }

    public class ConnectionWrapper : IConnectionWrapper
    {
        private readonly PersistentConnection _connection;

        public ConnectionWrapper(PersistentConnection connection)
        {
            _connection = connection;
        }
        public Task Send(string connectionId, object value)
        {
            return _connection.Connection.Send(connectionId, value);
        }

        public Task Broadcast(object value, params string[] excludeConnectionIds)
        {
            return _connection.Connection.Broadcast(value, excludeConnectionIds);
        }
    }
}