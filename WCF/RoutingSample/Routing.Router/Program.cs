using System;
using System.ServiceModel;
using System.ServiceModel.Routing;

namespace Routing.Router
{
   internal static class Program
   {
      private static ServiceHost _routerHost;

      private static void Main()
      {
         StartService();

         Console.WriteLine("Router is running. Press return to exit");
         Console.ReadLine();

         StopService();
      }

      private static void StartService()
      {
         try
         {
            _routerHost = new ServiceHost(typeof(RoutingService));
            _routerHost.Faulted += RouterHost_Faulted;
            _routerHost.Open();
         }
         catch (AddressAccessDeniedException)
         {
            Console.WriteLine(
               "either start Visual Studio in elevated admin mode or register the listener port with netsh.exe");
         }
      }

      private static void StopService()
      {
         if (_routerHost != null && _routerHost.State == CommunicationState.Opened)
         {
            _routerHost.Close();
         }
      }

      private static void RouterHost_Faulted(object sender, EventArgs e)
      {
         Console.WriteLine("Router faulted");
      }
   }
}