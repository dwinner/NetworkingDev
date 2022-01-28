using System;
using System.Collections.Generic;

namespace NorthwindComponent
{
   [Serializable]
   public class Order
   {
      private readonly List<OrderLine> _orderLines = new List<OrderLine>();

      private Order()
      {
      }

      private Order(string customerId, DateTime orderDate, string shipAddress, string shipCity, string shipCountry)
      {
         CustomerId = customerId;
         OrderDate = orderDate;
         ShipAddress = shipAddress;
         ShipCity = shipCity;
         ShipCountry = shipCountry;
      }

      public IEnumerable<OrderLine> OrderLines
      {
         get
         {
            var orderLines = new OrderLine[_orderLines.Count];
            _orderLines.CopyTo(orderLines);
            return orderLines;
         }
      }

      public int OrderId { get; private set; }

      public string CustomerId { get; private set; }

      public DateTime OrderDate { get; private set; }

      public string ShipAddress { get; private set; }

      public string ShipCity { get; private set; }

      public string ShipCountry { get; private set; }

      public static Order Create(string customerId, DateTime orderDate, string shipAddress, string shipCity,
         string shipCountry)
      {
         return new Order(customerId, orderDate, shipAddress, shipCity, shipCountry);
      }

      public void SetOrderId(int orderId)
      {
         OrderId = orderId;
      }

      public void AddOrderLine(OrderLine orderLine)
      {
         _orderLines.Add(orderLine);
      }
   }
}