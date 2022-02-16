using System.Data.Entity;

namespace SportsStore.Models.Repository
{
   public class SportsStoreDatabaseContext : DbContext
   {
      public DbSet<Product> Products { get; set; }

      public DbSet<Order> Orders { get; set; }
   }
}