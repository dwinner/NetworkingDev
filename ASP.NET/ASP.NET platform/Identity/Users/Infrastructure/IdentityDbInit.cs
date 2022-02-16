using System.Data.Entity;

namespace Users.Infrastructure
{
   public class IdentityDbInit : NullDatabaseInitializer<AppIdentityDbContext> /*DropCreateDatabaseIfModelChanges<AppIdentityDbContext>*/
   {
      public const string AdminRoleName = "Adminstrators";

      #region commented

      //protected override void Seed(AppIdentityDbContext context)
      //{
      //   PerformInitialSetup(context);
      //   base.Seed(context);
      //}

      //private void PerformInitialSetup(DbContext context)
      //{
      //   var userManager = new AppUserManager(new UserStore<AppUser>(context));
      //   var roleManager = new AppRoleManager(new RoleStore<AppRole>(context));

      //   const string userName = "Admin";
      //   const string password = "MySecret";
      //   const string email = "admin@example.com";

      //   if (!roleManager.RoleExists(AdminRoleName))
      //   {
      //      roleManager.Create(new AppRole(AdminRoleName));
      //   }

      //   var user = userManager.FindByName(userName);
      //   if (user == null)
      //   {
      //      userManager.Create(new AppUser { UserName = userName, Email = email }, password);
      //      user = userManager.FindByName(userName);
      //   }

      //   if (!userManager.IsInRole(user.Id, AdminRoleName))
      //   {
      //      userManager.AddToRole(user.Id, AdminRoleName);
      //   }
      //}

      #endregion

   }
}