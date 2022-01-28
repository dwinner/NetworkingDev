/**
 * Отправка сообщения
 */

using System;
using System.Messaging;

namespace _04_SendMessage
{
   internal static class Program
   {
      private const string LocalPrivateQueue = @".\private$\MyQueue";

      private static void Main()
      {
         try
         {
            if (!MessageQueue.Exists(LocalPrivateQueue))
               MessageQueue.Create(LocalPrivateQueue);

            var queue = new MessageQueue(LocalPrivateQueue);
            queue.Send("Sample message", "Label");
         }
         catch (MessageQueueException messageQueueEx)
         {
            Console.WriteLine(messageQueueEx.Message);
         }
      }
   }
}