using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MulticastNetworkUtils.MulticastUtils;

namespace AdvancedMulticastReceiver
{
   internal static class MCastReceiver
   {
      private static volatile bool _stop;

      private static void Main(string[] args)
      {
         var (mcastIpAddr, udpPort) = ParseArguments(args);
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

         //var mcastSocket = CreateIPv4MCastClientSocket(mcastIpAddr, udpPort);
         var mcastSocket = CreateIPv6MCastClientSocket(mcastIpAddr, (int) udpPort);
         Task.Run(() =>
         {
            const char nullTerminate = '\0';

            // Receive the data
            while (!_stop)
            {
               var rcvData = new byte[0x400];
               mcastSocket.Receive(rcvData);
               var rcvStr = Encoding.UTF8.GetString(rcvData, 0, rcvData.Length);
               Console.WriteLine(rcvStr.Trim(nullTerminate));
               Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
         });

         Console.ReadKey();
         _stop = true;
      }
   }
}