/**
 * Загрузка содержимого WEB-страницы по протоколу HTTP
 */

using System;
using System.Net;

namespace WebDownloader
{
   class Program
   {
      private const string DefaultUrl = "http://www.microsoft.com";
      private const string DefaultOutputFile = "microsoft_main_page.html";

      static void Main(string[] args)
      {
         string url, outputfile;

         if (args.Length < 2)
         {
            url = DefaultUrl;
            outputfile = DefaultOutputFile;
         }
         else
         {
            url = args[0];
            outputfile = args[1];
         }

         using (WebClient client = new WebClient())
         {
            // Такой вариант тоже сработал бы: byte[] bytes = client.DownloadData(url);
            try
            {
               client.DownloadFile(url, outputfile);
            }
            catch (WebException ex)
            {
               Console.WriteLine(ex.Message);
            }
         }

         Console.ReadKey();
      }
   }
}
