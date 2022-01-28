using Microsoft.Owin;
using Owin;
using SignalRDraw;

[assembly: OwinStartup(typeof(Startup))]

namespace SignalRDraw
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.MapSignalR();
      }
   }
}