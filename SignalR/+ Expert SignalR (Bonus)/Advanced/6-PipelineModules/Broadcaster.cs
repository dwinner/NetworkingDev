using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using PipelineModules.Modules;

namespace PipelineModules
{
    public class Broadcaster: Hub
    {
        public override Task OnConnected()
        {
            return Clients.All.Message("New connection " + Context.ConnectionId);
        }

        [OnlyOn(Weekday.Thursday | Weekday.Friday | Weekday.Saturday | Weekday.Sunday)]
        public Task WeekendMessage(string message)
        {
            return Clients.All.Message(message + ". Let's party!");
        }
    }
}