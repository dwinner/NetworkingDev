using System;
using System.Web.UI;
using WebCache = System.Web.Caching.Cache;

namespace Caching
{
   public partial class Default : Page
   {
      private const string CacheKey = "codebehind_ts";

      // Cache.Insert(CacheKey, ts, null, DateTime.Now.AddSeconds(20), System.Web.Caching.Cache.NoSlidingExpiration);   // 20 сек: абсолютное время истечения
      // Cache.Insert(CacheKey, ts, null, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(10), CacheItemPriority.Normal, HandleRemoveNotification); // 10 сек: скользящее время истечения

      protected string GetTime()
      {
         string ts;
         var stObject = Cache[CacheKey] as StCacheObject<string>;
         ts = stObject == null
            ? new StCacheObject<string>(CacheKey, GenerateTimeStamp).Data
            : stObject.Data + " <b>(Cached)</b>";

         //if (ts == null)
         //   ts = UpdateCache();
         //else
         //   ts += " <b>(Cached)</b>";

         return ts;
      }

      private string GenerateTimeStamp()
      {
         return DateTime.Now.ToLongTimeString();
      }

      /*
            private string UpdateCache()
            {
               string longTimeString = DateTime.Now.ToLongTimeString();
               Cache.Insert(CacheKey, longTimeString, null, WebCache.NoAbsoluteExpiration, TimeSpan.FromSeconds(10),
                  HandleUpdateNotification);
               //Cache.Insert(CacheKey, longTimeString, null, WebCache.NoAbsoluteExpiration, TimeSpan.FromSeconds(10),
               //   CacheItemPriority.Normal, HandleRemoveNotification);
               return longTimeString;
            }
      */

      /*
            private void HandleRemoveNotification(string key, object value, CacheItemRemovedReason reason)
            {
               if (reason == CacheItemRemovedReason.Expired)
               {
                  UpdateCache(); // Безотложное обновление кэша
                  Debug.WriteLine("Cache item {0} ejected: {1}", key, reason);
               }
            }
      */

      /*
            private void HandleUpdateNotification(string key, CacheItemUpdateReason updateReason, out object data,
               out CacheDependency cacheDependency, out DateTime absoluteExpiry, out TimeSpan slidingExpiry)
            {
               data = cacheDependency = null;
               slidingExpiry = WebCache.NoSlidingExpiration;
               absoluteExpiry = WebCache.NoAbsoluteExpiration;

               if (updateReason == CacheItemUpdateReason.Expired) // Предотвращение удаления из кэша
               {
                  data = DateTime.Now.ToLongTimeString();
                  slidingExpiry = TimeSpan.FromSeconds(10);
                  Debug.WriteLine("Item {0} updates", key);
               }
            }
      */
   }
}