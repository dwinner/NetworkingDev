// Объединение потоковых последовательностей

using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;

namespace MergingObservables
{
   internal static class Program
   {
      private static void Main()
      {
         var slow = GetSomeTokens().ToObservable();
         var fast = GetSomeTokensFast().ToObservable();
         var mergedStream = slow.Merge(fast);
         mergedStream.Subscribe(Console.WriteLine);

         Console.ReadLine();
      }

      private static IEnumerable<string> GetSomeTokensFast()
      {
         string[] names = { "A", "B", "C", "D", "E", "F", "G" };
         foreach (var name in names)
         {
            Thread.Sleep(new Random().Next(500));
            yield return name;
         }
      }

      private static IEnumerable<string> GetSomeTokens()
      {
         string[] names = { "Af", "fB", "fD", "fE", "fF", "fG" };
         foreach (var name in names)
         {
            Thread.Sleep(new Random().Next(500));
            yield return name;
         }
      }
   }
}