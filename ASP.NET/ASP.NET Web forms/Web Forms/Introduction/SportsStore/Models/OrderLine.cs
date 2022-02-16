namespace SportsStore.Models
{
   /// <summary>
   /// Класс модели данных для хранения сведений о товарах, входящих в заказ
   /// </summary>
   public class OrderLine
   {
      public int OrderLineId { get; set; }

      public Order Order { get; set; }

      public Product Product { get; set; }

      public int Quantity { get; set; }
   }
}