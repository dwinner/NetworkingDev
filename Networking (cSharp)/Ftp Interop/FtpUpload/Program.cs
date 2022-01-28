/**
 * Выгрузка файла по протоколу FTP
 */

using System;
using System.IO;
using System.Net;
using System.Text;

namespace FtpUpload
{
   internal static class Program
   {
      private static void Main(string[] args)
      {
         if (args.Length < 4)
         {
            Console.WriteLine("Usage: FtpUpload host username password file");
            return;
         }

         var host = args[0];
         var username = args[1];
         var password = args[2];
         var file = args[3];
         if (!host.StartsWith("ftp://"))
         {
            host = "ftp://" + host;
         }
         var uri = new Uri(host);
         var info = new FileInfo(file);
         var destFileName = host + "/" + info.Name;
         try
         {
            /*
             * Хотя это FTP-протокол, мы можем использовать класс WebClient,
             * который распознает ftp:// и воспользоваться правильным протоколом в своем коде
             */
            var client = new WebClient {Credentials = new NetworkCredential(username, password)};
            var response = client.UploadFile(destFileName, file);
            if (response.Length > 0)
            {
               Console.WriteLine("Response: {0}", Encoding.ASCII.GetString(response));
            }
         }
         catch (WebException ex)
         {
            Console.WriteLine(ex.Message);
         }
      }
   }
}