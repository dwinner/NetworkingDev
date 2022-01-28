using IocNinject.Extensions;
using IocNinject.Model;
using Microsoft.AspNet.SignalR;
using Ninject;
using Owin;

namespace IocNinject
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var kernel = new StandardKernel();

            kernel.Bind<IClock>().To<Clock>().InSingletonScope();
            kernel.Bind<IMessageFormatter>().To<MessageFormatter>();

            app.MapSignalR(new HubConfiguration()
                           {
                               Resolver = new NinjectDependencyResolver(kernel)
                           });
        }

    }
}