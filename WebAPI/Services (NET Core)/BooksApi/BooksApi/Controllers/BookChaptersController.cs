using Books.Shared;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class BookChaptersController : ControllerBase
{
   private readonly IBookChapterService _chapterService;

   public BookChaptersController(IBookChapterService chapterService) => _chapterService = chapterService;

   // GET api/bookchapters
   [ProducesResponseType(StatusCodes.Status200OK)]
   [HttpGet]
   public Task<IEnumerable<BookChapter>> GetBookChapters() => _chapterService.GetAllAsync();

   // GET api/bookchapters/guid
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   [HttpGet("{id}", Name = nameof(GetBookChapterById))]
   public async Task<ActionResult<BookChapter>> GetBookChapterById(Guid id)
   {
      var chapter = await _chapterService.FindAsync(id).ConfigureAwait(false);
      if (chapter is null)
      {
         return NotFound();
      }

      return Ok(chapter);
   }

   // POST api/bookchapters
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   [ProducesResponseType(StatusCodes.Status201Created)]
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
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   [ProducesResponseType(StatusCodes.Status204NoContent)]
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

      var updatedChapter = await _chapterService.UpdateAsync(chapter).ConfigureAwait(false);
      if (updatedChapter is null)
      {
         return NotFound();
      }

      return NoContent();
   }

   // DELETE api/bookchapters/5
   [ProducesResponseType(StatusCodes.Status200OK)]
   [HttpDelete("{id}")]
   public async Task<ActionResult> Delete(Guid id)
   {
      await _chapterService.RemoveAsync(id).ConfigureAwait(false);
      return Ok();
   }
}