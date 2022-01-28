using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using StockTicker.Web.Models;
using Ticker = StockTicker.Web.Businesslogic.StockTicker;

namespace StockTicker.Web.Hubs
{
   [HubName("stockTicker")]
   public class StockTickerHub : Hub
   {
      private readonly Ticker _stockTicker;

      public StockTickerHub() : this(Ticker.Instance) { }

      private StockTickerHub(Ticker stockTicker)
      {
         _stockTicker = stockTicker;
      }

      public IEnumerable<Stock> GetAllStocks() => _stockTicker.GetAllStocks();

      public string GetMarketState() => _stockTicker.MarketState.ToString();

      public void OpenMarket() => _stockTicker.OpenMarket();

      public void CloseMarket() => _stockTicker.CloseMarket();

      public void Reset() => _stockTicker.Reset();
   }
}