using System;
using System.Web;
using System.Web.Optimization;

namespace Data
{
   public class Global : HttpApplication
   {
      protected void Application_Start(object sender, EventArgs e)
      {
         BundleConfig.RegisterBundles(BundleTable.Bundles);
      }
   }
}