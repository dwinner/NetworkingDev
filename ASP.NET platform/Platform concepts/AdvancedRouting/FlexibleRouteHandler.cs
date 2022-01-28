using System;
using System.Web;
using System.Web.Routing;

namespace AdvancedRouting
{
   public class FlexibleRouteHandler : IRouteHandler
   {
      public string HandlerType { get; set; }

      public IHttpHandler GetHttpHandler(RequestContext requestContext)
      {
         IHttpHandler handler = null;

         if (HandlerType != null)
         {
            // ReSharper disable once AssignNullToNotNullAttribute
            object target = Activator.CreateInstance(Type.GetType(HandlerType));
            if (target is IHttpHandlerFactory && requestContext.HttpContext is HttpContextWrapper)
            {
               HttpRequestBase request = requestContext.HttpContext.Request;
               handler = (target as IHttpHandlerFactory).GetHandler(HttpContext.Current, request.RequestType,
                  request.RawUrl, request.PhysicalApplicationPath);
            }
            else if (target is IHttpHandler)
            {
               handler = target as IHttpHandler;
            }            
         }

         return handler;
      }
   }
}