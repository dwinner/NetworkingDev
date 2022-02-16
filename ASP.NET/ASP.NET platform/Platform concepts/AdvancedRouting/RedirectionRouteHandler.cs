using System.Web;
using System.Web.Routing;

namespace AdvancedRouting
{
   /// <summary>
   ///    Специальный обработчик маршрута для перенаправления на внешний Url
   /// </summary>
   public class RedirectionRouteHandler : IRouteHandler
   {
      public IHttpHandler GetHttpHandler(RequestContext requestContext)
      {
         return new RedirectionHandler
         {
            TargetUrl = requestContext.RouteData.DataTokens["target"].ToString()
         };
      }

      private class RedirectionHandler : IHttpHandler
      {
         public string TargetUrl { private get; set; }

         public void ProcessRequest(HttpContext context)
         {
            context.Response.Redirect(TargetUrl);
         }

         public bool IsReusable
         {
            get { return false; }
         }
      }
   }
}