/**
 * WebAPI-контроллер c конкретными именами маршрутов
 */

using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BookServiceSample.Models;

namespace BookServiceSample.Controllers
{
   // [RoutePrefix("booksamples")] NOTE: Если нужен одинаковый префикс маршрута 
   public class BookChaptersAttrController : ApiController
   {
      private static readonly List<BookChapter> Chapters;
      private static readonly List<Book> Books;

      static BookChaptersAttrController()
      {
         Chapters = new List<BookChapter>
         {
            new BookChapter {Number = 1, Title = ".NET Architecture", Pages = 20},
            new BookChapter {Number = 2, Title = "Core C#", Pages = 42},
            new BookChapter {Number = 3, Title = "Objects and Types", Pages = 24},
            new BookChapter {Number = 4, Title = "Inheritance", Pages = 18},
            new BookChapter {Number = 5, Title = "Generics", Pages = 22},
            new BookChapter {Number = 17, Title = "Visual Studio 2012", Pages = 50},
            new BookChapter {Number = 42, Title = "ASP.NET Dynamic Data", Pages = 14}
         };

         Books = new List<Book>
         {
            new Book(1, "Professional C# 5 and .NET 4.5.1", Chapters.ToArray()),
            new Book(2, "Professional ASP.NET MVC 4")
         };
      }

      [Route("books/{bookId}")]
      public IEnumerable<BookChapter> GetBookChapters(int bookId)
      {
         return Books.Single(book => book.Id == bookId).BookChapters;
      }

      [Route("books/{bookId:int}/chapters/{chapterId:int}")]
      // [Route("{bookId:int}/{chapterId:int}")] NOTE: Если используется префикс маршрута
      public BookChapter GetBookChapter(int bookId, int chapterId)
      {
         return
            Books.Single(book => book.Id == bookId).BookChapters.SingleOrDefault(chapter => chapter.Number == chapterId);
      }

      // POST api/bookchapters
      public void PostBookChapter([FromBody] BookChapter value)
      {
         Chapters.Add(value);
      }

      // PUT api/bookchapters/5
      public void PutBookChapter(int id, [FromBody] BookChapter value)
      {
         Chapters.Remove(Chapters.Single(c => c.Number == id));
         Chapters.Add(value);
      }

      // DELETE api/bookchapters/5
      public void DeleteBookChapter(int id)
      {
         Chapters.Remove(Chapters.Single(c => c.Number == id));
      }
   }
}