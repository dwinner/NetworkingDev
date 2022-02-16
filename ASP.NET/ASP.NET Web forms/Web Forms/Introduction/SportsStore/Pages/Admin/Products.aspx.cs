using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI;
using SportsStore.Models;
using SportsStore.Models.Repository;

namespace SportsStore.Pages.Admin
{
   public partial class Products : Page
   {
      private readonly SportsStoreRepository _repository = new SportsStoreRepository();

      protected void Page_Load(object sender, EventArgs e)
      {
      }

      public IEnumerable<Product> GetProducts()
      {
         return _repository.Products;
      }

      public void UpdateProduct(int productId)
      {
         Product productToUpdate = _repository.Products.FirstOrDefault(product => product.ProductId == productId);
         if (productToUpdate != null
            && TryUpdateModel(productToUpdate, new FormValueProvider(ModelBindingExecutionContext)))
         {
            _repository.Save(productToUpdate);
         }
      }

      public void DeleteProduct(int productId)
      {
         Product productToDelete = _repository.Products.FirstOrDefault(product => product.ProductId == productId);
         if (productToDelete != null)
         {
            _repository.Delete(productToDelete);
         }
      }

      public void InsertProduct()
      {
         var newProduct = new Product();
         if (TryUpdateModel(newProduct, new FormValueProvider(ModelBindingExecutionContext)))
         {
            _repository.Save(newProduct);
         }
      }
   }
}