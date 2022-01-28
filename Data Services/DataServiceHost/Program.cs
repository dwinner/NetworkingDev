/**
 * Хостинг службы WCF Data Service в виде консольного приложения
 */

using System;
using System.ServiceModel;

namespace DataServiceHost
{
   internal static class Program
   {
      private const string ServiceAddress = "http://localhost:9000/Samples";

      private static void Main()
      {
         System.Data.Services.DataServiceHost host = null;
         try
         {
            host = new System.Data.Services.DataServiceHost(typeof(MenuDataService), new[] { new Uri(ServiceAddress) });
            host.Open();
            Console.WriteLine("service running");
            Console.WriteLine("Press return to exit");
            Console.ReadLine();
         }
         catch (CommunicationException communicationEx)
         {
            Console.WriteLine(communicationEx.Message);
         }
         finally
         {
            if (host != null && host.State == CommunicationState.Opened)
               host.Close();
         }
      }
   }
}