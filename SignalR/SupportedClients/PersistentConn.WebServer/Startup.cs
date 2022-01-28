using Owin;
using PersistentConn.WebServer.PerCon;

namespace PersistentConn.WebServer
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.MapSignalR<SamplePersistentConnection>("/SamplePC");
      }
   }
}