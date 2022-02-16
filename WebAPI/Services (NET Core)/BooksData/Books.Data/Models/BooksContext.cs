using Books.Data.Services;
using Books.Shared;
using Microsoft.EntityFrameworkCore;

namespace Books.Data.Models;

public sealed class BooksContext : DbContext, IBookChapterService
{
   public BooksContext(DbContextOptions<BooksContext> options)
      : base(options) =>
      ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

   public DbSet<BookChapter> Chapters => Set<BookChapter>();

   public async Task AddAsync(BookChapter chapter)
   {
      await Chapters.AddAsync(chapter).ConfigureAwait(false);
      await SaveChangesAsync().ConfigureAwait(false);
   }

   public async Task AddRangeAsync(IEnumerable<BookChapter> chapters)
   {
      await Chapters.AddRangeAsync(chapters).ConfigureAwait(false);
      await SaveChangesAsync().ConfigureAwait(false);
   }

   public async Task<IEnumerable<BookChapter>> GetAllAsync()
   {
      var chapters = await Chapters.ToListAsync().ConfigureAwait(false);
      return chapters;
   }

   public async Task<BookChapter?> FindAsync(Guid id)
   {
      var chapter = await Chapters.FindAsync(id).ConfigureAwait(false);
      return chapter;
   }

   public async Task<BookChapter?> RemoveAsync(Guid id)
   {
      var chapter = await Chapters.FindAsync(id).ConfigureAwait(false);
      if (chapter is not null)
      {
         Chapters.Remove(chapter);
         await SaveChangesAsync().ConfigureAwait(false);
      }

      return chapter;
   }

   public async Task<BookChapter?> UpdateAsync(BookChapter chapter)
   {
      Chapters.Update(chapter);
      await SaveChangesAsync().ConfigureAwait(false);
      return chapter;
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<BookChapter>().Property(b => b.Title).HasMaxLength(120);
   }
}