using System.Collections.Generic;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entites;

namespace SportsStore.Domain.Concrete
{
   public class EfProductRepository : IProductRepository
   {
      private readonly EfDbContext _context = new EfDbContext();

      public IEnumerable<Product> Products
      {
         get { return _context.Products; }
      }

      public void Save(Product aProduct)
      {
         if (aProduct.ProductId == 0)
         {
            _context.Products.Add(aProduct);
         }
         else
         {
            var productEntry = _context.Products.Find(aProduct.ProductId);
            if (productEntry != null)
            {
               productEntry.Name = aProduct.Name;
               productEntry.Description = aProduct.Description;
               productEntry.Price = aProduct.Price;
               productEntry.Category = aProduct.Category;
               productEntry.ImageData = aProduct.ImageData;
               productEntry.ImageMimeType = aProduct.ImageMimeType;
            }
         }

         _context.SaveChanges();
      }

      public Product Delete(int aProductId)
      {
         var productEntry = _context.Products.Find(aProductId);
         if (productEntry != null)
         {
            _context.Products.Remove(productEntry);
            _context.SaveChanges();
         }

         return productEntry;
      }
   }
}