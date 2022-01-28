using System.Web.Cors;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace EchoConnection
{
    public static class Startup
    {
        public static void Configuration(IAppBuilder app)
        {

            app.Map("/realtime/echo", map =>
                                      {
                                          map.UseCors(CorsOptions.AllowAll);
                                          map.RunSignalR<EchoConnection>();
                                      }

            );
        }
    }
}