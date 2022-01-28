/**
 * Получение сообщений
 */

using System;
using System.Messaging;

namespace _05_ReceiveMessage
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
         Message receivedMessage = queue.Receive();
         if (receivedMessage != null)
            Console.WriteLine(receivedMessage.Body);
      }
   }
}