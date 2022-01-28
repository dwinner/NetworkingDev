using Microsoft.AspNet.SignalR;
using Owin;

namespace HubsSample
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         var hubConfig = new HubConfiguration { EnableJSONP = true };
         app.MapSignalR("/simpleHub", hubConfig);
      }
   }
}