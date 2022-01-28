using Owin;
using PersistentConnSample.PersistentConnections;

namespace PersistentConnSample
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.MapSignalR<SamplePersistentConnection>("/SamplePC");
      }
   }
}