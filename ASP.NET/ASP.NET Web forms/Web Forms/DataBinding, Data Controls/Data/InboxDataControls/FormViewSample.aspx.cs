using System;
using System.Linq;
using System.Web.UI;
using Data.Models;
using Data.Models.Repository;

namespace Data.InboxDataControls
{
   public partial class FormViewSample : Page
   {
      private static readonly Repository Repo = new Repository();

      protected void Page_Load(object sender, EventArgs e)
      {
      }

      public IQueryable<Product> GetProducts()
      {
         return Repo.Products.AsQueryable();
      }

      public void UpdateProduct(int? productId)
      {
         var productToUpdate = Repo.Products.FirstOrDefault(product => product.ProductId == productId);
         if (productToUpdate != null && TryUpdateModel(productToUpdate))
         {
            Repo.Save(productToUpdate);
         }
      }

      public void DeleteProduct(int? productId)
      {
         var productToDelete = Repo.Products.FirstOrDefault(product => product.ProductId == productId);
         if (productToDelete != null)
         {
            Repo.Delete(productToDelete);
         }
      }

      public void InsertProduct()
      {
         var newProduct = new Product();
         if (TryUpdateModel(newProduct))
         {
            Repo.Add(newProduct);
         }
      }
   }
}