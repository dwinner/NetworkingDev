using Microsoft.Owin;
using Owin;
using PersistentConMvc;
using PersistentConMvc.Connection;

[assembly: OwinStartup(typeof (Startup))]

namespace PersistentConMvc
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.MapSignalR<ChatConnection>("/chat");
      }
   }
}