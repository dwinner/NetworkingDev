using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;
using Ninject.Web.Common;

namespace EssentialTools.Infrastructure
{
   /// <summary>
   ///    Распознаватель зависимостей
   /// </summary>
   public class NinjectDependencyResolver : IDependencyResolver
   {
      private readonly IKernel _kernel;

      public NinjectDependencyResolver(IKernel kernel)
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

      private void AddBindings()
      {
         // Область действия запроса
         _kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();
         _kernel.Bind<IDiscountHelper>()
            .To<DefaultDiscountHelper>() /*.WithPropertyValue("DiscountSize", 50M)*/
            .WithConstructorArgument("discountSize", 50M);
         // Условная привязка
         _kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
      }
   }
}