/**
 * HTTP-запросы
 */

using System;
using System.Net;

namespace HttpWebRequestSample
{
   class Program
   {
      static void Main()
      {
         WebRequest webRequest = WebRequest.Create("http://www.google.ru");
         var httpWebRequest = webRequest as HttpWebRequest;
         if (httpWebRequest != null)
         {
            Console.WriteLine("Request timeout: {0}", httpWebRequest.Timeout);
            Console.WriteLine("Request Keep Alive: {0}", httpWebRequest.KeepAlive);
            Console.WriteLine("Request AllowAutoRedirect: {0}", httpWebRequest.AllowAutoRedirect);
         }
      }
   }
}
