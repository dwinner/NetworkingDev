/**
 * Реализация кэширования вывода из обобщенных обработчиков
 */

using System;
using System.IO;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.UI;

namespace CachingOutput
{
   /// <summary>
   ///    Фабрика обработчиков для кеширования *.ashx-файлов
   /// </summary>
   public class CachingHandlerFactory : IHttpHandlerFactory
   {
      private const int DefaultExpiry = 60;

      public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
      {
         string response = GetFromCache(context, pathTranslated);
         if (response == null)
         {
            var handler =
               BuildManager.CreateInstanceFromVirtualPath(context.Request.Path, typeof(IHttpHandler)) as IHttpHandler;
            using (var writer = new StringWriter())
            {
               context.Server.Execute(new PageWrapper(handler), writer, true);
               response = writer.ToString();
            }

            AddToCache(context, pathTranslated, response);
         }

         return new CachedResponseHandler(response);
      }

      public void ReleaseHandler(IHttpHandler handler)
      {
      }

      #region Служебные классы

      /// <summary>
      ///    Обработчик для ранее кэшированного ответа
      /// </summary>
      private class CachedResponseHandler : IHttpHandler
      {
         private readonly string _response;

         public CachedResponseHandler(string response)
         {
            _response = response;
         }

         public void ProcessRequest(HttpContext context)
         {
            context.Response.Write(_response);
         }

         public bool IsReusable
         {
            get { return false; }
         }
      }

      /// <summary>
      ///    Адаптер из IHttpHandler в Page
      /// </summary>
      private class PageWrapper : Page
      {
         private readonly IHttpHandler _wrappedHandler;

         public PageWrapper(IHttpHandler handler)
         {
            _wrappedHandler = handler;
         }

         public override void ProcessRequest(HttpContext context)
         {
            _wrappedHandler.ProcessRequest(context);
         }
      }

      #endregion

      private static void AddToCache(HttpContext context, string path, string output)
      {
         OutputCacheProvider defaultOutputCacheProvider = OutputCache.Providers[OutputCache.DefaultProviderName];
         if (defaultOutputCacheProvider != null)
            defaultOutputCacheProvider.Add(path, output, DateTime.Now.AddSeconds(DefaultExpiry));
         else
            context.Cache.Add(path, output, null, DateTime.Now.AddSeconds(DefaultExpiry), Cache.NoSlidingExpiration,
               CacheItemPriority.Low, null);
      }

      private static string GetFromCache(HttpContext context, string path)
      {
         OutputCacheProvider defaultOutputCacheProvider = OutputCache.Providers[OutputCache.DefaultProviderName];
         return defaultOutputCacheProvider != null
            ? defaultOutputCacheProvider.Get(path) as string
            : context.Cache.Get(path) as string;
      }
   }
}