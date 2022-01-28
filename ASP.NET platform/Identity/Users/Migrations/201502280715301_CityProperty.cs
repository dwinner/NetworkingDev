using System.Data.Entity.Migrations;

namespace Users.Migrations
{
   public partial class CityProperty : DbMigration
   {
      public override void Up()
      {
         AddColumn("dbo.AspNetUsers", "City", c => c.Int(false));
      }

      public override void Down()
      {
         DropColumn("dbo.AspNetUsers", "City");
      }
   }
}