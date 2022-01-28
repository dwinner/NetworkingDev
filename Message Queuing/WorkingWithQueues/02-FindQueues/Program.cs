/**
 * Нахождение очереди
 */

using System;
using System.Messaging;

namespace _02_FindQueues
{
   internal static class Program
   {
      private static void Main()
      {
         // Открытые очереди в домене
         foreach (var publicQueue in MessageQueue.GetPublicQueues())
         {
            Console.WriteLine(publicQueue.Path);
         }

         // Закрытые очереди
         foreach (var privateQueue in MessageQueue.GetPrivateQueuesByMachine("."))
         {
            Console.WriteLine(privateQueue.QueueName);
         }
      }
   }
}