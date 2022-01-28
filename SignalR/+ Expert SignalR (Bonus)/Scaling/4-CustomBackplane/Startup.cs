using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Messaging;
using Owin;

namespace CustomBackplane
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var bus = new Lazy<FileSystemMessageBus>(
                          () => new FileSystemMessageBus(
                                     GlobalHost.DependencyResolver,
                                     new ScaleoutConfiguration())
            );
            
            GlobalHost.DependencyResolver.Register(
                          typeof(IMessageBus),
                          () => (object)bus.Value
            );
            app.MapSignalR();
        }
    }
}