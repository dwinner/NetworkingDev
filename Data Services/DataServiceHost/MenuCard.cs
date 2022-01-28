using System.Collections.Generic;

namespace DataServiceHost
{
   public class MenuCard
   {
      private static readonly object Sync = new object();
      private static MenuCard _menuCard;
      private readonly List<Category> _categories;
      private readonly List<Menu> _menus;

      private MenuCard()
      {
         _categories = new List<Category>
         {
            new Category(1, "Main"),
            new Category(2, "Appetizer")
         };

         _menus = new List<Menu>
         {
            new Menu(1, "Roaster Chicken", 22, _categories[0]),
            new Menu(2, "Rack of Lamb", 32, _categories[0]),
            new Menu(3, "Pork Tenderloin", 23, _categories[0]),
            new Menu(4, "Fried Calamari", 9, _categories[1])
         };
      }

      public List<Menu> Menus
      {
         get { return _menus; }
      }

      public List<Category> Categories
      {
         get { return _categories; }
      }

      public static MenuCard Instance
      {
         get
         {
            lock (Sync)
            {
               if (_menuCard == null)
                  _menuCard = new MenuCard();
            }

            return _menuCard;
         }
      }
   }
}