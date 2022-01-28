using System;

namespace VerySimpleRxExample
{
   public sealed class StatusChange
   {
      public int OrderId { get; set; }
      public string OrderStatus { get; set; }

      public StatusChange()
      {
      }

      public StatusChange(StatusChange aStatusChange)
      {
         OrderId = aStatusChange.OrderId;
         OrderStatus = aStatusChange.OrderStatus;
      }

      public override string ToString()
      {
         return String.Format("OrderId: {0}, OrderStatus: {1}", OrderId, OrderStatus);
      }
   }
}