// Специальное ограничение маршрута

using System.Web;
using System.Web.Routing;

namespace AdvancedRouting
{
   public class FormDataConstraint : IRouteConstraint
   {
      private readonly string _targetValue;

      public FormDataConstraint(string targetValue)
      {
         _targetValue = targetValue;
      }

      public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
         RouteDirection routeDirection)
      {
         string actualValue = httpContext.Request.Form[parameterName];
         return actualValue != null && actualValue == _targetValue;
      }
   }
}