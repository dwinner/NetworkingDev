using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace SecureWebAPI
{
   public static class WebApiConfig
   {
      public static void Register(HttpConfiguration config)
      {
         // Конфигурация и службы Web API
         // Настройка Web API для использования только проверки подлинности посредством маркера-носителя.
         config.SuppressDefaultHostAuthentication();
         config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

         // Маршруты Web API
         config.MapHttpAttributeRoutes();

         config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
      }
   }
}