/**
 * Сервер службы WCF
 */

using System;
using System.ServiceModel;
using FileServiceLib;

namespace WCFHost
{
   internal static class Program
   {
      private static void Main()
      {
         Console.WriteLine("FileService Host");

         using (var serviceHost = new ServiceHost(typeof (FileService)))
         {
            serviceHost.Open();

            Console.ReadLine();
         }
      }
   }
}