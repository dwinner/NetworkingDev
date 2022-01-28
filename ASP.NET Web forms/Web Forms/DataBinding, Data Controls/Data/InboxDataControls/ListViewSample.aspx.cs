using System.Linq;
using System.Web.UI;
using Data.Models;
using Data.Models.Repository;

namespace Data.InboxDataControls
{
   public partial class ListViewSample : Page
   {
      private static readonly Repository Repo = new Repository();

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
   }
}