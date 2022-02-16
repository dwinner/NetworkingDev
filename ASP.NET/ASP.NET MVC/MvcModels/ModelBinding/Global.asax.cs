using System.Web.Mvc;
using System.Web.Routing;
using ModelBinding.Infrastructure;
using ModelBinding.Models;

namespace ModelBinding
{
   public class MvcApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         RouteConfig.RegisterRoutes(RouteTable.Routes);

         // Регистрация фабрики поставщиков значений
         ValueProviderFactories.Factories.Insert(0, new CustomValueProviderFactory());

         // Регистрация специального связывателя модели
         ModelBinders.Binders.Add(typeof(AddressSummary), new AddressSummaryBinder());
      }
   }
}
