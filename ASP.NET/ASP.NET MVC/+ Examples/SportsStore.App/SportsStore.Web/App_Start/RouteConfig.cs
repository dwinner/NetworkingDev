using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.Web
{
   public static class RouteConfig
   {
      public static void RegisterRoutes(RouteCollection routes)
      {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         routes.MapRoute(null, "adm", new { controller = "Admin", action = "Index" });
         routes.MapRoute(null, "", new { controller = "Product", action = "List", category = (string)null, page = 1 });
         routes.MapRoute(null, "Page{page}", new { controller = "Product", action = "List", category = (string)null },
            new { page = @"\d+" });
         routes.MapRoute(null, "{category}", new { controller = "Product", action = "List", page = 1 });
         routes.MapRoute(null, "{category}/Page{page}", new { controller = "Product", action = "List" },
            new { page = @"\d+" });
         routes.MapRoute(null, "{controller}/{action}");         
      }
   }
}