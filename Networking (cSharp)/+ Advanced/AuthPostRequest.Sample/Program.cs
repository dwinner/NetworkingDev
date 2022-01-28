/**
 * Аутентифицированный POST-запрос
 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AuthPostRequest.Sample
{
   internal static class Program
   {
      private static void Main()
      {
         const string sampleDomain = "https://www.google.com";
         Tuple<string, string>[] postData =
         {
            Tuple.Create("key1", "value1"),
            Tuple.Create("key2", "value2"),
            Tuple.Create("key3", "value3"),
            Tuple.Create("key4", "value4")
         };
         var credentials = new KeyValuePair<string, string>("user", "password");
         var uriBuilder = new UriBuilder("https", "www.google.com", 80, "auth/api");
         var proxyAddress = uriBuilder.Uri;
         IWebProxy proxy = new WebProxy(proxyAddress);
         var encoding = Encoding.Default;
         var requestHelper = new AuthPostRequestHelper(sampleDomain, postData, credentials, proxy, encoding);
         //var result = requestHelper.ApplyAsync().Result;
         var result = requestHelper.Apply();
         Console.WriteLine(result);
      }
   }
}