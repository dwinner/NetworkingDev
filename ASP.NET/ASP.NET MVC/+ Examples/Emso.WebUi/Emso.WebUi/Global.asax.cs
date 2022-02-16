using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Emso.WebUi
{
   /// <summary>
   ///    Startup class for ASP.NET App
   /// </summary>
   public class MvcApplication : HttpApplication
   {
      private void Application_Start(object sender, EventArgs e)
      {
         AreaRegistration.RegisterAllAreas();
         GlobalConfiguration.Configure(WebApiConfig.Register);
         RouteConfig.RegisterRoutes(RouteTable.Routes);        
         BundleConfig.RegisterBundles(BundleTable.Bundles);
         FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         AutoMapperConfig.ConfigureViewModelMapping();
      }

      protected void Session_Start()
      {
      }

      protected void Session_End()
      {
      }
   }
}