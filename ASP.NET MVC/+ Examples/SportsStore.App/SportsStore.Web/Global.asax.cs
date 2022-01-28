using System.Web.Mvc;
using System.Web.Routing;
using SportsStore.Domain.Entites;
using SportsStore.Web.Infrastructure.Binders;

namespace SportsStore.Web
{
   public class MvcApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         ModelBinders.Binders.Add(typeof (Cart), new CartModelBinder());   // Регистрация связывателя модели
      }
   }
}
