using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using IWebApiDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;
using SignalrDefaultDependencyResolver = Microsoft.AspNet.SignalR.DefaultDependencyResolver;

namespace GroupBrush.Web.Unity
{
   public class UnityDependencyResolver : SignalrDefaultDependencyResolver, IWebApiDependencyResolver
   {
      private readonly IUnityContainer _container = new UnityContainer();

      public UnityDependencyResolver()         
      {
      }

      private UnityDependencyResolver(IUnityContainer container)
      {
         _container = container;
      }

      public override object GetService(Type serviceType) // WebAPI, SignalR impl
      {
         try
         {
            return _container.Resolve(serviceType);
         }
         catch
         {
            return base.GetService(serviceType);
         }
      }

      public override IEnumerable<object> GetServices(Type serviceType) // WebAPI, SignalR impl
      {
         try
         {
            var services = _container.ResolveAll(serviceType).ToList();
            var defaultService = GetService(serviceType);
            if (defaultService != null)
            {
               services.Add(defaultService);
            }

            return services;
         }
         catch
         {
            return base.GetServices(serviceType);
         }
      }

      public IDependencyScope BeginScope() // WebAPI impl
      {
         return new UnityDependencyResolver(_container.CreateChildContainer());
      }

      public override void Register(Type serviceType, IEnumerable<Func<object>> activators) // SignalR impl
      {
         _container.RegisterType(serviceType,
            new InjectionFactory(
               container =>
               {
                  return
                     activators.Select(activator => activator.Invoke()).FirstOrDefault(tempObject => tempObject != null);
               }));

         base.Register(serviceType, activators);
      }

      public override void Register(Type serviceType, Func<object> activator) // SignalR impl
      {
         _container.RegisterType(serviceType, new InjectionFactory(container => activator.Invoke()));
         base.Register(serviceType, activator);
      }

      public void RegisterType<TFrom, TTo>(params InjectionMember[] injectionMembers)
         where TTo : TFrom
      {
         _container.RegisterType<TFrom, TTo>(injectionMembers);
      }

      public void RegisterType<TFrom, TTo>(LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
         where TTo : TFrom
      {
         _container.RegisterType<TFrom, TTo>(lifetimeManager, injectionMembers);
      }

      public void RegisterInstance<TInterface>(TInterface instance)
      {
         _container.RegisterInstance(instance);
      }
   }
}