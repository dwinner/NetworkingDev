/**
 * Выяснение имени хоста и IP-адреса у данного компьютера
 */

using System;
using System.Net;

namespace MyIp
{
   class Program
   {
      static void Main()
      {
         string hostname = Dns.GetHostName();
         Console.WriteLine("Hostname: {0}", hostname);
         IPAddress[] addresses = Dns.GetHostAddresses(hostname);
         foreach (IPAddress ipAddress in addresses)
         {
            Console.WriteLine("IP Address: {0} ({1})", ipAddress, ipAddress.AddressFamily);
         }
         Console.ReadKey();
      }
   }
}
