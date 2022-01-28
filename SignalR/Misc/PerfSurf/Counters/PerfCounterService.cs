using System.Collections.Generic;
using System.Linq;

namespace PerfSurf.Counters
{
   public class PerfCounterService
   {
      private readonly List<PerfCounterWrapper> _counters;

      public PerfCounterService()
      {
         _counters = new List<PerfCounterWrapper>
         {
            new PerfCounterWrapper("Processor", "Processor", "% Processor Time", "_Total"),
            new PerfCounterWrapper("Paging", "Memory", "Pages/sec"),
            new PerfCounterWrapper("Disk", "PhysicalDisk", "% Disk Time", "_Total")
         };
      }

      public dynamic GetResults()
      {
         return _counters.Select(c => new { name = c.Name, value = c.Value });
      }
   }
}