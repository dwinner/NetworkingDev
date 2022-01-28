using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace HubsSample.Hubs
{
   [HubName("SecondHub")]
   public class SecondHub : Hub
   {
      public void SendMessage(string text)
      {
         Clients.Others.displayText(text);
      }
   }
}