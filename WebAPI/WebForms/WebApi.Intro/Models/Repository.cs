using System.Collections.Generic;
using System.Linq;

namespace WebApi.Intro.Models
{
   public class Repository
   {
      private static readonly Dictionary<int, Product> Data = new Dictionary<int, Product>();

      static Repository()
      {
         Product[] dataArray =
         {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product
            {
               Name = "Lifejacket",
               Category = "Watersports",
               Price = 48.95M
            },
            new Product {Name = "Soccer Ball", Category = "Soccer", Price = 19.50M},
            new Product
            {
               Name = "Corner Flags",
               Category = "Soccer",
               Price = 34.95M
            },
            new Product {Name = "Stadium", Category = "Soccer", Price = 79500M},
            new Product {Name = "Thinking Cap", Category = "Chess", Price = 16M},
            new Product
            {
               Name = "Unsteady Chair",
               Category = "Chess",
               Price = 29.95M
            },
            new Product
            {
               Name = "Human Chess Board",
               Category = "Chess",
               Price = 75M
            },
            new Product
            {
               Name = "Bling-Bling King",
               Category = "Chess",
               Price = 1200M
            }
         };

         for (var i = 0; i < dataArray.Length; i++)
         {
            dataArray[i].ProductId = i;
            Data[i] = dataArray[i];
         }
      }

      public IEnumerable<Product> Products
      {
         get { return Data.Values; }
      }

      public void Save(Product product)
      {
         Data[product.ProductId] = product;
      }

      public void Delete(Product product)
      {
         if (Data.ContainsKey(product.ProductId))
         {
            Data.Remove(product.ProductId);
         }
      }

      public void Add(Product product)
      {
         product.ProductId = Products.Select(p => p.ProductId).Max() + 1;
         Save(product);
      }
   }
}