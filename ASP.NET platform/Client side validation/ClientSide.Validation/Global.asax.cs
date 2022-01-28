using System;
using System.Web;
using System.Web.Routing;
using System.Web.UI;

namespace ClientSide.Validation
{
   public class Global : HttpApplication
   {
      protected void Application_Start(object sender, EventArgs e)
      {
         ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
            new ScriptResourceDefinition { Path = "~/Scripts/jquery-2.1.4.js" });
         RouteConfig.RegisterRoutes(RouteTable.Routes);
      }
   }
}