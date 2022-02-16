using System.Collections.Generic;
using SportsStore.Domain.Entites;

namespace SportsStore.Web.Models
{
   public class ProductListViewModel
   {
      public IEnumerable<Product> Products { get; set; }
      public PagingInfo PagingInfo { get; set; }
      public string CurrentCategory { get; set; }
   }
}