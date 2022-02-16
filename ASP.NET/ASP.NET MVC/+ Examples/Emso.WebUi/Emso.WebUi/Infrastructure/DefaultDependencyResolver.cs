using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Http.Dependencies;
using Emso.Configuration;
using Emso.WebUi.Infrastructure.Ifaces;
using Emso.WebUi.Infrastructure.Impl;
using Ninject;
using Ninject.Web.WebApi;
using MvcResolver = System.Web.Mvc.IDependencyResolver;
using WebApiResolver = System.Web.Http.Dependencies.IDependencyResolver;

namespace Emso.WebUi.Infrastructure
{
   /// <summary>
   ///    Dependency injection composition root for ASP.NET MVC, WebApi
   /// </summary>
   public sealed class DefaultDependencyResolver : MvcResolver, WebApiResolver
   {
      private readonly IKernel _kernel;

      public DefaultDependencyResolver(IKernel kernel)
      {
         _kernel = kernel;
         AddBindings();
      }

      public object GetService(Type serviceType)
      {
         return _kernel.TryGet(serviceType);
      }

      public IEnumerable<object> GetServices(Type serviceType)
      {
         return _kernel.GetAll(serviceType);
      }

      public IDependencyScope BeginScope()
      {
         return new NinjectDependencyScope(_kernel.BeginBlock());
      }

      public void Dispose()
      {
         _kernel.Dispose();
      }

      private void AddBindings()
      {
         _kernel.Bind<IContactSender>().To<EmailContactSender>();
         _kernel.Bind<IRssFeedSource>().To<DatabaseRssFeedSourceImpl>();

         string sliderPath = WebConfigurationManager.AppSettings["DefaultSliderPath"];
         string imagePattern = WebConfigurationManager.AppSettings["DefaultImagePattern"];
         _kernel.Bind<ISliderSource>()
            .To<PhysicalPathSliderSource>()
            .WithConstructorArgument("relativeServerPath", sliderPath)
            .WithConstructorArgument("imagePattern", imagePattern);

         _kernel.Bind<ICredentials>().To<ConfigCredentials>().InSingletonScope();
         _kernel.Bind<IRecipientCollection>().To<ConfigRecipients>().InSingletonScope();
         _kernel.Bind<IJobVacancyRepository>().To<SqlServerEfJobVacancyRepository>();
         _kernel.Bind<IPagingConfiguration>().To<WebConfigPagingConfiguration>().InSingletonScope();
         _kernel.Bind<IResumeManagerRepository>().To<DatabaseResumeManager>();
      }
   }   
}