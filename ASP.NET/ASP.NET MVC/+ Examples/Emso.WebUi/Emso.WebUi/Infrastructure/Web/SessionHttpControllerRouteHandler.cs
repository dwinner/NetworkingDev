using System.Web;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace Emso.WebUi.Infrastructure.Web
{
   /// <summary>
   ///    Controller handler for indirect support of session state in WebAPI controllers
   /// </summary>
   public sealed class SessionHttpControllerRouteHandler : HttpControllerRouteHandler
   {
      protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
      {
         return new SessionControllerHandler(requestContext.RouteData);
      }

      private sealed class SessionControllerHandler : HttpControllerHandler, IRequiresSessionState
      {
         public SessionControllerHandler(RouteData routeData)
            : base(routeData)
         {
         }
      }
   }
}