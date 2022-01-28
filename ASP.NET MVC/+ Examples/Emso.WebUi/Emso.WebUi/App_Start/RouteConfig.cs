using System.Web.Mvc;
using System.Web.Routing;
using Emso.WebUi.Infrastructure;

namespace Emso.WebUi
{
   public static class RouteConfig
   {
      public static void RegisterRoutes(RouteCollection routes)
      {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         routes.MapRoute(Constants.NewsPaginationRoute,
            "{culture}/news{page}",
            new
            {
               culture = CultureHelper.DefaultCulture,
               controller = "AdminNews",
               action = "Index"
            },
            new { page = @"\d+" });

         routes.MapRoute(Constants.DefaultRoute,
            "{culture}/{controller}/{action}/{id}",
            new
            {
               culture = CultureHelper.DefaultCulture,
               controller = "Home",
               action = "Index",
               id = UrlParameter.Optional
            },
            new[] { "Controllers" });
      }

      private static class Constants
      {
         public const string NewsPaginationRoute = "NewsPaginationRoute";
         public const string DefaultRoute = "DefaultRoute";
      }
   }
}