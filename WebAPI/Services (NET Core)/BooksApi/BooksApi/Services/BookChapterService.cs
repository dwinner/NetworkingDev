using System.Collections.Concurrent;
using Books.Shared;

namespace BooksApi.Services;

public class BookChapterService : IBookChapterService
{
   private readonly ConcurrentDictionary<Guid, BookChapter> _chapters = new();

   public Task AddAsync(BookChapter chapter)
   {
      chapter = GetInitializedId(chapter);
      _chapters[chapter.Id] = chapter;

      return Task.CompletedTask;
   }

   public Task AddRangeAsync(IEnumerable<BookChapter> chapters)
   {
      foreach (var c in chapters)
      {
         var chapter = GetInitializedId(c);
         _chapters[chapter.Id] = chapter;
      }

      return Task.CompletedTask;
   }

   public Task<BookChapter?> FindAsync(Guid id)
   {
      _chapters.TryGetValue(id, out var chapter);
      return Task.FromResult(chapter);
   }

   public Task<IEnumerable<BookChapter>> GetAllAsync() =>
      Task.FromResult<IEnumerable<BookChapter>>(_chapters.Values.OrderBy(c => c.Number));

   public Task<BookChapter?> RemoveAsync(Guid id)
   {
      _chapters.TryRemove(id, out var removed);
      return Task.FromResult(removed);
   }

   public async Task<BookChapter?> UpdateAsync(BookChapter chapter)
   {
      var existingChapter = await FindAsync(chapter.Id).ConfigureAwait(false);
      if (existingChapter is null)
      {
         return null;
      }

      _chapters[chapter.Id] = chapter;
      return chapter;
   }

   private static BookChapter GetInitializedId(BookChapter chapter)
   {
      if (chapter.Id == Guid.Empty)
      {
         chapter = chapter with { Id = Guid.NewGuid() };
      }

      return chapter;
   }
}