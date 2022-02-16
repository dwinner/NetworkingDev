using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace SportsStore
{
   public class Global : HttpApplication
   {
      protected void Application_Start(object sender, EventArgs e)
      {
         RouteConfig.Instance.RegisterRoutes(RouteTable.Routes);
         BundleConfig.Instance.RegisterBundles(BundleTable.Bundles);
      }

      protected void Session_Start(object sender, EventArgs e)
      {

      }

      protected void Application_BeginRequest(object sender, EventArgs e)
      {

      }

      protected void Application_AuthenticateRequest(object sender, EventArgs e)
      {

      }

      protected void Application_Error(object sender, EventArgs e)
      {

      }

      protected void Session_End(object sender, EventArgs e)
      {

      }

      protected void Application_End(object sender, EventArgs e)
      {

      }
   }
}