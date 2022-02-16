using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Users.Infrastructure;
using Users.Models;

namespace Users.Migrations
{
   internal sealed class Configuration : DbMigrationsConfiguration<AppIdentityDbContext>
   {
      public Configuration()
      {
         AutomaticMigrationsEnabled = true;
         ContextKey = "Users.Infrastructure.AppIdentityDbContext";
      }

      protected override void Seed(AppIdentityDbContext context)
      {
         const string adminRoleName = IdentityDbInit.AdminRoleName;

         var userManager = new AppUserManager(new UserStore<AppUser>(context));
         var roleManager = new AppRoleManager(new RoleStore<AppRole>(context));

         const string userName = "Admin";
         const string password = "MySecret";
         const string email = "admin@example.com";

         if (!roleManager.RoleExists(adminRoleName))
         {
            roleManager.Create(new AppRole(adminRoleName));
         }

         var user = userManager.FindByName(userName);
         if (user == null)
         {
            userManager.Create(new AppUser { UserName = userName, Email = email }, password);
            user = userManager.FindByName(userName);
         }

         if (!userManager.IsInRole(user.Id, adminRoleName))
         {
            userManager.AddToRole(user.Id, adminRoleName);
         }

         foreach (var dbUser in userManager.Users)
         {
            if (dbUser.City == default(Cities))
            {
               dbUser.City = Cities.Paris;
            }

            if (dbUser.Country == default(Countries))
            {
               dbUser.SetCountryFromCity(dbUser.City);
            }
         }

         context.SaveChanges();
      }
   }
}