using Microsoft.Owin;
using Owin;
using PushNotifyApp;

[assembly: OwinStartup(typeof (Startup))]

namespace PushNotifyApp
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.MapSignalR();
      }
   }
}