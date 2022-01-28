using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace DependencyResolver.Extensions
{
    public class CustomProxyGenerator : IJavaScriptProxyGenerator
    {
        private DefaultJavaScriptProxyGenerator _generator;

        public CustomProxyGenerator()
        {
            _generator = new DefaultJavaScriptProxyGenerator(
                 GlobalHost.DependencyResolver
            );
        }

        public new string GenerateProxy(string serviceUrl)
        {
            var proxy = _generator.GenerateProxy(serviceUrl);
            proxy += "\n\n"
                     + "// Please don't use this code from the dark side";
            return proxy;
        }
    }

}