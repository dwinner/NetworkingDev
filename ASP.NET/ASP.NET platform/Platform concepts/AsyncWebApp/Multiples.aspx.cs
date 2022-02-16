using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.UI;

namespace AsyncWebApp
{
   public partial class Multiples : Page
   {
      private readonly string[] _targetUrls =
      {
         "http://asp.net",
         "http://apress.com",
         "http://google.com"
      };

      private ConcurrentQueue<MultiWebSiteResult> _results;

      protected void Page_Load(object sender, EventArgs e)
      {
         _results = new ConcurrentQueue<MultiWebSiteResult>();

         #region Параллельное выполнение с особождением потока обработки запроса

         RegisterAsyncTask(new PageAsyncTask(async () =>
         {
            var tasks = _targetUrls.Select(localUrl => Task.Factory.StartNew(() =>
            {
               var result = new MultiWebSiteResult
               {
                  Url = localUrl,
                  StartTime = (long)DateTime.Now.Subtract(Context.Timestamp).TotalMilliseconds
               };
               using (var webClient = new WebClient())
               {
                  var content = webClient.DownloadString(localUrl);
                  result.Length = content.Length;
               }
               _results.Enqueue(result);
            })).ToList();

            await Task.WhenAll(tasks);
            MultRepeater.DataBind();
         }));

         #endregion

         #region Последовательное выполнение с освобождением потока обработки запроса

         //foreach (var targetUrl in _targetUrls)
         //{
         //   var result = new MultiWebSiteResult {Url = targetUrl};
         //   _results.Enqueue(result);
         //   var localUrl = targetUrl;
         //   RegisterAsyncTask(new PageAsyncTask(async () =>
         //   {
         //      result.StartTime = (long) DateTime.Now.Subtract(Context.Timestamp).TotalMilliseconds;
         //      using (var client = new WebClient())
         //      {
         //         var webContent = await client.DownloadStringTaskAsync(localUrl);
         //         result.Length = webContent.Length;
         //         MultRepeater.DataBind();
         //      }
         //   }));
         //}

         #endregion
      }

      public IEnumerable<MultiWebSiteResult> GetResults()
      {
         return _results;
      }
   }

   public class MultiWebSiteResult
   {
      public string Url { get; set; }
      public long Length { get; set; }
      public long StartTime { get; set; }
   }
}