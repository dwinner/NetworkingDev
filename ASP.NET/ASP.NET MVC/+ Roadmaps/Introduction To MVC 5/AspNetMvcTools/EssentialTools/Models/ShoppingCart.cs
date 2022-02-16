using System.Collections.Generic;

namespace EssentialTools.Models
{
   public class ShoppingCart
   {
      private readonly IValueCalculator _calculator;

      public ShoppingCart(IValueCalculator calculator)
      {
         _calculator = calculator;
      }

      public IEnumerable<Product> Products { get; set; }

      public decimal CalculateProductTotal()
      {
         return _calculator.ValueProducts(Products);
      }
   }
}