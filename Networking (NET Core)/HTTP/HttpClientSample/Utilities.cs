using System;
using System.Net.Http.Headers;

namespace HttpClientSample
{
   public static class Utilities
   {
      public static void ShowHeaders(string title, HttpHeaders headers)
      {
         Console.WriteLine(title);
         foreach (var (key, value) in headers)
         {
            var val = string.Join(" ", value);
            Console.WriteLine($"Header: {key}. Value: {val}");
         }

         Console.WriteLine();
      }
   }
}