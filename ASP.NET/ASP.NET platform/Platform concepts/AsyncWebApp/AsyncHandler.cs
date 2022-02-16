/**
 * Создание асинхронных обработчиков
 */

using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace AsyncWebApp
{
   public class AsyncHandler : HttpTaskAsyncHandler
   {
      public override async Task ProcessRequestAsync(HttpContext context)
      {
         using (var client = new WebClient())
         {
            var content = await client.DownloadStringTaskAsync("http://asp.net");
            context.Response.ContentType = "text/plain";
            context.Response.Write(string.Format("The length of the result is: {0}", content.Length));
         }
      }
   }
}