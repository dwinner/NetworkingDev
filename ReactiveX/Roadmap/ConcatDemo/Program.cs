// Конканетация потоковых коллекций объектов

using System;
using System.Reactive.Linq;

namespace ConcatDemo
{
   internal static class Program
   {
      private static void Main()
      {
         var range1 = Observable.Range(11, 5).Select(x => (long) x);
         var range2 = Observable.Interval(TimeSpan.FromSeconds(.5)).Take(5);
         range1.Concat(range2).Subscribe(l => Console.Write("{0} ", l));
         Console.WriteLine();
      }
   }
}