using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;

namespace ConsoleHosting
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll)
                .MapSignalR<PingConnection>("/ping-connection")
                .MapSignalR("/hub", new HubConfiguration());
        }
    }
}