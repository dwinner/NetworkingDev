using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace UdpSenderSample
{
   public class UdpSenderEntry
   {
      public static void Main(string[] args)
      {
         int port;
         string hostname;
         bool broadcast;
         string groupAddress;
         bool ipv6;
         if (!ParseCommandLine(args, out port, out hostname, out broadcast, out groupAddress, out ipv6))
         {
            ShowUsage();
            ReadLine();
            return;
         }

         var endPoint = GetIpEndPointAsync(port, hostname, broadcast, groupAddress, ipv6).Result;
         SenderAsync(endPoint, broadcast, groupAddress).Wait();
         WriteLine("Press return to exit...");
         ReadLine();
      }

      private static async Task<IPEndPoint> GetIpEndPointAsync(int port, string hostName, bool broadcast,
         string groupAddress, bool ipv6)
      {
         IPEndPoint endPoint = null;

         try
         {
            if (broadcast)
            {
               endPoint = new IPEndPoint(IPAddress.Broadcast, port);
            }
            else if (hostName != null)
            {
               var hostEntry = await Dns.GetHostEntryAsync(hostName).ConfigureAwait(false);
               var address = ipv6
                  ? hostEntry.AddressList.FirstOrDefault(
                     ipAddress => ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
                  : hostEntry.AddressList.FirstOrDefault(
                     ipAddress => ipAddress.AddressFamily == AddressFamily.InterNetwork);

               if (address == null)
               {
                  Func<string> ipVersion = () => ipv6 ? "IPv6" : "IPv4";
                  WriteLine($"No {ipVersion()} address for {hostName}");
                  return null;
               }

               endPoint = new IPEndPoint(address, port);
            }
            else if (groupAddress != null)
            {
               endPoint = new IPEndPoint(IPAddress.Parse(groupAddress), port);
            }
            else
            {
               throw new InvalidOperationException(
                  $"{nameof(hostName)}, {nameof(broadcast)}, or {nameof(groupAddress)} must be set");
            }
         }
         catch (SocketException socketEx)
         {
            WriteLine(socketEx.Message);
         }

         return endPoint;
      }

      private static async Task SenderAsync(IPEndPoint endPoint, bool broadcast, string groupAddress)
      {
         try
         {
            var localhost = Dns.GetHostName();
            using (var client = new UdpClient {EnableBroadcast = broadcast})
            {
               if (groupAddress != null)
               {
                  client.JoinMulticastGroup(IPAddress.Parse(groupAddress));
               }

               bool completed;
               do
               {
                  WriteLine("Enter a message or bye to exit");
                  var input = ReadLine();
                  WriteLine();
                  completed = input == "bye";
                  var datagram = Encoding.UTF8.GetBytes($"{input} from {localhost}");
                  /*var sent = */
                  await client.SendAsync(datagram, datagram.Length, endPoint).ConfigureAwait(false);
               }
               while (!completed);

               if (groupAddress != null)
               {
                  client.DropMulticastGroup(IPAddress.Parse(groupAddress));
               }
            }
         }
         catch (SocketException socketEx)
         {
            WriteLine(socketEx.Message);
         }
      }

      private static void ShowUsage()
      {
         WriteLine("Usage: UdpSender -p port [-g groupaddress | -b | -h hostname] [-ipv6]");
         WriteLine("\t-p port number\tEnter a port number for the sender");
         WriteLine("\t-g group address\tGroup address in the range 224.0.0.0 to 239.255.255.255");
         WriteLine("\t-b\tFor a broadcast");
         WriteLine("\t-h hostname\tUse the hostname option if the message should be sent to a single host");
      }

      private static bool ParseCommandLine(IReadOnlyList<string> args,
         out int port,
         out string hostname,
         out bool broadcast,
         out string groupAddress,
         out bool ipv6)
      {
         port = 0;
         hostname = string.Empty;
         broadcast = false;
         groupAddress = string.Empty;
         ipv6 = false;
         if (args.Count < 2 || args.Count > 5)
         {
            return false;
         }

         if (args.SingleOrDefault(a => a == "-p") == null)
         {
            WriteLine("-p required");
            return false;
         }

         string[] requiredOneOf = {"-h", "-b", "-g"};
         if (args.Intersect(requiredOneOf).Count() != 1)
         {
            WriteLine("either one (and only one) of -h -b -g required");
            return false;
         }

         // get port number
         var port1 = GetValueForKey(args, "-p");
         if (port1 == null || !int.TryParse(port1, out port))
         {
            return false;
         }

         // get optional host name
         hostname = GetValueForKey(args, "-h");
         broadcast = args.Contains("-b");
         ipv6 = args.Contains("-ipv6");

         // get optional group address
         groupAddress = GetValueForKey(args, "-g");
         return true;
      }

      private static string GetValueForKey(IReadOnlyList<string> args, string key)
      {
         var nextIndex =
            args.Select((arg, index) => new {Arg = arg, Index = index}).SingleOrDefault(a => a.Arg == key)?.Index +
            1;
         return !nextIndex.HasValue ? null : args[nextIndex.Value];
      }
   }
}