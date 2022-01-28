using Microsoft.Owin;
using Owin;
using StockTicker.Web;

[assembly: OwinStartup(typeof (Startup))]

namespace StockTicker.Web
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.MapSignalR();
      }
   }
}