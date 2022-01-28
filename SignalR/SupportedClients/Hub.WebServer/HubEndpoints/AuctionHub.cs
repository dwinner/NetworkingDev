using System.Threading.Tasks;
using Hub.WebServer.Models;

namespace Hub.WebServer.HubEndpoints
{
   public class AuctionHub : Microsoft.AspNet.SignalR.Hub
   {
      public AuctionHub()
      {
         BidManager.Start();
      }

      public override Task OnConnected()
      {
         Clients.Caller.CloseBid();
         Clients.All.updateBid(BidManager.CurrentBid);

         return base.OnConnected();
      }

      public void MakeCurrentBid()
      {
         BidManager.CurrentBid.BidPrice += 1;
         BidManager.CurrentBid.ConnectionId = Context.ConnectionId;
         Clients.All.updateBid(BidManager.CurrentBid);
      }

      public void MakeBid(double bidPrice)
      {
         if (bidPrice < BidManager.CurrentBid.BidPrice)
         {
            return;
         }

         BidManager.CurrentBid.BidPrice = bidPrice;
         BidManager.CurrentBid.ConnectionId = Context.ConnectionId;
         Clients.All.updateBid(BidManager.CurrentBid);
      }
   }
}