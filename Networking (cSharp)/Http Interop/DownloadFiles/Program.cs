/**
 * Простейший способ загрузки файлов по сети
 */

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace DownloadFiles
{
   class Program
   {
      private const string DefaultAddress = "http://vk.com/id32863838";
      private const string DefaultFileName = "johnny.html";

      static void Main()
      {
         var continueTask = DownloadFileAsync();
         continueTask.Wait();
         DownloadToStream();
      }

      #region Загрузка файла по сети

      public static async Task DownloadFileAsync(string address = DefaultAddress, string fileName = DefaultFileName)
      {
         var client = new WebClient();
         await client.DownloadFileTaskAsync(address, fileName);
      }

      public static void DonwloadFile(string address = DefaultAddress, string fileName = DefaultFileName)
      {
         var client = new WebClient();
         client.DownloadFile(address, fileName);
      }

      #endregion

      #region Загрузка файла в поток

      public static void DownloadToStream()
      {
         const string url = "http://www.pornotube.name/porno/599743.html?party";
         var webClient = new WebClient();
         using (Stream stream = webClient.OpenRead(url))
         {
            if (stream == null)
            {
               return;
            }

            using (var inputStream = new StreamReader(stream))
            {
               string currentLine;
               while ((currentLine = inputStream.ReadLine()) != null)
               {
                  if (currentLine.IndexOf("mp", StringComparison.Ordinal) != -1)
                  {
                     Console.WriteLine(currentLine);
                  }
               }
            }
         }
      }

      #endregion
   }
}
