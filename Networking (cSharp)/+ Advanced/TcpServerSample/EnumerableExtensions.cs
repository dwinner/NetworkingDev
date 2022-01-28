using System;
using System.Collections.Generic;

namespace TcpServerSample
{
   public static class EnumerableExtensions
   {
      public static void Action<T>(this IEnumerable<T> collection, Action<T> action)
      {
         foreach (var element in collection)
         {
            action(element);
         }
      }
   }
}