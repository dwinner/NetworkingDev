using System.Collections.Generic;
using SportsStore.Domain.Entites;

namespace SportsStore.Domain.Abstract
{
   public interface IProductRepository
   {
      IEnumerable<Product> Products { get; }

      void Save(Product aProduct);

      Product Delete(int aProductId);
   }
}