using System.Diagnostics;

namespace PerfSurf.Counters
{
   public class PerfCounterWrapper
   {
      private readonly PerformanceCounter _counter;

      public PerfCounterWrapper(string name, string category, string counter, string instance = "")
      {
         _counter = new PerformanceCounter(category, counter, instance, true);
         Name = name;
      }

      public string Name { get; private set; }

      public float Value
      {
         get { return _counter.NextValue(); }
      }      
   }
}