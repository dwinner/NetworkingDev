using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace MulticastNetworkUtils
{
   /// <summary>
   ///    Some utils for IP Multicasting
   /// </summary>
   public static class MulticastUtils
   {
      /// <summary>
      ///    Ping 'all-routers.mcast.net' to check if multicast works on the router
      /// </summary>
      /// <returns>true if router supports multicast packets, false - otherwise</returns>
      public static bool IsRouterMulticastEnabled()
      {
         var mcastRouterPing = new Ping();
         var mcastReply = mcastRouterPing.Send("all-routers.mcast.net");
         var mcastStatus = mcastReply.Status;
         var mcastReplyBuffer = mcastReply.Buffer;

         return mcastReplyBuffer.Length > 0 && mcastStatus == IPStatus.Success;
      }

      /// <summary>
      ///    Check if TCPIP6 stack is enabled in Registry
      /// </summary>
      /// <returns>
      ///    true, if HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip6\Parameters\DisabledComponents set to
      ///    0x20, false otherwise
      /// </returns>
      public static bool IsTcpIpv6StackEnabled()
      {
         var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

         // we can only check out TCPIPv6 for Windows
         if (!isWindows)
         {
            return true;
         }

         var disableComp = Registry.LocalMachine.OpenSubKey("SYSTEM")
            ?.OpenSubKey("CurrentControlSet")
            ?.OpenSubKey("Services")
            ?.OpenSubKey("Tcpip6")
            ?.OpenSubKey("Parameters")
            ?.GetValue("DisabledComponents");

         return int.TryParse(disableComp?.ToString(), out var ipv6Value) && ipv6Value == 0x20;
      }

      public static (string mcastIpAddr, uint udpPort) ParseArguments(string[] args)
      {
         const string mcastKey = "mcast_ip";
         const string udpPortKey = "udp_port";
         const char splitChar = '=';
         var usage = $"Usage: dotnet 'entry_dll' {mcastKey}=ip_address {udpPortKey}=port";

         // Parse arguments
         if (args.Length == 2)
         {
            var rawIp = args[0];
            var rawPort = args[1];

            var rawIpArray = rawIp.Split(splitChar, StringSplitOptions.RemoveEmptyEntries);
            var rawPortArray = rawPort.Split(splitChar, StringSplitOptions.RemoveEmptyEntries);

            string mcastIp;
            if (rawIpArray.Length == 2
                && rawIpArray[0].Equals(mcastKey, StringComparison.CurrentCultureIgnoreCase)
                && rawIpArray[1].Length > 0)
            {
               mcastIp = rawIpArray[1].Trim();
            }
            else
            {
               return ExitWithUsage();
            }

            if (rawPortArray.Length != 2 ||
                !rawPortArray[0].Equals(udpPortKey, StringComparison.CurrentCultureIgnoreCase) ||
                !uint.TryParse(rawPortArray[1], out var udpPort))
            {
               return ExitWithUsage();
            }

            return (mcastIp, udpPort);
         }

         return ExitWithUsage();

         (string mcastIpAddr, uint udpPort) ExitWithUsage()
         {
            Console.WriteLine(usage);
            Environment.Exit(1);
            return (string.Empty, 0);
         }
      }

      public static Socket CreateIPv4MCastClientSocket(string mcastIpAddr, uint udpPort)
      {
         var mcastSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
         var receiveIp = new IPEndPoint(IPAddress.Any, (int) udpPort);
         mcastSocket.Bind(receiveIp);

         // Join to the group
         var inputIp = IPAddress.Parse(mcastIpAddr);
         mcastSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership,
            new MulticastOption(inputIp, IPAddress.Any));

         return mcastSocket;
      }

      public static Socket CreateIPv6MCastClientSocket(string mcastIpAddr, int udpPort)
      {
         var mcastSocket = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
         var receiveIp = new IPEndPoint(IPAddress.IPv6Any, udpPort);
         mcastSocket.Bind(receiveIp);

         var inputIp = IPAddress.Parse(mcastIpAddr);
         mcastSocket.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.AddMembership,
            new IPv6MulticastOption(inputIp));

         return mcastSocket;
      }

      public static Socket CreateIPv6MCastServerSocket(string ipv6Address, int udpPort, out IPEndPoint ipEndPoint)
      {
         var mcastSocket = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
         var ipv6Addr = IPAddress.Parse(ipv6Address);
         mcastSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
         //var bindEndPoint = new IPEndPoint(IPAddress.IPv6Any, udpPort);
         //mcastSocket.Bind(bindEndPoint);
         mcastSocket.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.AddMembership,
            new IPv6MulticastOption(ipv6Addr));
         ipEndPoint = new IPEndPoint(ipv6Addr, udpPort);

         return mcastSocket;
      }

      public static Socket CreateIPv4MCastServerSocket(string mcastIpAddr, uint udpPort, out IPEndPoint ipEndPoint)
      {
         // Create IPv4 socket and adapt it for multicasting
         var mcastSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
         var ipv4Addr = IPAddress.Parse(mcastIpAddr);
         mcastSocket.SetSocketOption(
            SocketOptionLevel.IP,
            SocketOptionName.AddMembership,
            new MulticastOption(ipv4Addr));
         mcastSocket.SetSocketOption(
            SocketOptionLevel.IP,
            SocketOptionName.MulticastTimeToLive,
            2);
         ipEndPoint = new IPEndPoint(ipv4Addr, (int)udpPort);

         return mcastSocket;
      }
   }
}