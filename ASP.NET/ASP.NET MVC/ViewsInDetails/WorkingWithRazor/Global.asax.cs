using System.Web.Mvc;
using System.Web.Routing;
using WorkingWithRazor.Infrastructure;

namespace WorkingWithRazor
{
   public class MvcApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         RouteConfig.RegisterRoutes(RouteTable.Routes);

         // Регистрация специального механизма визуализации
         ViewEngines.Engines.Clear();
         ViewEngines.Engines.Add(new CustomLocationViewEngine());
      }
   }
}
