using System;
using System.ServiceModel;

namespace DuplexHost
{
   internal static class Program
   {
      internal static ServiceHost MyServiceHost = null;

      private static void Main()
      {
         StartService();
         Console.WriteLine("Service running; press return to exit");
         Console.ReadLine();
         StopService();
         Console.WriteLine("stopped");
      }

      internal static void StartService()
      {
         MyServiceHost = new ServiceHost(typeof (MessageService.MessageService));
         MyServiceHost.Open();
      }

      internal static void StopService()
      {
         if (MyServiceHost.State != CommunicationState.Closed)
         {
            MyServiceHost.Close();
         }
      }
   }
}