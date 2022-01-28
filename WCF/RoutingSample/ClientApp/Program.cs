using System;
using ClientApp.DemoSrvRef;

namespace ClientApp
{
   internal static class Program
   {
      private static void Main()
      {
         Console.WriteLine("Client - wait for services");
         Console.ReadLine();
         var service = new DemoServiceClient();
         Console.WriteLine(service.GetData("HelloB"));
         Console.ReadLine();
      }
   }
}