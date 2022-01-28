using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Hub.WebServer.HubEndpoints;
using Microsoft.AspNet.SignalR;

namespace Hub.WebServer.Models
{
   public static class BidManager
   {
      private static Timer _timer = new Timer(BidInterval, null, 0, 2000);

      private static readonly List<Bid> Items = new List<Bid>
      {
         new Bid {Name = "Bike", Description = "10 Speed", TimeLeft = 30, BidPrice = 120.0},
         new Bid {Name = "Car", Description = "Sports Car", TimeLeft = 30, BidPrice = 1500.0},
         new Bid {Name = "TV", Description = "Big screen TV", TimeLeft = 30, BidPrice = 330.0},
         new Bid {Name = "Boat", Description = "Party Boat", TimeLeft = 30, BidPrice = 1200.0}
      };

      public static Bid CurrentBid { get; set; }

      public static void Start()
      {
      }

      private static void BidInterval(object o)
      {
         var clients = GlobalHost.ConnectionManager.GetHubContext<AuctionHub>().Clients;
         if (CurrentBid == null || CurrentBid.TimeLeft <= 0)
         {
            SetBid();
         }

         Debug.Assert(CurrentBid != null, "BidManager.CurrentBid != null");
         CurrentBid.TimeLeft -= 2;
         if (CurrentBid.TimeLeft <= 0)
         {
            clients.AllExcept(CurrentBid.ConnectionId).CloseBid();
            if (!string.IsNullOrWhiteSpace(CurrentBid.ConnectionId))
            {
               clients.Client(CurrentBid.ConnectionId).CloseBidWin(CurrentBid);
            }
         }

         clients.All.UpdateBid(CurrentBid);
      }

      private static void SetBid()
      {
         var rnd = new Random();
         CurrentBid = Items[rnd.Next(0, Items.Count - 1)].Clone();
      }
   }
}