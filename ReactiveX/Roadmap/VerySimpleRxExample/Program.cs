// Очень простой пример использования реактивных расширений

using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace VerySimpleRxExample
{
   internal static class Program
   {
      private static void Main()
      {
         ISubject<StatusChange> statChange = new Subject<StatusChange>();

         // Уведомления при изменении заказов
         statChange.Subscribe(change => Console.WriteLine(change.OrderStatus));
         statChange.Subscribe(change => Console.WriteLine(change.OrderId));

         // Фильтрация уведомлений
         statChange
            .Where(change => change.OrderStatus == "Processing")
            .Subscribe(change => Console.WriteLine("Only processing: {0}", change.OrderStatus));

         // Подключение полного цикла уведомлений
         IFullNotifier fullNotifier = new FullNotifierImpl();
         statChange.Subscribe(fullNotifier.Next, fullNotifier.ErrorOccured, fullNotifier.Complete,
            CancellationToken.None);

         statChange.OnNext(new StatusChange { OrderId = 1, OrderStatus = "New" });
         statChange.OnNext(new StatusChange { OrderId = 1, OrderStatus = "Processing" });
         statChange.OnCompleted();
      }
   }
}