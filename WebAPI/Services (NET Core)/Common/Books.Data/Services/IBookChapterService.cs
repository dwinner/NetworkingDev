using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.Shared;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Books.Data.Services;

public interface IBookChapterService
{
   DatabaseFacade Database { get; }

   Task AddAsync(BookChapter chapter);

   Task AddRangeAsync(IEnumerable<BookChapter> chapters);

   Task<IEnumerable<BookChapter>> GetAllAsync();

   Task<BookChapter?> FindAsync(Guid id);

   Task<BookChapter?> RemoveAsync(Guid id);

   Task<BookChapter?> UpdateAsync(BookChapter chapter);
}