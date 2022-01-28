/**
 * Простейший спосоп выгрузки файлов
 */

using System;
using System.IO;
using System.Net;

namespace UploadFiles
{
   class Program
   {
      static void Main()
      {
         PutFileOnServer();
         UploadingData();
      }

      public static void PutFileOnServer()   // Выгрузка файла методом PUT
      {
         try
         {
            var webClient = new WebClient();
            Stream stream = webClient.OpenWrite("http://localhost/newfile.txt", "PUT");
            using (var writer = new StreamWriter(stream))
            {
               writer.WriteLine("Hello World");
            }
         }
         catch (WebException webEx)
         {
            Console.WriteLine(webEx.Message);
            Console.WriteLine("Status: {0}", webEx.Status);
         }
      }

      public static void UploadingData()  // Выгрузка целого файла
      {
         var webClient = new WebClient();
         const string fileName = "Sliders.rar";
         webClient.UploadFile("http://localhost", fileName);   //webClient.UploadData("http://localhost", byte[])         
      }
   }
}
