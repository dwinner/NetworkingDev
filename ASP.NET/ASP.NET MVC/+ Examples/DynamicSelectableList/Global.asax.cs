using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using DynamicSelectableList.Infrastructure;

namespace DynamicSelectableList
{
   public class MvcApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         Database.SetInitializer(new StateContextInitializer());
      }
   }
}
