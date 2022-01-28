/**
 * Клиент службы
 */

using System;
using System.ServiceModel;
using WebSocketClient.DemoService;

namespace WebSocketClient
{
   internal class Program
   {
      private static void Main()
      {
         Console.WriteLine("Client... wait for the server");
         Console.ReadLine();
         StartSendRequest();
         Console.WriteLine("Next return to exit");
         Console.ReadLine();
      }

      private static async void StartSendRequest()
      {
         var instance = new InstanceContext(new CallbackHandler());
         var client = new DemoServiceClient(instance);
         await client.StartSendingMessagesAsync();
      }

      private class CallbackHandler : IDemoServiceCallback
      {
         public void SendMessage(string aMessage)
         {
            Console.WriteLine("Message from server {0}", aMessage);
         }
      }
   }
}