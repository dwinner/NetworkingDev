// Потоковый генератор

using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace ObserveGenerator
{
   internal static class Program
   {
      private static void Main()
      {
         var seed = new KeyValuePair<int, int>(0, 1);
         var fibo = Observable.Generate(
            seed, // Начальное значение
            pair => true, // Предикат остановки запуска
            pair => new KeyValuePair<int, int>(pair.Value, pair.Key + pair.Value), // Шаг итерации
            pair => pair.Key // Возвращаемое значение
            ).Take(10);
         fibo.Subscribe(val => { Console.Write("{0} ", val); });
         Console.WriteLine();
      }
   }
}