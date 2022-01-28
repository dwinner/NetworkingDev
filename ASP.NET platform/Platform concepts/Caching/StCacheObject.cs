using System;
using System.Web;
using System.Web.Caching;

namespace Caching
{
   /// <summary>
   ///    Адаптивный подход к обновлению кэшированных данных
   /// </summary>
   /// <typeparam name="T">Параметр типа хранения в кэше</typeparam>
   public class StCacheObject<T>
   {
      private const int DefaultThreshold = 100;

      private readonly int _renewThreshold;
      private readonly Func<T> _updateCallback;
      private int _accessedCounter;
      private T _dataObject;

      public StCacheObject(string key, Func<T> callback, int threshold = DefaultThreshold)
      {
         _updateCallback = callback;
         _dataObject = _updateCallback();
         _renewThreshold = threshold;

         HttpContext.Current.Cache.Insert(key, this, null, Expiry, Cache.NoSlidingExpiration, HandleUpdateCallback);
      }

      public T Data
      {
         get
         {
            _accessedCounter++;
            return _dataObject;
         }
      }

      private DateTime Expiry
      {
         get { return DateTime.Now.AddSeconds(10); }
      }

      private void HandleUpdateCallback(string key, CacheItemUpdateReason reason, out object data,
         out CacheDependency dependency, out DateTime absExpiry, out TimeSpan slidingExpiry)
      {
         bool renew = _accessedCounter >= _renewThreshold;
         if (renew)
         {
            _dataObject = _updateCallback();
            _accessedCounter = 0;
         }

         data = renew ? this : null;
         dependency = null;
         slidingExpiry = Cache.NoSlidingExpiration;
         absExpiry = renew ? Expiry : Cache.NoAbsoluteExpiration;
      }
   }
}