/**
 * Потребление службы WebAPI
 */

using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using BookServiceSample.Models;

namespace BookServiceClientApp
{
   internal class Program
   {
      private const string BaseAddress = "http://localhost:4642";
      private const string AllBookChaptersAddress = "/api/bookchapter";

      private static void Main()
      {
         Console.WriteLine("Client app wait for service");
         Console.ReadLine();

         ReadArraySample().Wait();
         ReadSampleXml().Wait();
         ReadWithExtensionsSample().Wait();
         AddSample().Wait();
         UpdateSample().Wait();
         DeleteSample().Wait();

         Console.ReadLine();
      }

      private static async Task ReadArraySample() // NOTE: Получение данных в формате JSON
      {
         string response;
         using (var client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
         {
            response = await client.GetStringAsync(AllBookChaptersAddress);
         }

         Console.WriteLine(response);

         var serializer = new JavaScriptSerializer();
         var chapters = serializer.Deserialize<BookChapter[]>(response);

         foreach (BookChapter chapter in chapters)
         {
            Console.WriteLine(chapter.Title);
         }
      }

      private static async Task ReadSampleXml() // NOTE: Получение данных ы формате XML
      {
         string response;
         using (var client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
         {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            response = await client.GetStringAsync(AllBookChaptersAddress);
         }

         XElement chapter = XElement.Parse(response);
         Console.WriteLine(chapter);
      }

      private static async Task ReadWithExtensionsSample()
      // NOTE: Использование расширений для специального форматирования
      {
         HttpResponseMessage responseMessage;
         using (var client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
         {
            responseMessage = await client.GetAsync("/api/bookchapters/3");
         }

         BookChapter chapter = await responseMessage.Content.ReadAsAsync<BookChapter>();
         Console.WriteLine("{0}. {1}", chapter.Number, chapter.Title);
      }

      private static async Task AddSample() // NOTE: Использование POST-запросов на добавление
      {
         var newChapter = new BookChapter
         {
            Title = "ASP.NET Web API",
            Number = 44,
            Pages = 29
         };

         HttpResponseMessage response;
         using (var client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
         {
            HttpContent content = new ObjectContent<BookChapter>(newChapter, new JsonMediaTypeFormatter());
            response = await client.PostAsync("/api/bookchapters", content);
         }

         response.EnsureSuccessStatusCode();
         await ReadArraySample();
      }

      private static async Task UpdateSample() // NOTE: Запросы PUT на обновление
      {
         using (var client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
         {
            var chapterToUpdate = new BookChapter
            {
               Title = "Visual Studio 2013",
               Number = 17,
               Pages = 50
            };

            /*HttpResponseMessage responseMessage = */
            await client.PutAsJsonAsync("/api/bookchapters/17", chapterToUpdate);
         }

         await ReadArraySample();
      }

      private static async Task DeleteSample()  // NOTE: Запросы на удаление
      {
         try
         {
            HttpResponseMessage response;
            using (var client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
            {
               response = await client.DeleteAsync("/api/bookchapters/42");
            }
            response.EnsureSuccessStatusCode();

            await ReadArraySample();
         }
         catch (HttpRequestException ex)
         {
            Console.WriteLine(ex.Message);
         }
      }
   }
}