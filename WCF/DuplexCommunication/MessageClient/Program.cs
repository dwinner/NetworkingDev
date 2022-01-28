using System;
using System.ServiceModel;
using System.Threading.Tasks;
using MessageService;

namespace MessageClient
{
   internal static class Program
   {
      private static void Main()
      {
         Console.WriteLine("Client - wait for service");
         Console.ReadLine();

         DuplexSample();

         Console.WriteLine("Client - press return to exit");
         Console.ReadLine();
      }

      private static async void DuplexSample()
      {
         var binding = new WSDualHttpBinding();
         var address = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/MessageService/Service1/");
         var clientCallback = new ClientCallback();
         var context = new InstanceContext(clientCallback);
         var factory = new DuplexChannelFactory<IMyMessage>(context, binding, address);
         IMyMessage messageChannel = factory.CreateChannel();
         await Task.Run(() => messageChannel.MessageToServer("From the server"));
      }
   }

   internal class ClientCallback : IMyMessageCallback
   {
      public void OnCallback(string message)
      {
         Console.WriteLine("Message from server: {0}", message);
      }
   }
}