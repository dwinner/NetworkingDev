using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.Practices.Unity;

namespace IocUnity.Extensions
{
    public class UnityDependencyResolver : DefaultDependencyResolver
    {
        private readonly UnityContainer _container;
        public UnityDependencyResolver(UnityContainer container)
        {
            _container = container;
        }

        public override object GetService(Type serviceType)
        {
            if (_container.IsRegistered(serviceType))
            {
                return _container.Resolve(serviceType);
            }
            return base.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType)
                .Concat(base.GetServices(serviceType));
        }
    }
}