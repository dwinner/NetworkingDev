using System.Web.Routing;

namespace SportsStore
{
   /// <summary>
   /// Класс конфигурации для маршрутизации URL
   /// </summary>
   public class RouteConfig
   {
      private readonly static RouteConfig RouteConfigInstance = new RouteConfig();

      private RouteConfig() { }

      public static RouteConfig Instance { get { return RouteConfigInstance; } }

      public void RegisterRoutes(RouteCollection routes)
      {
         routes.MapPageRoute(null, "list/{category}/{page}", "~/Pages/Listings.aspx");
         routes.MapPageRoute(null, "list/{page}", "~/Pages/Listings.aspx");
         routes.MapPageRoute(null, "", "~/Pages/Listings.aspx");
         routes.MapPageRoute(null, "list", "~/Pages/Listings.aspx");
         routes.MapPageRoute("cart", "cart", "~/Pages/CartView.aspx");
         routes.MapPageRoute("checkout", "checkout", "~/Pages/Checkout.aspx");
         routes.MapPageRoute("admin_orders", "admin/orders", "~/Pages/Admin/Orders.aspx");
         routes.MapPageRoute("admin_products", "admin/products", "~/Pages/Admin/Products.aspx");
      }
   }
}