using Microsoft.Owin;
using Owin;
using SignalrMvc;

[assembly: OwinStartup(typeof(Startup))]

namespace SignalrMvc
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.MapSignalR();
      }
   }
}