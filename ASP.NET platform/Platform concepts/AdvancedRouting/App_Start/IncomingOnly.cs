// Ограничение для маршрута

using System.Web;
using System.Web.Routing;

namespace AdvancedRouting
{
   public class IncomingOnly : IRouteConstraint
   {
      public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
         RouteDirection routeDirection)
      {
         return routeDirection == RouteDirection.IncomingRequest;
      }
   }
}