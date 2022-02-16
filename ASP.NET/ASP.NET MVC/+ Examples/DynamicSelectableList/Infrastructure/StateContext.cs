using System.Data.Entity;

namespace DynamicSelectableList.Infrastructure
{
   public class StateContext : DbContext
   {
      public DbSet<State> States { get; set; }
      public DbSet<City> Cities { get; set; }
   }
}