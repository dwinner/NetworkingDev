/**
 * Асинхронный модуль
 */

using System.Net;
using System.Web;

namespace AsyncWebApp
{
   public class AsyncModule : IHttpModule
   {
      public void Init(HttpApplication httpApp)
      {
         var helper = new EventHandlerTaskAsyncHelper(async (sender, args) =>
         {
            if (httpApp.Context.Request.Path == "/DisplayItemValue.aspx")
            {
               using (var client = new WebClient())
               {
                  var content = await client.DownloadStringTaskAsync("http://asp.net");
                  var app = sender as HttpApplication;
                  if (app != null)
                  {
                     app.Context.Items["length"] = content.Length;
                  }
               }
            }
         });

         httpApp.AddOnBeginRequestAsync(helper.BeginEventHandler, helper.EndEventHandler);
      }

      public void Dispose()
      {
      }
   }
}