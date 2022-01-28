/**
 * Advanced multicast sender.
 * Usage: dotnet AdvancedMulticastSender.dll mcast_ip=ip_address udp_port=port
 *        i.e. dotnet AdvancedMulticastSender.dll mcast_ip=224.5.6.7 udp_port=4567
 */

using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using static MulticastNetworkUtils.MulticastUtils;

namespace AdvancedMulticastSender
{
   internal static class MCastSender
   {
      private static volatile bool _stop;

      private static void Main(string[] args)
      {
         var (mcastIpAddr, udpPort) = ParseArguments(args);

         // Check IPv6 stack
         var tcpIpv6StackEnabled = IsTcpIpv6StackEnabled();
         if (!tcpIpv6StackEnabled)
         {
            Console.Error.WriteLine(
               "Please set value '{0:D}' in 'HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip6\\Parameters\\DisabledComponents' to enable IPv6",
               0x20);

            return;
         }

         var isMcastEnabled = IsRouterMulticastEnabled();
         if (!isMcastEnabled)
         {
            Console.WriteLine("Your router doesn't support multicast packets");
            return;
         }

         //var mcastSocket = CreateIPv4MCastServerSocket(mcastIpAddr, udpPort, out var ipEndPoint);
         var mcastSocket = CreateIPv6MCastServerSocket(mcastIpAddr, (int) udpPort, out var ipEndPoint);
         mcastSocket.Connect(ipEndPoint); // Connect the socket

         // Transfer some data to the group
         var someData = new byte[10];
         for (var i = 0; i < someData.Length; i++)
         {
            someData[i] = (byte) (i + 65);
         }

         Task.Run(() =>
         {
            while (!_stop)
            {
               mcastSocket.Send(someData, someData.Length, SocketFlags.None);
               Console.WriteLine("Sending one more time...");
               Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
         });

         Console.ReadKey();
         _stop = true;
      }
   }
}