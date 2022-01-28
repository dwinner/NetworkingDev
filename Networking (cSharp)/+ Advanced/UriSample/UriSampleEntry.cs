/**
 * URI sample
 */

using System;
using static System.Console;

namespace UriSample
{
   internal static class UriSampleEntry
   {
      private const string Amazon =
         "http://www.amazon.com/Professional-C-6-0-Christian-Nagel/dp/111909660X/ref=sr_1_4?ie=UTF8&amqid=1438459506&sr=8-4&keywords=professional+c%23+6";

      private static void Main()
      {
         UriTest(Amazon);
         UriBuilderTest();
      }

      private static void UriTest(string url)
      {
         var page = new Uri(url);
         WriteLine("Scheme: {0}", page.Scheme);
#if NET46
         WriteLine("Host : {0}, Type: {1}", page.Host, page.HostNameType);
#else
         System.Console.WriteLine("Host: {0}, Type: {1}, Idn Host: {2}",
            page.Host,
            page.HostNameType,
            page.IdnHost);
#endif
         WriteLine("Port: {0}", page.Port);
         WriteLine("Path: {0}", page.AbsolutePath);
         WriteLine("Query: {0}", page.Query);
         foreach (var segment in page.Segments)
         {
            WriteLine("Segment: {0}", segment);
         }
      }

      private static void UriBuilderTest()
      {
         var uri = new UriBuilder {Host = "www.cinnovation.com", Port = 80, Path = "training/MVC"}.Uri;
         WriteLine(uri);
      }
   }
}