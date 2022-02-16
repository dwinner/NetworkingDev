using System.Data.Entity;
using Books.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Books.Web.DataContexts
{
   public class IdentityDb : IdentityDbContext<ApplicationUser>
   {
      public IdentityDb()
         : base("DefaultConnection")
      {
      }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.HasDefaultSchema("identity");
         base.OnModelCreating(modelBuilder);
      }
   }
}