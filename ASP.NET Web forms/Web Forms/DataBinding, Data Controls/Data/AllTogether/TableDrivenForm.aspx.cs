using Data.Models;
using Data.Models.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI;

namespace Data.AllTogether
{
   public partial class TableDrivenForm : Page
   {
      private readonly Repository _repository = new Repository();

      public IEnumerable<Product> GetProductData(
         [Control("SelectedCategory", "SelectedCategory.Value")] string filterSelect)
      {
         var products = _repository.Products;
         return (filterSelect ?? "All") == "All"
            ? products
            : products.Where(product => product.Category == filterSelect);
      }

      public IEnumerable<Product> GetCategories()
      {
         return
            new[] { new Product { Category = "All" } }.Concat(
               _repository.Products.GroupBy(product => product.Category)
                  .Select(g => g.First())
                  .OrderBy(product => product.Category));
      }
   }
}