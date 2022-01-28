using Owin;

namespace PerfSurf
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.MapSignalR();
      }
   }
}