namespace SportsStore.Models
{
   /// <summary>
   /// Сущностный класс элемента корзины для покупок
   /// </summary>
   public class CartLine
   {
      /// <summary>
      /// Товар
      /// </summary>
      public Product Product { get; set; }

      /// <summary>
      /// Кол-во товара
      /// </summary>
      public int Quantity { get; set; }
   }
}