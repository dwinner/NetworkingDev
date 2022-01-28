/**
 * Транзакционная очередь
 */

using System;
using System.Messaging;

namespace _08_TransactionalQueue
{
   internal static class Program
   {
      private static void Main()
      {
         if (!MessageQueue.Exists(@".\MyTransactionalQueue"))
         {
            MessageQueue.Create(@".\MyTransactionalQueue");
         }

         var queue = new MessageQueue(@".\MyTransactionalQueue");
         var transaction = new MessageQueueTransaction();

         try
         {
            transaction.Begin();
            queue.Send("a", transaction);
            queue.Send("b", transaction);
            queue.Send("c", transaction);
            transaction.Commit();
         }
         catch (Exception)
         {
            transaction.Abort();
         }
      }
   }
}