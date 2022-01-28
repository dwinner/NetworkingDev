using System.Linq;

namespace DataServiceHost
{
   public class MenuCardDataModel
   {
      public IQueryable<Menu> Menus
      {
         get { return MenuCard.Instance.Menus.AsQueryable(); }
      }

      public IQueryable<Category> Categories
      {
         get { return MenuCard.Instance.Categories.AsQueryable(); }
      }
   }
}