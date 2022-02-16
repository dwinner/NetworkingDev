using System;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.UI;

namespace FreelanceUnique.Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/jquery-2.1.3.min.js",
                    DebugPath = "~/Scripts/jquery-2.1.3.min.js",
                    CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.3.min.js",
                    CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jquery-2.1.3.min.js"
                });
        }
    }
}