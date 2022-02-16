using System.Data.Entity;
using SportsStore.Domain.Entites;

namespace SportsStore.Domain.Concrete
{
   public class EfDbContext : DbContext
   {
      public DbSet<Product> Products { get; set; }
   }
}