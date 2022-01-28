using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BookServiceSample.Models;

namespace BookServiceSample.Controllers
{
   public class BookChapterController : ApiController
   {
      private static readonly List<BookChapter> Chapters;

      static BookChapterController()
      {
         Chapters = new List<BookChapter>
         {
            new BookChapter {Number = 1, Title = ".NET Architecture", Pages = 20},
            new BookChapter {Number = 2, Title = "Core C#", Pages = 42},
            new BookChapter {Number = 3, Title = "Objects and Types", Pages = 24},
            new BookChapter {Number = 4, Title = "Inheritance", Pages = 18},
            new BookChapter {Number = 5, Title = "Generics", Pages = 22},
            new BookChapter {Number = 6, Title = "Visual Studio 2012", Pages = 50},
            new BookChapter {Number = 7, Title = "ASP.NET Dynamic Data", Pages = 14},
         };
      }

      // GET api/bookchapter
      // NOTE: добавьте [HttpGet], если метод не имеет префикса Get
      public IEnumerable<BookChapter> GetBookChapters()
      {
         return Chapters;
      }

      // GET api/bookchapter/5
      public BookChapter GetBookChapter(int id)
      {
         return Chapters.SingleOrDefault(chapter => chapter.Number == id);
      }

      // POST api/bookchapter
      // [AcceptVerbs("POST")]
      // [ActionName("bookchapter")]
      public void PostBookChapter([FromBody] BookChapter value)
      {
         Chapters.Add(value);
      }

      // PUT api/bookchapter/5
      public IHttpActionResult PutBookChapter(int id, [FromBody] BookChapter value)
      {
         BookChapter bookChapter = Chapters.SingleOrDefault(chapter => chapter.Number == id);
         if (bookChapter != null)
         {
            bookChapter.Title = value.Title;
            bookChapter.Pages = value.Pages;
            return Ok();
         }

         return BadRequest();
      }

      // DELETE api/bookchapter/5
      public void DeleteBookChapter(int id)
      {
         Chapters.Remove(Chapters.Single(chapter => chapter.Number == id));
      }
   }
}