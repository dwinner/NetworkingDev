using System;
using System.Net;
using System.Threading.Tasks;
using Books.Data.Services;
using Books.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Books_Function;

public class BooksService
{
   private readonly IBookChapterService _bookChapterService;

   public BooksService(IBookChapterService bookChapterService) => _bookChapterService =
      bookChapterService ?? throw new ArgumentNullException(nameof(bookChapterService));

   [Function("AddChapter")]
   public async Task<HttpResponseData> AddChapterAsync(
      [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "chapters")]
      HttpRequestData req,
      FunctionContext executionContext)
   {
      var logger = executionContext.GetLogger("BooksService");
      logger.LogInformation("Function AddChapter invoked.");

      var chapter = await req.ReadFromJsonAsync<BookChapter>().ConfigureAwait(false);
      if (chapter is null)
      {
         logger.LogError("invalid chapter received");
         return req.CreateResponse(HttpStatusCode.BadRequest);
      }

      var response = req.CreateResponse(HttpStatusCode.OK);
      await _bookChapterService.AddAsync(chapter).ConfigureAwait(false);
      await response.WriteAsJsonAsync(chapter).ConfigureAwait(false);
      return response;
   }

   [Function("GetChapters")]
   public async Task<HttpResponseData> GetChaptersAsync(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "chapters")]
      HttpRequestData req,
      FunctionContext executionContext)
   {
      var logger = executionContext.GetLogger("BooksService");
      logger.LogInformation("Function GetChapters invoked.");

      var response = req.CreateResponse(HttpStatusCode.OK);
      var chapters = _bookChapterService.GetAllAsync();
      await response.WriteAsJsonAsync(chapters).ConfigureAwait(false);
      return response;
   }
}