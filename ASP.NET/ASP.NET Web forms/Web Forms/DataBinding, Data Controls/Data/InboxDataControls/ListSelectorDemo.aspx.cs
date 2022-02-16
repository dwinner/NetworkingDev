using Data.Models;
using Data.Models.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Data.InboxDataControls
{
   public partial class ListSelectorDemo : Page
   {
      private static readonly Repository Repository = new Repository();

      public IEnumerable<Product> GetProducts(
         [Control("DemoListSelector", "DemoListSelector.Value")] string category)
      {
         var data = Repository.Products;
         return category == "All" ? data : data.Where(product => product.Category == category);
      }

      public IEnumerable<ListItem> GetCategories()
      {
         return
            new[] { new Product { Category = "All" } }.Concat(
               Repository.Products.GroupBy(product => product.Category)
                  .Select(products => products.First())
                  .OrderBy(product => product.Category))
               .Select(product => new ListItem { Text = product.Category, Selected = product.Category == "Chess" });
      }
   }
}