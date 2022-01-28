using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNet.SignalR;

namespace DependencyResolver.Extensions
{
    public class MyDependencyResolver : DefaultDependencyResolver
    {
        public override object GetService(Type serviceType)
        {
            var result = base.GetService(serviceType);
            var msg = string.Format(
                 "*** Requested type {0}, provided: {1}",
                 serviceType.Name,
                 result == null ? "null" : result.GetType().Name
            );
            Debug.WriteLine(msg);
            return result;
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            var results = base.GetServices(serviceType);
            var msg = string.Format(
                 "*** Requested type {0}, provided: {1}",
                 serviceType.Name,
                 string.Join(",",
                             results.Select(o => o.GetType().Name))
            );
            Debug.WriteLine(msg);
            return results;
        }
    }
}