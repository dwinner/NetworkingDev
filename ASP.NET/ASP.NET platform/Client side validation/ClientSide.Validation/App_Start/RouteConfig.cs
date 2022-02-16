using System.Web.Http;
using System.Web.Routing;

namespace ClientSide.Validation
{
   public static class RouteConfig
   {
      public static void RegisterRoutes(RouteCollection routes)
      {         
         routes.MapHttpRoute("WebApiRoute", "api/{controller}/{id}", new { id = RouteParameter.Optional });
      }
   }
}