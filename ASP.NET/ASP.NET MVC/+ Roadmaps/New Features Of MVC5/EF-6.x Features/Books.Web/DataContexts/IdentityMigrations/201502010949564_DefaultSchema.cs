using System.Data.Entity.Migrations;

namespace Books.Web.DataContexts.IdentityMigrations
{
   public partial class DefaultSchema : DbMigration
   {
      public override void Up()
      {
         MoveTable("dbo.AspNetRoles", "identity");
         MoveTable("dbo.AspNetUserClaims", "identity");
         MoveTable("dbo.AspNetUsers", "identity");
         MoveTable("dbo.AspNetUserLogins", "identity");
         MoveTable("dbo.AspNetUserRoles", "identity");
      }

      public override void Down()
      {
         MoveTable("identity.AspNetUserRoles", "dbo");
         MoveTable("identity.AspNetUserLogins", "dbo");
         MoveTable("identity.AspNetUsers", "dbo");
         MoveTable("identity.AspNetUserClaims", "dbo");
         MoveTable("identity.AspNetRoles", "dbo");
      }
   }
}