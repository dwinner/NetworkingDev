/**
 * Примеры миграции:
 * -----------------------------------------------------------------------------------
 * Включение поддержки миграции:          Enable-Migrations -EnableAutomaticMigrations
 * Создание новой миграции:               Add-Migration CityProperty
 * Обновление после добавления миграции:  Update-Database -TargetMigration CityProperty
 * и т.д...:
 * -----------------------------------------------------------------------------------
 * Add-Migration CountryProperty
 * Update-Database -TargetMigration CountryProperty
 */

using Microsoft.AspNet.Identity.EntityFramework;
using Users.Models;
using System.Data.Entity;

namespace Users.Infrastructure
{
   public class AppIdentityDbContext : IdentityDbContext<AppUser>
   {
      public static AppIdentityDbContext Create()
      {
         return new AppIdentityDbContext();
      }

      public AppIdentityDbContext()
         : base("IdentityDb")
      {         
      }

      static AppIdentityDbContext()
      {
         Database.SetInitializer(new IdentityDbInit());
      }
   }
}