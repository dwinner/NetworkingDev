using System;

namespace NorthwindComponent
{
   [Serializable]
   public class OrderLine
   {
      private OrderLine(int productId, float unitPrice, int quantity)
      {
         ProductId = productId;
         UnitPrice = unitPrice;
         Quantity = quantity;
      }

      private OrderLine()
      {
      }

      public int ProductId { get; private set; }

      public float UnitPrice { get; private set; }

      public int Quantity { get; private set; }

      public static OrderLine Create(int productId, float unitPrice, int quantity)
      {
         return new OrderLine(productId, unitPrice, quantity);
      }
   }
}