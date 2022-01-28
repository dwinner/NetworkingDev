using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SelfHosted.Srv.EndPoints
{
   public class SamplePersistentConnection : PersistentConnection
   {
      protected override Task OnReceived(IRequest request, string connectionId, string data)
      {
         return Connection.Broadcast(data);
      }
   }
}