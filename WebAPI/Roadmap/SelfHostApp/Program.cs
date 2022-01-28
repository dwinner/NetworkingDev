/**
 * Автономный хостинг сервисов WebAPI
 */

using System;
using System.Web.Http.SelfHost;

namespace SelfHostApp
{
   internal class Program
   {
      private static void Main()
      {
         var config = new HttpSelfHostConfiguration("http://localhost:8081");
         
         //config.MapHttpAttributeRoutes();

         using (var server = new HttpSelfHostServer(config))
         {
            server.OpenAsync().Wait();

            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
         }
      }
   }
}