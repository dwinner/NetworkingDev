using IocUnity.Extensions;
using IocUnity.Model;
using Microsoft.AspNet.SignalR;
using Microsoft.Practices.Unity;
using Owin;

namespace IocUnity
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = new UnityContainer();

            container.RegisterType<IClock, Clock>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMessageFormatter, MessageFormatter>();
            container.RegisterType<Broadcaster>();

            app.MapSignalR(new HubConfiguration()
                        {
                            Resolver = new UnityDependencyResolver(container)
                        });
        }
    }
}