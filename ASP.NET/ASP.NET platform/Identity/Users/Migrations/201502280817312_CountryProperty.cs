using System.Data.Entity.Migrations;

namespace Users.Migrations
{
   public partial class CountryProperty : DbMigration
   {
      public override void Up()
      {
         AddColumn("dbo.AspNetUsers", "Country", c => c.Int(false));
      }

      public override void Down()
      {
         DropColumn("dbo.AspNetUsers", "Country");
      }
   }
}