using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Emso.WebUi.Infrastructure.Ifaces;
using EmsoHr.Entities;

namespace Emso.WebUi.Infrastructure.Impl
{
   /// <summary>
   ///    Default RSS feed source implementation
   /// </summary>
   public sealed class DatabaseRssFeedSourceImpl : IRssFeedSource
   {
      // TOREFACTOR: Существуют репозитории, которые используют тот же контекст (напрашивается шаблон Unit Of Work)
      private readonly EmsoHrEntities _hrEntities = new EmsoHrEntities();         

      public void Dispose()
      {
         _hrEntities.Dispose();
      }

      /// <summary>
      ///    Get all news
      /// </summary>
      /// <returns>Rss feeds</returns>
      public async Task<IEnumerable<NewsFeed>> GetAllNewsAsync()
      {
         var newsFeeds = _hrEntities.NewsFeeds;
         return await Task.Run<IEnumerable<NewsFeed>>(() => newsFeeds).ConfigureAwait(false);
      }

      /// <summary>
      ///    Get news
      /// </summary>
      /// <param name="id">News Id</param>
      /// <returns>News</returns>
      public async Task<NewsFeed> GetNewsAsync(int id)
      {
         return await _hrEntities.NewsFeeds.FindAsync(id).ConfigureAwait(false);
      }

      /// <summary>
      ///    Add news
      /// </summary>
      /// <param name="newsFeed">News feed</param>
      /// <returns>Added news</returns>
      public async Task<NewsFeed> AddNewsAsync(NewsFeed newsFeed)
      {
         var newFeed = _hrEntities.NewsFeeds.Add(newsFeed);
         await _hrEntities.SaveChangesAsync().ConfigureAwait(false);
         return newFeed;
      }

      /// <summary>
      ///    Remove news
      /// </summary>
      /// <param name="newsFeed">News feed</param>
      /// <returns>true, if news was successfully removed, false otherwise</returns>      
      public async Task<bool> RemoveNewsAsync(NewsFeed newsFeed)
      {
         var feed = await GetNewsAsync(newsFeed.Id).ConfigureAwait(false);
         if (feed == null)
         {
            return false;
         }

         _hrEntities.NewsFeeds.Remove(feed);
         var affected = await _hrEntities.SaveChangesAsync().ConfigureAwait(false);
         return affected > 0;
      }

      /// <summary>
      ///    Update news
      /// </summary>
      /// <param name="newsFeed">News feed</param>
      /// <returns>true, if news was successfully removed, false otherwise</returns>
      public async Task<bool> UpdateNewsAsync(NewsFeed newsFeed)
      {
         int affected = 0;
         var newsFeedToUpdate =
            await
               _hrEntities.NewsFeeds.FirstOrDefaultAsync(feed => feed.Id == newsFeed.Id).ConfigureAwait(false);
         if (newsFeedToUpdate != null)
         {
            newsFeedToUpdate.ImageData = newsFeed.ImageData;
            newsFeedToUpdate.ImageMimeType = newsFeed.ImageMimeType;
            newsFeedToUpdate.NewsDate = DateTime.Now;
            newsFeedToUpdate.Details = newsFeed.Details;
            newsFeedToUpdate.RelatedLink = newsFeed.RelatedLink;
            newsFeedToUpdate.Title = newsFeed.Title;
            affected += await _hrEntities.SaveChangesAsync().ConfigureAwait(false);
         }
         
         return affected > 0;
      }
   }
}