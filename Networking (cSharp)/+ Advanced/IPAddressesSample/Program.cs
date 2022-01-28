using System.Net;
using static System.Console;

namespace IPAddressesSample
{
   public class Program
   {
      public static void Main()
      {
         const string ipAddr = "65.52.128.33";
         IpAddr(ipAddr);
      }

      private static void IpAddr(string ipAddressStr)
      {
         IPAddress address;
         if (!IPAddress.TryParse(ipAddressStr, out address))
         {
            WriteLine("Cannot parse {0}", ipAddressStr);
            return;
         }

         var addressBytes = address.GetAddressBytes();
         foreach (var ipByte in addressBytes)
         {
            WriteLine("Byte {0}", ipByte);
         }

         WriteLine("Family: {0}, Map to ipv6: {1}, Map to ipv4: {2}",
            address.AddressFamily,
            address.MapToIPv6(),
            address.MapToIPv4());

         WriteLine("IPv4 loopback address: {0}", IPAddress.Loopback);
         WriteLine("IPv6 loopback address: {0}", IPAddress.IPv6Loopback);
         WriteLine("IPv4 broadcast address: {0}", IPAddress.Broadcast);
         WriteLine("IPv4 any address: {0}", IPAddress.Any);
         WriteLine("IPv6 any address: {0}", IPAddress.IPv6Any);
      }
   }
}