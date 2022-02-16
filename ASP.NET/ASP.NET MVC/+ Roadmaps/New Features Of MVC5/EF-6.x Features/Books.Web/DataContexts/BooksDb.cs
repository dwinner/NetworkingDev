using System.Data.Entity;
using System.Diagnostics;
using Books.Entities;

namespace Books.Web.DataContexts
{
   public class BooksDb : DbContext
   {
      public BooksDb()
         : base("DefaultConnection")
      {
         Database.Log = sql => Debug.Write(sql);
      }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.HasDefaultSchema("library");
         base.OnModelCreating(modelBuilder);
      }

      public DbSet<Book> Books { get; set; }
   }
}