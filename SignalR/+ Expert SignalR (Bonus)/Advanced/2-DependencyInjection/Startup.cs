using System;
using DependencyResolver.Extensions;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Owin;
namespace DependencyResolver
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver = new MyDependencyResolver();

            var minifier = new Lazy<MyJavascriptMinifier>(
                        () => new MyJavascriptMinifier()
            );
            GlobalHost.DependencyResolver.Register(
                typeof(IJavaScriptMinifier), () => minifier.Value
            );

            var generator = new Lazy<CustomProxyGenerator>(() => new CustomProxyGenerator());
            GlobalHost.DependencyResolver.Register(
                typeof(IJavaScriptProxyGenerator),
                () => generator.Value
            );

            app.MapSignalR();
        }
    }
}