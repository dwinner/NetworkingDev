// Настройка DI-контейнера

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Web.Infrastructure.Abstract;
using SportsStore.Web.Infrastructure.Concrete;

namespace SportsStore.Web.Infrastructure
{
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
         // Здесь размещаются привязки

         #region Mock

         //var mock = new Mock<IProductRepository>();
         //mock.Setup(repository => repository.Products).Returns(new List<Product>
         //{
         //   new Product {Name = "Football", Price = 25},
         //   new Product {Name = "Surf board", Price = 179},
         //   new Product {Name = "Running shoes", Price = 95}
         //});
         //_kernel.Bind<IProductRepository>().ToConstant(mock.Object);

         #endregion

         _kernel.Bind<IProductRepository>().To<EfProductRepository>();

         var emailSettings = new EmailSettings
         {
            WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? default(bool).ToString())
         };

         _kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
         _kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
      }
   }
}