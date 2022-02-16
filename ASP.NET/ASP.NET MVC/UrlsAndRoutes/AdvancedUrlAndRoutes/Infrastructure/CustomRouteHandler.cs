using System.Web;
using System.Web.Routing;

namespace AdvancedUrlAndRoutes.Infrastructure
{
   /// <summary>
   ///    Специальный обработчик маршрутов
   /// </summary>
   public class CustomRouteHandler : IRouteHandler
   {
      public IHttpHandler GetHttpHandler(RequestContext requestContext)
      {
         return new CustomHttpHandler();
      }

      private class CustomHttpHandler : IHttpHandler
      {
         public void ProcessRequest(HttpContext context)
         {
            context.Response.Write("Hello");
         }

         public bool IsReusable
         {
            get { return false; }
         }
      }
   }
}