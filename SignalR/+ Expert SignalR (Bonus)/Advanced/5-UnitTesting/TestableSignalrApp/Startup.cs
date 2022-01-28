using Microsoft.AspNet.SignalR;
using Owin;
using TestableSignalrApp.Model;

namespace TestableSignalrApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.Register(typeof(Broadcaster), () => new Broadcaster(new Domain(new Calculator())));
            app.MapSignalR();
            app.MapSignalR<EchoConnection>("/echo");
        }
    }
}