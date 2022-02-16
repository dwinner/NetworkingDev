using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Emso.WebUi.Infrastructure.Ifaces;
using Emso.WebUi.ViewModels;

namespace Emso.WebUi.Services
{
   [RoutePrefix("newsfeed")]
   public class NewsFeedController : ApiController
   {
      private readonly IRssFeedSource _feedSource;
      private readonly IPagingConfiguration _pagingConfiguration;

      public NewsFeedController(IRssFeedSource feedSource, IPagingConfiguration pagingConfiguration)
      {
         _feedSource = feedSource;
         _pagingConfiguration = pagingConfiguration;
      }

      [Route("all/{page:int}")]
      public async Task<IEnumerable<RssFeedViewModel>> GetAllAsync(int page = 1)
      {
         var newsFeeds = await _feedSource.GetAllNewsAsync().ConfigureAwait(false);         
#if DEBUG
         await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
#endif         
         var feedVms =
            newsFeeds.Select(Mapper.Map<RssFeedViewModel>).OrderByDescending(rssModel => rssModel.NewsDate)
               .Skip((page - 1)* _pagingConfiguration.PageSize)
               .Take(_pagingConfiguration.PageSize);
         return feedVms;
      }

      [Route("navConfig")]
      public async Task<NavigationInfo> GetNavigatorConfigAsync()
      {
         // PERFORMANCE-NOTE: Явное проседание производительности (Нужно добавить в интерфейс IRssFeedSource метод, возвращающий общее ко-во записей)
         var newsFeeds = await _feedSource.GetAllNewsAsync().ConfigureAwait(false);
         var totalCount = newsFeeds.Count();
         return new NavigationInfo
         {            
            ItemsPerPageCount = _pagingConfiguration.PageSize,
            TotalItemsCount = totalCount         
         };
      }

      [Route("newsImage/{newsId:int}")]
      public async Task<HttpResponseMessage> GetNewsImageAsync(int newsId)
      {
         var newsFeed = await _feedSource.GetNewsAsync(newsId).ConfigureAwait(false);
         if (newsFeed == null)
         {
            return new HttpResponseMessage(HttpStatusCode.NotFound);
         }

         var imageData = newsFeed.ImageData;
         var mimeType = newsFeed.ImageMimeType;
         HttpResponseMessage response;
         using (var imageStream = new MemoryStream(imageData))
         {
            response = new HttpResponseMessage(HttpStatusCode.OK)
            {
               Content = new ByteArrayContent(imageStream.ToArray())
            };
         }

         response.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
         return response;
      }
   }
}