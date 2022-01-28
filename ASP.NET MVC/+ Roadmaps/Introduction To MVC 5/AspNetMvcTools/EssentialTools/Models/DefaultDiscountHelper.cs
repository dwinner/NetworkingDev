namespace EssentialTools.Models
{
   public class DefaultDiscountHelper : IDiscountHelper
   {
      public decimal DiscountSize { get; set; }

      public DefaultDiscountHelper(decimal discountSize)
      {
         DiscountSize = discountSize;
      }

      public decimal ApplyDiscount(decimal totalParam)
      {
         return (totalParam - (DiscountSize / 100m * totalParam));
      }
   }
}