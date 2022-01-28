using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace UdpSender
{
   public class Sender
   {
      private readonly string? _groupAddress;
      private readonly string? _hostName;
      private readonly ILogger _logger;
      private readonly int _port;
      private readonly bool _useBroadcast;
      private readonly bool _useIpv6;

      public Sender(IOptions<SenderOptions> options, ILogger<Sender> logger)
      {
         _logger = logger;
         _port = options.Value.ReceiverPort;
         _hostName = options.Value.HostName;
         _useBroadcast = options.Value.UseBroadcast;
         _groupAddress = options.Value.GroupAddress;
         _useIpv6 = options.Value.UseIpv6;
      }

      private async Task<IPEndPoint?> GetReceiverIpEndPointAsync()
      {
         IPEndPoint? endPoint = null;
         try
         {
            if (_useBroadcast)
            {
               endPoint = new IPEndPoint(IPAddress.Broadcast, _port);
            }
            else if (_hostName != null)
            {
               var hostEntry = await Dns.GetHostEntryAsync(_hostName);
               var address = hostEntry.AddressList.FirstOrDefault(ipAddr =>
                  ipAddr.AddressFamily == (_useIpv6
                     ? AddressFamily.InterNetworkV6
                     : AddressFamily.InterNetwork));
               if (address == null)
               {
                  string IpVersion() => _useIpv6 ? "IPv6" : "IPv4";
                  _logger.LogWarning($"no {IpVersion()} address for {_hostName}");
                  return null;
               }

               endPoint = new IPEndPoint(address, _port);
            }
            else if (_groupAddress != null)
            {
               endPoint = new IPEndPoint(IPAddress.Parse(_groupAddress), _port);
            }
            else
            {
               throw new InvalidOperationException(
                  $"{nameof(_hostName)}, {nameof(_useBroadcast)}, or {nameof(_groupAddress)} must be set");
            }
         }
         catch (SocketException socketEx)
         {
            _logger.LogError(socketEx, socketEx.Message);
         }

         return endPoint;
      }

      public async Task RunAsync()
      {
         var endPoint = await GetReceiverIpEndPointAsync();
         if (endPoint is null)
         {
            return;
         }

         try
         {
            // string localhost = Dns.GetHostName();
            using UdpClient client = new() { EnableBroadcast = _useBroadcast };
            if (_groupAddress is not null)
            {
               client.JoinMulticastGroup(IPAddress.Parse(_groupAddress));
            }

            var completed = false;
            do
            {
               Console.WriteLine($@"{Environment.NewLine}Enter a message or ""bye"" to exit");
               var input = Console.ReadLine();
               if (input is null)
               {
                  continue;
               }

               completed = input.Equals("bye", StringComparison.CurrentCultureIgnoreCase);
               byte[] datagram = Encoding.UTF8.GetBytes(input);
               /*int sent = */
               await client.SendAsync(datagram, datagram.Length, endPoint);
               _logger.LogInformation("Sent datagram using local EP {0} to {1}",
                  client.Client.LocalEndPoint, endPoint);
            } while (!completed);

            if (_groupAddress is not null)
            {
               client.DropMulticastGroup(IPAddress.Parse(_groupAddress));
            }
         }
         catch (SocketException socketEx)
         {
            _logger.LogError(socketEx, socketEx.Message);
         }
      }
   }
}