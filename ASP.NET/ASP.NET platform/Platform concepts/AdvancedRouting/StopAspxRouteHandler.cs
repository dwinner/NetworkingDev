/**
 * Обработчик маршрута для отключения запросов к файлам aspx
 */

using System.Web;
using System.Web.Routing;

namespace AdvancedRouting
{
   public class StopAspxRouteHandler : IRouteHandler, IHttpHandler
   {
      public void ProcessRequest(HttpContext context)
      {
         context.Response.StatusCode = 404;
         context.ApplicationInstance.CompleteRequest();
      }

      public bool IsReusable
      {
         get { return false; }
      }

      public IHttpHandler GetHttpHandler(RequestContext requestContext)
      {
         return this;
      }
   }

   public static class StopAspxRoutingHelper
   {
      public static void StopAspxRequests(this RouteCollection routes)
      {
         routes.RouteExistingFiles = true;
         routes.Add("noaspx", new Route("{*path}", null,
            new RouteValueDictionary { { "path", @"?i:^.*\.aspx.*$" } },
            new StopAspxRouteHandler()));
      }
   }
}