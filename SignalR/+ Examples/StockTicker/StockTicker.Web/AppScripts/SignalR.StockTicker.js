/// <reference path="~/Scripts/jquery-2.1.4.js" />
/// <reference path="~/Scripts/jquery.signalR-2.2.0.js" />

/**
 * ASP.NET SignalR Stock Ticker Sample
 */

// Простейший функционал шаблона
if (!String.prototype.supplant) {
   // ReSharper disable NativeTypePrototypeExtending
   String.prototype.supplant = function (o) {
      // ReSharper restore NativeTypePrototypeExtending
      return this.replace(/{([^{}]*)}/g,
         function (a, b) {
            var r = o[b];
            return typeof r === "string" || typeof r === "number" ? r : a;
         });
   };
}

// Простой flash-эффект
jQuery.fn.flash = function (color, duration) {
   var current = this.css("backgroundColor");
   this.animate({ backgroundColor: "rgb(" + color + ")" }, duration / 2)
      .animate({ backgroundColor: current }, duration / 2);
};

$(function () {

   var ticker = $.connection.stockTicker;
   var up = "▲";
   var down = "▼";
   var $stockTable = $("#stockTable");
   var $stockTableBody = $stockTable.find("tbody");
   var rowTemplate = '<tr data-symbol="{Symbol}"><td>{Symbol}</td><td>{Price}</td><td>{DayOpen}</td><td>{DayHigh}</td><td>{DayLow}</td><td><span class="dir {DirectionClass}">{Direction}</span> {Change}</td><td>{PercentChange}</td></tr>';
   var $stockTicker = $("#stockTicker");
   var $stockTickerUl = $stockTicker.find("ul");
   var liTemplate = '<li data-symbol="{Symbol}"><span class="symbol">{Symbol}</span> <span class="price">{Price}</span> <span class="change"><span class="dir {DirectionClass}">{Direction}</span> {Change} ({PercentChange})</span></li>';

   function formatStock(stock) {
      return $.extend(stock, {
         Price: stock.Price.toFixed(2),
         PercentChange: (stock.PercentChange * 100).toFixed(2) + "%",
         Direction: stock.Change === 0 ? "" : stock.Change >= 0 ? up : down,
         DirectionClass: stock.Change === 0 ? "even" : stock.Change >= 0 ? "up" : "down"
      });
   }

   function scrollTicker() {
      var w = $stockTickerUl.width();
      $stockTickerUl.css({ marginLeft: w });
      $stockTickerUl.animate({ marginLeft: -w }, 15000, 'linear', scrollTicker);
   }

   function stopTicker() {
      $stockTickerUl.stop();
   }

   function init() {
      return ticker.server.getAllStocks().done(function (stocks) {
         $stockTableBody.empty();
         $stockTickerUl.empty();
         $.each(stocks, function () {
            var stock = formatStock(this);
            $stockTableBody.append(rowTemplate.supplant(stock));
            $stockTickerUl.append(liTemplate.supplant(stock));
         });
      });
   }

   // hub-методы клиентской стороны, которые вызывают сервер
   $.extend(ticker.client, {
      updateStockPrice: function (stock) {
         var displayStock = formatStock(stock);
         var $row = $(rowTemplate.supplant(displayStock));
         var $li = $(liTemplate.supplant(displayStock));
         var bg = stock.LastChange < 0 ? "255,148,148" : "154,240,117";

         $stockTableBody.find("tr[data-symbol=" + stock.Symbol + "]")
            .replaceWith($row);
         $stockTickerUl.find("li[data-symbol=" + stock.Symbol + "]")
            .replaceWith($li);

         $row.flash(bg, 1000);
         $li.flash(bg, 1000);
      },

      marketOpened: function () {
         $("#open").prop("disabled", true);
         $("#close").prop("disabled", false);
         $("#reset").prop("disabled", true);
         scrollTicker();
      },

      marketClosed: function () {
         $("#open").prop("disabled", false);
         $("#close").prop("disabled", true);
         $("#reset").prop("disabled", false);
         stopTicker();
      },

      marketReset: function () {
         return init();
      }
   });

   // Запускаем подключение
   $.connection.hub.start()
      .then(init)
      .then(function () {
         return ticker.server.getMarketState();
      })
      .done(function (state) {
         if (state === 'Open') {
            ticker.client.marketOpened();
         } else {
            ticker.client.marketClosed();
         }

         $("#open").click(function () {
            ticker.server.openMarket();
         });

         $("#close").click(function () {
            ticker.server.closeMarket();
         });

         $("#reset").click(function () {
            ticker.server.reset();
         });
      });
});