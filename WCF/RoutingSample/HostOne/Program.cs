using System;
using System.ServiceModel;
using Routing.DemoService;

namespace HostOne
{
   internal static class Program
   {
      private static ServiceHost _myServiceHost;

      private static void Main()
      {
         const string host = "Host One";
         DemoService.Server = host;

         StartService();

         Console.WriteLine("{0} is running. Press return to exit", host);
         Console.ReadLine();

         StopService();
      }

      private static void StartService()
      {
         try
         {
            _myServiceHost = new ServiceHost(typeof (DemoService));
            _myServiceHost.Open();
         }
         catch (AddressAccessDeniedException)
         {
            Console.WriteLine(
               "either start Visual Studio in elevated admin mode or register the listener port with netsh.exe");
         }
      }

      private static void StopService()
      {
         if (_myServiceHost != null && _myServiceHost.State == CommunicationState.Opened)
         {
            _myServiceHost.Close();
         }
      }
   }
}