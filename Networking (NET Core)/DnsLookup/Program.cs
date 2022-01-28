/*
 * Try DNS lookup with the following:
 *    - www.cninnovation.com
 *    - www.wiley.com
 *    - portal.azure.com
 */

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

do
{
   Console.Write("Hostname:\t");
   var hostName = Console.ReadLine();
   if (hostName is null || hostName.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
   {
      Console.WriteLine("bye!");
      return;
   }

   await OnLookupAsync(hostName).ConfigureAwait(false);
   Console.WriteLine();
} while (true);

static async Task OnLookupAsync(string hostName)
{
   try
   {
      var ipHost = await Dns.GetHostEntryAsync(hostName).ConfigureAwait(false);
      Console.WriteLine($"Hostname: {ipHost.HostName}");

      foreach (var address in ipHost.AddressList)
      {
         Console.WriteLine($"Address family: {address.AddressFamily}, address: {address}");
      }
   }
   catch (SocketException socketEx)
   {
      Console.WriteLine(socketEx.Message);
   }
}