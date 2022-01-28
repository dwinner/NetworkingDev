/**
 * Асинхронные запросы страниц
 */

using System;
using System.Net;

namespace ApmWebRequest
{
   class Program
   {
      private const string GoogleMainDomain = "http://www.google.ru";

      static void Main()
      {
         ApmRequest();
         TapRequest();
         Console.ReadKey();
      }

      public static void ApmRequest()  // Запрос асинхронным шаблоном
      {
         WebRequest request = WebRequest.Create(GoogleMainDomain);
         request.BeginGetResponse(asyncResult =>
         {
            var webRequest = asyncResult.AsyncState as WebRequest;
            if (webRequest != null)
            {
               WebResponse webResponse = webRequest.EndGetResponse(asyncResult);
               PrintHeaders(webResponse);
            }
         }, request);
      }

      public static async void TapRequest()  // Запрос через задачи продолжения
      {
         WebRequest request = WebRequest.Create(GoogleMainDomain);
         PrintHeaders(await request.GetResponseAsync());
      }

      private static void PrintHeaders(WebResponse webResponse)
      {
         WebHeaderCollection webHeaderCollection = webResponse.Headers;
         foreach (string headerKey in webHeaderCollection)
         {
            Console.WriteLine("{0}: {1}", headerKey, webHeaderCollection[headerKey]);
         }
      }
   }
}
