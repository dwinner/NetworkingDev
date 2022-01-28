using System.Reactive.Subjects;

namespace VerySimpleRxExample
{
   public sealed class SalesOrder   // Proxy-класс
   {
      private string _status;

      public SalesOrder()
      {
         StatChange = new Subject<StatusChange>();
      }

      public ISubject<StatusChange> StatChange { get; private set; }
      public int Id { get; set; }

      public string Status
      {
         get { return _status; }
         set
         {
            _status = value;
            var newStatusChange = new StatusChange { OrderId = Id, OrderStatus = Status };
            StatChange.OnNext(newStatusChange);
         }
      }
   }
}