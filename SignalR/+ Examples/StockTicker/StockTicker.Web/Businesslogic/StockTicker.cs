using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using StockTicker.Web.Hubs;
using StockTicker.Web.Models;
using static System.TimeSpan;

namespace StockTicker.Web.Businesslogic
{
   public sealed class StockTicker
   {
      private static readonly Lazy<StockTicker> TickerInstance = new Lazy<StockTicker>(
         () => new StockTicker(GlobalHost.ConnectionManager.GetHubContext<StockTickerHub>().Clients));

      private readonly object _marketStateLock = new object();
      private const double RangePercent = 2E-3;
      private readonly ConcurrentDictionary<string, Stock> _stocks = new ConcurrentDictionary<string, Stock>();
      private readonly TimeSpan _updateInterval = FromMilliseconds(250);
      private readonly Random _updateOrNotRandom = new Random();
      private readonly object _updateStockPricesLock = new object();
      private volatile MarketState _marketState;
      private Timer _timer;
      private volatile bool _updatingStockPrices;

      private StockTicker(IHubConnectionContext<dynamic> clients)
      {
         Clients = clients;
         LoadDefaultStocks();
      }

      public MarketState MarketState
      {
         get { return _marketState; }
         private set { _marketState = value; }
      }

      public IHubConnectionContext<dynamic> Clients { get; set; }

      public static StockTicker Instance => TickerInstance.Value;


      private void LoadDefaultStocks()
      {
         _stocks.Clear();

         var stocks = new List<Stock>
         {
            new Stock {Symbol = "MSFT", Price = 41.68m},
            new Stock {Symbol = "AAPL", Price = 92.08m},
            new Stock {Symbol = "GOOG", Price = 543.01m}
         };

         stocks.ForEach(stock => _stocks.TryAdd(stock.Symbol, stock));
      }

      public IEnumerable<Stock> GetAllStocks() => _stocks.Values;

      public void OpenMarket()
      {
         lock (_marketStateLock)
         {
            if (MarketState == MarketState.Open)
            {
               return;
            }

            _timer = new Timer(UpdateStockPrices, null, _updateInterval, _updateInterval);
            MarketState = MarketState.Open;
            BroadcastMarketStateChange(MarketState.Open);
         }
      }

      private void BroadcastMarketStateChange(MarketState marketState)
      {
         switch (marketState)
         {
            case MarketState.Closed:
               Clients.All.marketClosed();
               break;

            case MarketState.Open:
               Clients.All.marketOpened();
               break;
         }
      }

      private void UpdateStockPrices(object state)
      {
         lock (_updateStockPricesLock)
         {
            if (_updatingStockPrices)
            {
               return;
            }

            try
            {
               _updatingStockPrices = true;
               foreach (var stock in _stocks.Values.Where(TryUpdateStockPrice))
               {
                  BroadcastStockPrice(stock);
               }
            }
            finally
            {
               _updatingStockPrices = false;
            }
         }
      }

      private void BroadcastStockPrice(Stock stockToBroadcast) => Clients.All.updateStockPrice(stockToBroadcast);

      private bool TryUpdateStockPrice(Stock stockToUpdate)
      {
         var d = _updateOrNotRandom.NextDouble();
         if (d > 0.1)
         {
            return false;
         }

         var random = new Random((int)Math.Floor(stockToUpdate.Price));
         var percentChange = random.NextDouble() * RangePercent;
         var pos = random.NextDouble() > 0.51;
         var change = Math.Round(stockToUpdate.Price * (decimal)percentChange, 2);
         change = pos ? change : -change;
         stockToUpdate.Price += change;

         return true;
      }

      public void CloseMarket()
      {
         lock (_marketStateLock)
         {
            if (MarketState != MarketState.Open)
            {
               return;
            }

            _timer?.Dispose();
            MarketState = MarketState.Closed;
            BroadcastMarketStateChange(MarketState.Closed);
         }
      }

      public void Reset()
      {
         lock (_marketStateLock)
         {
            if (MarketState != MarketState.Closed)
            {
               throw new InvalidOperationException("Market must be closed before it can be reset.");
            }

            LoadDefaultStocks();
            BroadcastMarketReset();
         }
      }

      private void BroadcastMarketReset() => Clients.All.marketReset();
   }

   public enum MarketState
   {
      Closed,
      Open
   }
}