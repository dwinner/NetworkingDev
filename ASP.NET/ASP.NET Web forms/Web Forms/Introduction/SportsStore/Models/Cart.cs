using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
   /// <summary>
   /// Класс корзины для покупок
   /// </summary>
   public class Cart
   {
      private readonly List<CartLine> _lines = new List<CartLine>();

      /// <summary>
      /// Корзина для покупок
      /// </summary>
      public IEnumerable<CartLine> Lines
      {
         get { return _lines; }
      }

      /// <summary>
      /// Добавление товара в корзину
      /// </summary>
      /// <param name="product">Товар для добавления</param>
      /// <param name="quantity">Кол-во товара для добавления</param>      
      public void AddItem(Product product, int quantity)
      {
         CartLine cartLine = _lines.FirstOrDefault(line => line.Product.ProductId == product.ProductId);
         if (cartLine == null)
         {
            _lines.Add(new CartLine
            {
               Product = product,
               Quantity = quantity
            });
         }
         else
         {
            cartLine.Quantity += quantity;
         }
      }

      /// <summary>
      /// Общая стоимость элементов в корзине
      /// </summary>
      /// <returns>Общая стоимость элементов в корзине</returns>
      public decimal ComputeTotalValue()
      {
         return _lines.Sum(line => line.Product.Price * line.Quantity);
      }

      /// <summary>
      /// Удаление товара из корзины
      /// </summary>
      /// <param name="product">Товар для удаления</param>
      /// <returns>Кол-во удаленных товаров</returns>
      public int RemoveLine(Product product)
      {
         return _lines.RemoveAll(line => line.Product.ProductId == product.ProductId);
      }

      /// <summary>
      /// Очистка корзины
      /// </summary>
      public void Clear()
      {
         _lines.Clear();
      }
   }
}