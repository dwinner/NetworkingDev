using System.Data.Entity.Migrations;
using Emso.WebUi.Infrastructure.Auth;
using Emso.WebUi.Models.Auth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Emso.WebUi.Migrations
{
   internal sealed class Configuration : DbMigrationsConfiguration<AppIdentityDbContext>
   {
      private const string SuperAdminUserName = "natnat";
      private const string SuperAdminPassword = "3680251am";
      private const string SuperAdminEmail = "natesova@schleissheimer.de";
      private const string SuperAdminRoleName = IdentityDbInit.AdminRoleName;

      public Configuration()
      {
         AutomaticMigrationsEnabled = true;
         ContextKey = "AppIdentityDbContext";
      }

      protected override void Seed(AppIdentityDbContext context)
      {
         var userManager = new AppUserManager(new UserStore<AppUser>(context));
         var roleManager = new AppRoleManager(new RoleStore<AppRole>(context));

         if (!roleManager.RoleExists(SuperAdminRoleName))
         {
            roleManager.Create(new AppRole(SuperAdminRoleName));
         }

         var user = userManager.FindByName(SuperAdminUserName);
         if (user == null)
         {
            userManager.Create(new AppUser { UserName = SuperAdminUserName, Email = SuperAdminEmail }, SuperAdminPassword);
            user = userManager.FindByName(SuperAdminUserName);
         }

         if (!userManager.IsInRole(user.Id, SuperAdminRoleName))
         {
            userManager.AddToRole(user.Id, SuperAdminRoleName);
         }         

         context.SaveChanges();
      }
   }
}