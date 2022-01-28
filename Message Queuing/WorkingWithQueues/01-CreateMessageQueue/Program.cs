/**
 * Создание очереди сообщений
 */

using System;
using System.Messaging;

namespace _01_CreateMessageQueue
{
   internal static class Program
   {
      private static void Main()
      {
         using (MessageQueue queue = MessageQueue.Create(@".\MyNewPublicQueue"))
         {
            queue.Label = "Demo Queue";
            Console.WriteLine("Queue created:");
            Console.WriteLine("Path: {0}", queue.Path);
            Console.WriteLine("Format name: {0}", queue.FormatName);
         }
      }
   }
}