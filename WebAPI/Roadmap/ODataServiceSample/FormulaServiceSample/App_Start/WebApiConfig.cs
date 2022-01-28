using System.Web.Http;
using System.Web.Http.OData.Builder;
using FormulaServiceSample.Models;

namespace FormulaServiceSample
{
   public static class WebApiConfig
   {
      public static void Register(HttpConfiguration config)
      {
         // Web API configuration and services

         var builder = new ODataConventionModelBuilder();
         builder.EntitySet<Racer>("Racer");
         builder.EntitySet<RaceResult>("RaceResult");
         builder.EntitySet<Race>("Race");
         builder.EntitySet<Circuit>("Circuit");
         builder.EntitySet<YearResult>("YearResult");
         config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());

         // Web API routes
         config.MapHttpAttributeRoutes();

         config.Routes.MapHttpRoute(
            "DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
      }
   }
}