/**
 * Специальный хост службы WCF
 */

using System;
using System.ServiceModel;
//using System.ServiceModel.Web;
using System.ServiceModel.Description;

namespace RoomReservationServiceHost
{
   internal class Program
   {
      private static ServiceHost _myServiceHost;

      private static void Main()
      {
         StartService();

         Console.WriteLine("Server is running. Press return to exit");
         Console.ReadLine();

         StopService();
      }

      // TODO: netsh http add urlacl url=http://localhost:9000/RoomReservation user=Developer\Денис
      private static void StartService()
      {
         try
         {            
            var uri = new Uri("http://localhost:9000/RoomReservation");
            _myServiceHost = new ServiceHost(typeof (RoomReservationService.RoomReservationService), uri);
            //_myServiceHost = new WebServiceHost(uri);
            _myServiceHost.Description.Behaviors.Add(new ServiceMetadataBehavior {HttpGetEnabled = true});
            _myServiceHost.Open();
         }
         catch (AddressAccessDeniedException)
         {
            Console.WriteLine(
               "Either start Visual Studio in elevated admin mode or register the listener port with netsh.exe");
         }
      }

      private static void StopService()
      {
         if (_myServiceHost != null && _myServiceHost.State == CommunicationState.Opened)
            _myServiceHost.Close();
      }
   }
}