/**
 * Создание специальной реализации кэша вывода
 */

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Web.Caching;

namespace CachingOutput
{
   public class CustomOutputCache : OutputCacheProvider
   {
      private readonly ConcurrentDictionary<string, CacheItem> _cache;

      public CustomOutputCache()
      {
         _cache = new ConcurrentDictionary<string, CacheItem>();
      }

      public override object Get(string key)
      {
         if (_cache.ContainsKey(key))
         {
            CacheItem item = _cache[key];
            if (!item.Expired)
            {
               Debug.WriteLine(string.Format("Get: Cache contains item: {0}", key));
               return item.Data;
            }

            Debug.WriteLine(string.Format("Get: Expired item: {0}", key));
         }
         else
         {
            Debug.WriteLine(string.Format("Get: No item: {0}", key));
         }

         return null;
      }

      public override object Add(string key, object entry, DateTime utcExpiry)
      {
         if (_cache.ContainsKey(key) && !_cache[key].Expired)
         {
            Debug.WriteLine(string.Format("Add: Cache already contains item: {0}", key));
            return Get(key);
         }

         Debug.WriteLine(string.Format("Add: Adding new item: {0}", key));
         Set(key, entry, utcExpiry);

         return entry;
      }

      public override void Set(string key, object entry, DateTime utcExpiry)
      {
         Debug.WriteLine(string.Format("Set: {0}", key));
         _cache[key] = new CacheItem
         {
            Data = entry,
            Expiry = utcExpiry
         };
      }

      public override void Remove(string key)
      {
         Debug.WriteLine(string.Format("Remove: {0}", key));
         if (_cache.ContainsKey(key))
            _cache[key] = null;
      }

      private class CacheItem
      {
         public object Data { get; set; }
         public DateTime Expiry { private get; set; }

         public bool Expired
         {
            get { return DateTime.UtcNow > Expiry; }
         }
      }
   }
}