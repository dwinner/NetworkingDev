using System.Data.Entity.Migrations;

namespace Books.Web.DataContexts.BookMigrations
{
   public partial class DefaultSchema : DbMigration
   {
      public override void Up()
      {
         MoveTable("dbo.Books", "library");
      }

      public override void Down()
      {
         MoveTable("library.Books", "dbo");
      }
   }
}