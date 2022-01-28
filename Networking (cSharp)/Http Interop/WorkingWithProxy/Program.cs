/**
 * Работа с прокси-сервером
 */

using System.Net;

namespace WorkingWithProxy
{
   class Program
   {
      static void Main()
      {
         var proxy = new WebProxy("192.168.1.100", true)
         {
            Credentials = new NetworkCredential("user", "password", "domain")
         };
         WebRequest request = WebRequest.Create("http://www.reuters.com");
         request.Proxy = proxy;
         WebResponse response = request.GetResponse();
      }
   }
}
