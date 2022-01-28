/**
 * Перечисление сообщений
 */

using System;
using System.Messaging;

namespace _06_MessageEnumeration
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

         // Использование IEnumerable
         foreach (Message message in queue)
         {
            Console.WriteLine(message);
         }

         // Использование перечислителя очереди
         using (MessageEnumerator enumerator = queue.GetMessageEnumerator2())
         {
            while (enumerator.MoveNext(TimeSpan.FromMinutes(30))) // Время на ожидание сообщения
            {
               Message currentMessage = enumerator.Current;
               if (currentMessage != null)
                  Console.WriteLine(currentMessage.Body);
            }
         }
      }
   }
}