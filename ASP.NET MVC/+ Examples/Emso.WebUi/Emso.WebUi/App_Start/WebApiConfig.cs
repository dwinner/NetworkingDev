using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.WebHost;
using Emso.WebUi.Infrastructure.Web;

namespace Emso.WebUi
{
   public static class WebApiConfig
   {
      public static void Register(HttpConfiguration config)
      {
         // Web API configuration and services

         FieldInfo httpControllerRouteHandler = typeof (HttpControllerRouteHandler).GetField("_instance",
            BindingFlags.Static | BindingFlags.NonPublic);
         if (httpControllerRouteHandler != null)
            httpControllerRouteHandler.SetValue(null,
               new Lazy<HttpControllerRouteHandler>(() => new SessionHttpControllerRouteHandler(), true));

         config.MapHttpAttributeRoutes();
         config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});
      }
   }
}