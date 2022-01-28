/**
 * Реализация динамического клиента, который пытается обнаружить
 * все доступные конечные точки для конкретной конфигурации
 */

using System;
using System.ServiceModel.Discovery;

namespace WCFDiscoverableClient
{
   internal static class Client
   {
      private static void Main()
      {
         var client = new DiscoveryClient(new UdpDiscoveryEndpoint());

         // Найти все доступные конечные точки
         // Note: вы также можете вызвать этот метод асинхронно
         var criteria = new FindCriteria(typeof (FileServiceLib.IFileService));
         var response = client.Find(criteria);

         // Связаться с одной из них
         FileServiceClient svcClient = null;
         foreach (var endpoint in response.Endpoints)
         {
            svcClient = new FileServiceClient();
            svcClient.Endpoint.Address = endpoint.Address;
            break;
         }
         // Вызвать службу
         if (svcClient != null)
         {
            var dirs = svcClient.GetSubDirectories(@"C:\");
            foreach (var dir in dirs)
            {
               Console.WriteLine(dir);
            }
         }
         Console.ReadLine();
      }
   }
}