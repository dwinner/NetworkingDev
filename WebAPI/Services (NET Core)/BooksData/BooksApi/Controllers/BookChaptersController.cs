using Books.Data.Services;
using Books.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers;

[Produces("application/json", "application/xml")]
[Route("api/[controller]")]
[ApiController]
public class BookChaptersController : ControllerBase
{
   private readonly IBookChapterService _chapterService;

   public BookChaptersController(IBookChapterService chapterService) => _chapterService = chapterService;

   // GET api/bookchapters/guid
   [HttpGet]
   public Task<IEnumerable<BookChapter>> GetBookChapters() => _chapterService.GetAllAsync();

   // GET api/bookchapters/guid
   [HttpGet("{id}", Name = nameof(GetBookChapterById))]
   public async Task<ActionResult<IEnumerable<BookChapter>>> GetBookChapterById(Guid id)
   {
      var chapter = await _chapterService.FindAsync(id).ConfigureAwait(false);
      if (chapter is null)
      {
         return NotFound();
      }

      return Ok(chapter);
   }

   // POST api/bookchapters
   [HttpPost]
   public async Task<ActionResult> PostBookChapter(BookChapter chapter)
   {
      if (string.IsNullOrEmpty(chapter.Title))
      {
         return BadRequest();
      }

      await _chapterService.AddAsync(chapter).ConfigureAwait(false);
      return CreatedAtRoute(nameof(GetBookChapterById), new { id = chapter.Id }, chapter);
   }

   // PUT api/bookchapters/guid
   [HttpPut("{id}")]
   public async Task<ActionResult> PutBookChapter(Guid id, BookChapter chapter)
   {
      if (string.IsNullOrEmpty(chapter.Title) || id != chapter.Id)
      {
         return BadRequest();
      }

      var existingChapter = await _chapterService.FindAsync(id).ConfigureAwait(false);
      if (existingChapter == null)
      {
         return NotFound();
      }

      var c = await _chapterService.UpdateAsync(chapter).ConfigureAwait(false);
      return c is null ? NotFound() : NoContent();
   }

   // DELETE api/bookchapters/5
   [HttpDelete("{id}")]
   public async Task<ActionResult> Delete(Guid id)
   {
      var existingChapter = await _chapterService.RemoveAsync(id).ConfigureAwait(false);
      return existingChapter is null ? NotFound() : Ok();
   }
}