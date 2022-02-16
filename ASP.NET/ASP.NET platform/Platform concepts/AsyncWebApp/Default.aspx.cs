using System;
using System.Diagnostics;
using System.Net;
using System.Web.UI;

namespace AsyncWebApp
{
   public partial class Default : Page
   {
      private const string TargetUrl = "http://asp.net";
      private WebSiteResult _result;

      protected void Page_Load(object sender, EventArgs e)
      {
         _result = new WebSiteResult { Url = TargetUrl };
         Stopwatch stopwatch = Stopwatch.StartNew();
         RegisterAsyncTask(new PageAsyncTask(async () =>
         {
            using (var client = new WebClient())
            {
               string webContent = await client.DownloadStringTaskAsync(TargetUrl);
               _result.Length = webContent.Length;
               // NOTE: Без учета других событий жизненного цикла
               _result.Total = (long)DateTime.Now.Subtract(Context.Timestamp).TotalMilliseconds;               
            }            
         }));

         _result.Blocked = stopwatch.ElapsedMilliseconds;
      }

      protected WebSiteResult GetResult()
      {
         return _result;
      }
   }

   public class WebSiteResult
   {
      public string Url { get; set; }
      public long Length { get; set; }
      public long Blocked { get; set; }
      public long Total { get; set; }
   }
}