using SportsStore.Domain.Entites;

namespace SportsStore.Domain.Abstract
{
   public interface IOrderProcessor
   {
      void ProcessOrder(Cart aCart, ShippingDetails aShippingDetails);
   }
}