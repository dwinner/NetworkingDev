using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EssentialTools.Models
{
   public class LinqValueCalculator : IValueCalculator
   {
      private readonly IDiscountHelper _discount;
      private static int _counter = 0;

      public LinqValueCalculator(IDiscountHelper discount)
      {
         _discount = discount;
         Debug.WriteLine("Instance {0} created", ++_counter);
      }

      public decimal ValueProducts(IEnumerable<Product> products)
      {
         return _discount.ApplyDiscount(products.Sum(product => product.Price));
      }
   }
}