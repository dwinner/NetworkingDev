using FirstSample.PersistentConnections;
using Owin;

namespace FirstSample
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.MapSignalR<SamplePersistentConnection>("/SamplePC");         
      }
   }
}