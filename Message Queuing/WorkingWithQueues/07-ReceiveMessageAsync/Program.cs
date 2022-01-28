/**
 * Асинхронное чтение сообщений
 */

using System;
using System.Messaging;

namespace _07_ReceiveMessageAsync
{
   internal static class Program
   {
      private const string LocalPrivateQueue = @".\private$\MyQueue";

      private static void Main()
      {
         var queue = new MessageQueue(LocalPrivateQueue)
         {
            Formatter = new XmlMessageFormatter(new[]
            {
               typeof (string)
            })
         };

         queue.ReceiveCompleted += QueueOnReceiveCompleted;
         queue.BeginReceive();   // Поток не ожидает         
      }

      private static void QueueOnReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
      {
         var queue = sender as MessageQueue;
         if (queue != null)
         {
            Message message = queue.EndReceive(e.AsyncResult);
            Console.WriteLine(message.Body);
         }
      }
   }
}