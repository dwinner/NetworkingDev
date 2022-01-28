using System.Web.Mvc;
using System.Web.Routing;
using I18n.Web.Infrastructure;

namespace I18n.Web
{
   public static class RouteConfig
   {
      public static void RegisterRoutes(RouteCollection routes)
      {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         routes.MapRoute(string.Empty, "{culture}/{controller}/{action}/{id}",
            new
            {
               culture = CultureHelper.DefaultCulture,
               controller = "Home",
               action = "Index",
               id = UrlParameter.Optional
            });
      }
   }
}