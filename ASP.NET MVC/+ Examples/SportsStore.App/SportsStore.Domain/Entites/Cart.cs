using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Domain.Entites
{
   public class Cart
   {
      private readonly List<CartLine> _cartLines = new List<CartLine>();

      public IEnumerable<CartLine> Lines
      {
         get { return _cartLines; }
      }

      public void AddItem(Product aProduct, int aQuantity)
      {
         var cartLine = _cartLines.FirstOrDefault(line => line.Product.ProductId == aProduct.ProductId);

         if (cartLine == null)
         {
            _cartLines.Add(new CartLine {Product = aProduct, Quantity = aQuantity});
         }
         else
         {
            cartLine.Quantity += aQuantity;
         }
      }

      public void RemoveLine(Product aProduct)
      {
         _cartLines.RemoveAll(line => line.Product.ProductId == aProduct.ProductId);
      }

      public decimal ComputeTotalValue()
      {
         return _cartLines.Sum(line => line.Product.Price*line.Quantity);
      }

      public void Clear()
      {
         _cartLines.Clear();
      }
   }
}