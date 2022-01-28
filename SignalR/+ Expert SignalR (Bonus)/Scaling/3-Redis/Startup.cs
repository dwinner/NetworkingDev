using Microsoft.AspNet.SignalR;
using Owin;

namespace Redis
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.UseRedis(
                server: "localhost",
                port: 54321,
                password: "12345",
                eventKey: "Broadcaster"
            );
            app.MapSignalR();
        }
    }
}