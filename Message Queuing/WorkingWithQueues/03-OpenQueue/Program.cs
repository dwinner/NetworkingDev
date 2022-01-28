/**
 * Открытие очереди
 */

using System;
using System.Messaging;

namespace _03_OpenQueue
{
   internal static class Program
   {
      private const string LocalPrivateQueue = @".\private$\MyQueue";

      private static void Main()
      {
         if (MessageQueue.Exists(LocalPrivateQueue))
         {
            var privateQueue = new MessageQueue(LocalPrivateQueue);
            Console.WriteLine(privateQueue.Path);
         }
         else
         {
            Console.WriteLine("Queue {0} is not exists", LocalPrivateQueue);
         }
      }
   }
}