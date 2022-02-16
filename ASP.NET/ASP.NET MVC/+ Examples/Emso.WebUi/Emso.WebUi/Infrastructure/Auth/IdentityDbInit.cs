using System.Data.Entity;

namespace Emso.WebUi.Infrastructure.Auth
{
   public class IdentityDbInit : NullDatabaseInitializer<AppIdentityDbContext>
   {
      public const string AdminRoleName = "Adminstrators";
   }
}