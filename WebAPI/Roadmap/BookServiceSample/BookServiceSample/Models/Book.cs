using System.Collections.Generic;

namespace BookServiceSample.Models
{
   public class Book
   {
      public Book(int id, string title, params BookChapter[] bookChapters)
      {
         BookChapters = bookChapters;
         Id = id;
         Title = title;
      }

      public ICollection<BookChapter> BookChapters { get; private set; }

      public int Id { get; private set; }

      public string Title { get; private set; }
   }
}