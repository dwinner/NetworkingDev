using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
   public static class RouteConfig
   {
      public static void RegisterRoutes(RouteCollection routes)
      {
         //DefaultRouteExamples(routes);
         //RouteExamples(routes);
         //VariableSegments(routes);
         //VarRoutesAndNamespaces(routes);
         //RouteConstraints(routes);         
         //CustomRouteConstraint(routes);

         routes.MapMvcAttributeRoutes();
      }

      private static void CustomRouteConstraint(RouteCollection routes) // Определение специального ограничения
      {
         routes.MapRoute("ChromeRoute", "{*catchall}", new {controller = "Home", action = "Index"},
            new {customConstraint = new UserAgentConstraint("Chrome")}, new[] {"UrlsAndRoutes.AdditionalControllers"});
      }

      private static void RouteConstraints(RouteCollection routes)
      {
         // Ограничение маршрутов
         routes.MapRoute(string.Empty, "{controller}/{action}/{id}/{*catchall}",
            new
            {
               controller = "Home",
               action = "Index",
               id = UrlParameter.Optional
            },
            new
            {
               controller = "^H.*",
               action = "^Index$|^About$",
               httpMethod = new HttpMethodConstraint("GET"),
               id =
                  new CompoundRouteConstraint(new IRouteConstraint[] { new AlphaRouteConstraint(), new MinLengthRouteConstraint(6) })
            },
            new[] { "UrlsAndRoutes.AdditionalControllers" });
      }

      private static void VarRoutesAndNamespaces(RouteCollection routes)
      {
         // Определение маршрутов переменной длины, управление распознаванием пространств имен
         var myRoute = routes.MapRoute("AddControllerRoute", "Home/{action}/{id}/{*catchall}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            new[] { "UrlsAndRoutes.AdditionalControllers" });
         myRoute.DataTokens["UseNamespaceFallback"] = false; // Не искать в других пространствах имен

         routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            new[] { "UrlsAndRoutes.Controllers" });
      }

      private static void VariableSegments(RouteCollection routes)
      {
         // Определение специальных (необязательных) переменных сегментов
         routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional /*"DefaultId"*/});
      }

      private static void DefaultRouteExamples(RouteCollection routes)
      {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         routes.MapRoute("Default", "{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional });

         var myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
         routes.Add("MyRoute", myRoute);
      }

      private static void RouteExamples(RouteCollection routes)
      {
         // Транслирование запросов на Home-контроллер из контроллера Shop
         routes.MapRoute("ShopSchema2", "Shop/OldAction", new { controller = "Home", action = "Index" });
         routes.MapRoute("ShopSchema", "Shop/{action}", new { controller = "Home" });

         // Статический префикс в маршруте
         routes.MapRoute(string.Empty, "X{controller}/{action}");

         // 2х-сегментные Url со значениями по умолчанию
         routes.MapRoute(string.Empty, "{controller}/{action}", new { controller = "Home", action = "Index" });

         // 3х-сегментный Url со статическим первым сегментом
         routes.MapRoute(string.Empty, "Public/{controller}/{action}", new { controller = "Home", action = "Index" });
      }
   }
}