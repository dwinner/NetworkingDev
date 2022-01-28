using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace UdpReceiverSample
{
   public class UdpReceiverEntry
   {
      public static void Main(string[] args)
      {
         int port;
         string groupAddress;
         if (!ParseCommandLine(args, out port, out groupAddress))
         {
            ShowUsage();
            return;
         }

         ReaderAsync(port, groupAddress).Wait();
         ReadLine();
      }

      private static async Task ReaderAsync(int port, string groupAddress)
      {
         using (var client = new UdpClient(port))
         {
            IPAddress multicastAddr = null;
            if (groupAddress != null)
            {
               multicastAddr = IPAddress.Parse(groupAddress);
               client.JoinMulticastGroup(multicastAddr);
               WriteLine("Joining the multicast group {0}", multicastAddr);
            }

            var completed = false;
            do
            {
               WriteLine("Starting the receiver");
               var result = await client.ReceiveAsync().ConfigureAwait(false);
               var datagram = result.Buffer;
               var received = Encoding.UTF8.GetString(datagram);
               WriteLine("Received {0}", received);
               if (received == "bye")
               {
                  completed = true;
               }
            }
            while (!completed);

            WriteLine("Receiver closing");

            if (groupAddress != null && multicastAddr != null)
            {
               client.DropMulticastGroup(multicastAddr);
            }
         }
      }

      private static string GetValueForKey(IReadOnlyList<string> args, string key)
      {
         var nextIndex =
            args.Select((arg, index) => new {Arg = arg, Index = index}).SingleOrDefault(a => a.Arg == key)?.Index +
            1;
         return !nextIndex.HasValue ? null : args[nextIndex.Value];
      }

      private static bool ParseCommandLine(IReadOnlyList<string> args,
         out int port,
         out string groupAddress)
      {
         port = 0;
         groupAddress = string.Empty;
         if (args.Count < 2 || args.Count > 5)
         {
            return false;
         }

         if (args.SingleOrDefault(a => a == "-p") == null)
         {
            WriteLine("-p required");
            return false;
         }

         // get port number
         var port1 = GetValueForKey(args, "-p");
         if (port1 == null || !int.TryParse(port1, out port))
         {
            return false;
         }

         // get optional group address
         groupAddress = GetValueForKey(args, "-g");
         return true;
      }

      private static void ShowUsage()
         => WriteLine("Usage: UdpReceiver -p port  [-g groupaddress]");
   }
}