using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmsoHr.Entities;

namespace Emso.WebUi.Infrastructure.Ifaces
{
   /// <summary>
   ///    Rss feed source interface
   /// </summary>
   public interface IRssFeedSource : IDisposable
   {
      /// <summary>
      ///    Get all news
      /// </summary>
      /// <returns>Rss feeds</returns>
      Task<IEnumerable<NewsFeed>> GetAllNewsAsync();

      /// <summary>
      ///    Get news
      /// </summary>
      /// <param name="id">News Id</param>
      /// <returns>News</returns>
      Task<NewsFeed> GetNewsAsync(int id);

      /// <summary>
      ///    Add news
      /// </summary>
      /// <param name="newsFeed">News feed</param>
      /// <returns>Added news</returns>
      Task<NewsFeed> AddNewsAsync(NewsFeed newsFeed);

      /// <summary>
      ///    Remove news
      /// </summary>
      /// <param name="newsFeed">News feed</param>
      /// <returns>true, if news was successfully removed, false otherwise</returns>
      Task<bool> RemoveNewsAsync(NewsFeed newsFeed);

      /// <summary>
      ///    Update news
      /// </summary>
      /// <param name="newsFeed">News feed</param>
      /// <returns>true, if news was successfully removed, false otherwise</returns>
      Task<bool> UpdateNewsAsync(NewsFeed newsFeed);
   }
}