using Books.Data.Services;
using Books.Shared;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GRPCService.Services;

internal static class ChapterExtensions
{
   public static BookChapter ToBookChapter(this Chapter chapter) =>
      new(
         Guid.Parse(chapter.Id),
         chapter.Number,
         chapter.Title,
         chapter.PageCount);

   public static Chapter ToGrpcChapter(this BookChapter chapter) =>
      new()
      {
         Id = chapter.Id.ToString(),
         Number = chapter.Number,
         Title = chapter.Title,
         PageCount = chapter.PageCount
      };
}

public class BooksService : GRPCBooks.GRPCBooksBase
{
   private readonly IBookChapterService _bookChapterService;
   private readonly ILogger _logger;

   public BooksService(ILogger<BooksService> logger, IBookChapterService bookChapterService)
   {
      _logger = logger;
      _bookChapterService = bookChapterService;
   }

   public override async Task<AddBookChapterResponse> AddBookChapter(AddBookChapterRequest request,
      ServerCallContext context)
   {
      var bookChapter = request.Chapter.ToBookChapter();
      await _bookChapterService.AddAsync(bookChapter).ConfigureAwait(false);
      AddBookChapterResponse response = new()
      {
         Chapter = bookChapter.ToGrpcChapter()
      };
      return response;
   }

   public override async Task<GetBookChapterResponse> GetBookChapters(Empty request, ServerCallContext context)
   {
      var bookChapters = await _bookChapterService.GetAllAsync().ConfigureAwait(false);
      GetBookChapterResponse response = new();
      response.Chapters.AddRange(bookChapters.Select(bc => bc.ToGrpcChapter()).ToArray());
      return response;
   }
}