/**
 * Определение IP-адреса по имени хоста
 */

using System;
using System.Net;

namespace ResolveHost
{
   class Program
   {
      static void Main()
      {
         string[] hosts =
            {
                "www.microsoft.com",
                "www.live.com",
                "www.google.com",
                "www.yahoo.com"
            };

         foreach (string host in hosts)
         {
            Console.WriteLine("{0}", host);
            IPAddress[] addresses = Dns.GetHostAddresses(host);   // Note: хост может иметь несколько IP-адресов 
            foreach (IPAddress addr in addresses)
            {
               Console.WriteLine("\t{0}", addr);
            }
            Console.WriteLine();
         }
         Console.ReadKey();
      }
   }
}
