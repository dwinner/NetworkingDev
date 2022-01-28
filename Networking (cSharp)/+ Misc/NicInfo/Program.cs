/**
 * Выяснение информации о сетевой карте
 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace NicInfo
{
   class Program
   {
      static void Main()
      {
         NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
         foreach (NetworkInterface @interface in nics)
         {
            // В принципе, вместе лишь опрашивается несколько свойств
            Console.WriteLine("ID: {0}", @interface.Id);
            Console.WriteLine("Name: {0}", @interface.Name);
            Console.WriteLine("Description: {0}", @interface.Description);
            Console.WriteLine("Type: {0}", @interface.NetworkInterfaceType);
            Console.WriteLine("Status: {0}", @interface.OperationalStatus);
            Console.WriteLine("Speed: {0}", @interface.Speed);
            Console.WriteLine("Supports Multicast: {0}", @interface.SupportsMulticast);
            Console.WriteLine("Receive-only: {0}", @interface.IsReceiveOnly);
            Console.WriteLine("Physical Address: {0}", @interface.GetPhysicalAddress());
            IPInterfaceProperties props = @interface.GetIPProperties();
            PrintIpCollection("DHCP Servers: ", props.DhcpServerAddresses);
            PrintIpCollection("DNS Servers: ", props.DnsAddresses);

            Console.WriteLine();
         }
         Console.ReadKey();
      }

      private static void PrintIpCollection(string title, IEnumerable<IPAddress> ipAddresses)
      {
         Console.Write(title);
         foreach (IPAddress address in ipAddresses)
         {
            Console.Write("{0} ", address);
         }
         Console.WriteLine();
      }
   }
}
