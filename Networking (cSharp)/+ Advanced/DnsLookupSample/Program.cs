using System;
using System.Net;
using System.Threading.Tasks;
using static System.Console;

namespace DnsLookupSample
{
   internal static class Program
   {
      private static void Main()
      {
         do
         {
            Write("Hostname:\t");
            var hostName = ReadLine();
            if (string.Compare(hostName, "exit", StringComparison.Ordinal) == 0)
            {
               WriteLine("bye!");
               return;
            }

            OnLookupAsync(hostName).Wait();
            WriteLine();
         }
         while (true);
      }

      private static async Task OnLookupAsync(string aHostName)
      {
         try
         {
            var ipHost = await Dns.GetHostEntryAsync(aHostName).ConfigureAwait(false);
            foreach (var address in ipHost.AddressList)
            {
               WriteLine($"Address family: {address.AddressFamily}");
               WriteLine($"Address: {address}");
            }
         }
         catch (Exception ex)
         {
            WriteLine(ex.Message);
         }
      }
   }
}