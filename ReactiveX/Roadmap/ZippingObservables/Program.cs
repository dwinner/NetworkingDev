// Поэлементное комбинирование результатов, при поступлении от нескольких потоков

using System;
using System.Linq;
using System.Reactive.Linq;

namespace ZippingObservables
{
   internal static class Program
   {
      private static void Main()
      {
         var onePrices = Observable.Interval(TimeSpan.FromSeconds(1)).Select(x => new Random().NextDouble() * 10).Take(4);
         var twoPrices = Observable.Interval(TimeSpan.FromSeconds(.5)).Select(x => new Random().NextDouble() * 10).Take(4);
         var cheapestPrices =
            Observable.Zip(onePrices, twoPrices)
               .Select(priceList => priceList.First() <= priceList.Last() ? priceList.First() : priceList.Last());
         cheapestPrices.Subscribe(Console.WriteLine);
         
         Console.ReadKey();
      }
   }
}