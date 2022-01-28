using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace UdpReceiver
{
   public class Receiver
   {
      private readonly string? _groupAddress;
      private readonly ILogger _logger;
      private readonly int _port;
      private readonly bool _useBroadcast;

      public Receiver(IOptions<ReceiverOptions> options, ILogger<Receiver> logger)
      {
         _port = options.Value.Port;
         _groupAddress = options.Value.GroupAddress;
         _useBroadcast = options.Value.UseBroadcast;
         _logger = logger;
      }

      public async Task RunAsync()
      {
         using UdpClient client = new(_port) { EnableBroadcast = _useBroadcast };
         if (_groupAddress != null)
         {
            client.JoinMulticastGroup(IPAddress.Parse(_groupAddress));
            _logger.LogInformation("joining the multicast group {0}", IPAddress.Parse(_groupAddress));
         }

         var completed = false;
         do
         {
            _logger.LogInformation("Waiting to received data");
            var result = await client.ReceiveAsync();
            byte[] datagram = result.Buffer;
            string dataReceived = Encoding.UTF8.GetString(datagram);
            _logger.LogInformation("Received {0} from {1}", dataReceived, result.RemoteEndPoint);
            if (dataReceived.Equals("bye", StringComparison.CurrentCultureIgnoreCase))
            {
               completed = true;
            }
         } while (!completed);

         _logger.LogInformation("Receiver closing");
         if (_groupAddress is not null)
         {
            client.DropMulticastGroup(IPAddress.Parse(_groupAddress));
         }
      }
   }
}