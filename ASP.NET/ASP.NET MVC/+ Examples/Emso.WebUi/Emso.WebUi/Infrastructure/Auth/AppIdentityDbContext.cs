using System.Data.Entity;
using Emso.WebUi.Models.Auth;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Emso.WebUi.Infrastructure.Auth
{
   public class AppIdentityDbContext : IdentityDbContext<AppUser>
   {
      static AppIdentityDbContext()
      {
         Database.SetInitializer(new IdentityDbInit());
      }

      public AppIdentityDbContext()
         : base("IdentityDb")
      {
      }

      public static AppIdentityDbContext Create()
      {
         return new AppIdentityDbContext();
      }
   }
}