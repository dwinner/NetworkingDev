using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using PerfSurf.Counters;

namespace PerfSurf.Hubs
{
   public class PerfHub : Hub
   {
      public PerfHub()
      {
         StartCounterCollection();
      }

      private void StartCounterCollection()
      {
         /*var task = */
         Task.Factory.StartNew(async () =>
         {
            var perfService = new PerfCounterService();
            while (true)
            {
               dynamic results = perfService.GetResults();
               Clients.All.newCounters(results);
               await Task.Delay(2000);
            }
            // ReSharper disable once FunctionNeverReturns
         }, TaskCreationOptions.LongRunning);
      }

      public void Send(string message)
      {
         Clients.All.newMessage(
            "{0} says {1}", Context.User.Identity.Name, message);
      }
   }
}