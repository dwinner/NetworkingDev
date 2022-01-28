/**
 * Специальная реализация RouteBase
 */

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;

namespace AdvancedRouting
{
   public class BrowserRoute : RouteBase
   {
      private readonly IDictionary<Browser, string> _targetPages;
      private readonly string _targetPath;

      public BrowserRoute(string targetPath, IDictionary<Browser, string> targetPages)
      {
         _targetPath = targetPath.ToLower();
         _targetPages = targetPages;
      }

      public override RouteData GetRouteData(HttpContextBase httpContext)
      {
         Browser browser;
         if (httpContext.Request.CurrentExecutionFilePath.ToLower() == string.Format("/{0}", _targetPath) &&
             _targetPages.ContainsKey(browser = IdentifyBrowser(httpContext.Request)))
         {
            return new RouteData
            {
               Route = this,
               RouteHandler = new PageRouteHandler(_targetPages[browser])
            };
         }

         return null;
      }

      private static Browser IdentifyBrowser(HttpRequestBase request)
      {
         string uaString = request.Headers["user-agent"] ?? string.Empty;
         return uaString.IndexOf("MSIE 10", StringComparison.Ordinal) != -1
            ? Browser.IeTen
            : uaString.IndexOf("Chrome", StringComparison.Ordinal) != -1 ? Browser.Chrome : Browser.Other;
      }

      public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
      {
         return new VirtualPathData(this, _targetPath);
      }
   }

   public enum Browser
   {
      IeTen,
      Chrome,
      Other
   }
}