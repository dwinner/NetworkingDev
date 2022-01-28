using System.Data.Entity;

namespace WebApiSample.Models
{
   /// <summary>
   /// EF-Контекст
   /// </summary>
   public class MenuCardModel : DbContext
   {
      public DbSet<Menu> Menus { get; set; }

      public DbSet<MenuCard> MenuCards { get; set; }
   }
}