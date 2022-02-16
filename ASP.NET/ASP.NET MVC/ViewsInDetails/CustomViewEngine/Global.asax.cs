using System.Web.Mvc;
using System.Web.Routing;
using CustomViewEngine.Infrastructure;

namespace CustomViewEngine
{
   public class MvcApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         ViewEngines.Engines.Add(new DebugDataViewEngine());   // NOTE: Регистрация специального механизма визуализации
      }
   }
}
