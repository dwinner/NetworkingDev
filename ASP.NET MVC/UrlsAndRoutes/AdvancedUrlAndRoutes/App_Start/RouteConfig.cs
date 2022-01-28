using System.Web.Mvc;
using System.Web.Routing;
using AdvancedUrlAndRoutes.Infrastructure;

namespace AdvancedUrlAndRoutes
{
   public static class RouteConfig
   {
      public static void RegisterRoutes(RouteCollection routes)
      {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
         routes.RouteExistingFiles = true;   // Оценка маршрутов перед проверкой физических путей
         routes.MapMvcAttributeRoutes();

         // Обход системы маршрутизации
         routes.IgnoreRoute("Content/{filename}.html");

         // Определение запросов к дисковым файлам
         routes.MapRoute("DiskFile", "Content/StaticContent.html", new { controller = "Customer", action = "List" });

         // Специальный обработчик маршрутов
         routes.Add(new Route("SayHello", new CustomRouteHandler()));

         // Регистрация специального маршрута для унаследованных Url
         routes.Add(new LegacyRoute("~/articles/Windows_3.1_Overview.html", "~/old/.NET_1.0_Class_Library"));

         routes.MapRoute("MyRoute", "{controller}/{action}", null,
            new[] { "AdvancedUrlAndRoutes.Controllers" });
         routes.MapRoute("MyOtherRoute", "App/{action}", new { controller = "Home" },
            new[] { "AdvancedUrlAndRoutes.Controllers" });

         routes.MapRoute("Default", "{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            new[] { "AdvancedUrlAndRoutes.Controllers" });
      }
   }
}