using SportsStore.Domain.Entites;

namespace SportsStore.Web.Models
{
   public class CartIndexViewModel
   {
      public Cart Cart { get; set; }
      public string ReturnUrl { get; set; }
   }
}