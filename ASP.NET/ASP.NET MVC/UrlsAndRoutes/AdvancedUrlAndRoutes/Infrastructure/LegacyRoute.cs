using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdvancedUrlAndRoutes.Infrastructure
{
   /// <summary>
   ///    Маршрутизация унаследованных Url
   /// </summary>
   public class LegacyRoute : RouteBase
   {
      private const string LegacyUrlValue = "legacyUrl";
      private readonly string[] _legacyUrls;

      public LegacyRoute(params string[] legacyUrls)
      {
         _legacyUrls = legacyUrls;
      }

      public override RouteData GetRouteData(HttpContextBase httpContext)
      {
         RouteData result = null;
         var requestedUrl = httpContext.Request.AppRelativeCurrentExecutionFilePath;
         if (_legacyUrls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
         {
            result = new RouteData(this, new MvcRouteHandler());
            result.Values.Add("controller", "Legacy");
            result.Values.Add("action", "GetLegacyUrl");
            result.Values.Add(LegacyUrlValue, requestedUrl);
         }

         return result;
      }

      public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
      {
         VirtualPathData result = null;
         if (values.ContainsKey(LegacyUrlValue) &&
             _legacyUrls.Contains((string)values[LegacyUrlValue], StringComparer.OrdinalIgnoreCase))
         {
            result = new VirtualPathData(this,
               new UrlHelper(requestContext).Content((string)values[LegacyUrlValue]).Substring(1));
         }

         return result;
      }
   }
}