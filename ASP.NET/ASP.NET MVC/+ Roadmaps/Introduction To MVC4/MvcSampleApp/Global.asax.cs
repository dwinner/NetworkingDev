using System.Web.Mvc;
using System.Web.Routing;

namespace MvcSampleApp
{
   public class MvcApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         RegisterGlobalFilters(GlobalFilters.Filters);
         RegisterRoutes(RouteTable.Routes);
      }

      public static void RegisterRoutes(RouteCollection routes)
      {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
         //routes.MapRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
         //routes.MapRoute("MultipleParameters", "{controller}/{action}/{x}{y}",
         //   new { controller = "Home", action = "Index" });
         routes.MapRoute("Default", "{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional });
      }

      public static void RegisterGlobalFilters(GlobalFilterCollection filters)
      {
         filters.Add(new HandleErrorAttribute());
      }
   }
}