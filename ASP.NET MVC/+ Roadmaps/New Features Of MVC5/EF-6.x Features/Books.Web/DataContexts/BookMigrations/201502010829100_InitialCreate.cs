using System.Data.Entity.Migrations;

namespace Books.Web.DataContexts.BookMigrations
{
   public partial class InitialCreate : DbMigration
   {
      public override void Up()
      {
         CreateTable(
            "dbo.Books",
            c => new
            {
               Id = c.Int(false, true),
               Title = c.String(false, 255),
               Category = c.Int(false),
            })
            .PrimaryKey(t => t.Id);
      }

      public override void Down()
      {
         DropTable("dbo.Books");
      }
   }
}