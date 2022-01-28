using System;
using System.IO;
using System.Web.Caching;
using System.Web.UI;

namespace Caching
{
   public partial class CitiesControl : UserControl
   {
      private const string FileName = "/CitiesList.html";
      private const string TimeCacheKey = "cities_time";
      private const string HtmlCacheKey = "cities_html";

      private bool _cached;

      protected string GetCities()
      {
         var html = Cache[HtmlCacheKey] as string;
         if (html == null)
         {
            html = File.ReadAllText(MapPath(FileName));

            var aggregateCacheDependency = new AggregateCacheDependency(); // Создание агрегатной зависимости
            var countDependency = new RequestCountDependency(3); // Собственная зависимость
            var cacheDependency = new CacheDependency(MapPath(FileName)); // Зависимость от изменения файла
            aggregateCacheDependency.Add(countDependency, cacheDependency);

            Cache.Insert(HtmlCacheKey, html, aggregateCacheDependency);
         }
         else
         {
            _cached = true;
         }

         return html;
      }

      protected string GetTimeStamp()
      {
         var timeStamp = Cache[TimeCacheKey] as string;
         if (timeStamp == null)
         {
            timeStamp = DateTime.Now.ToLongTimeString();
            Cache.Insert(TimeCacheKey, timeStamp,
               new CacheDependency(null, new[] { HtmlCacheKey })); // NOTE: Внутренняя зависимость
         }

         return timeStamp + (_cached ? " <b>Cached</b>" : string.Empty);
      }
   }
}