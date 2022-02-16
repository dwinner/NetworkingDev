using Data.Models.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace Data.InboxDataControls
{
   public partial class Bullet : Page
   {
      public IEnumerable<string> GetProducts()
      {
         return new Repository().Products.Select(product => product.Name);
      }
   }
}