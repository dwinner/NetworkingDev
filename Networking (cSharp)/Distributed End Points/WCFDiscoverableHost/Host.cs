/**
 * Реализация хоста, который можно обнаружить
 */

using System;
using System.ServiceModel;
using FileServiceLib;

namespace WCFDiscoverableHost
{
   internal static class Host
   {
      private static void Main()
      {
         Console.WriteLine("FileService Host (Discoverable)");

         using (var serviceHost = new ServiceHost(typeof (FileService)))
         {
            serviceHost.Open();

            Console.ReadLine();
         }
      }
   }
}