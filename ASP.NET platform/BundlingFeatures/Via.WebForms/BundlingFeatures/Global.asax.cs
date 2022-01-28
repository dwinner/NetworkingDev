using System;
using System.Web;
using static System.Web.Optimization.BundleTable;
using static BundlingFeatures.BundleConfig;

namespace BundlingFeatures
{
   public class Global : HttpApplication
   {
      protected void Application_Start(object sender, EventArgs e)
      {
         RegisterBundles(Bundles);
//#if (!DEBUG)
//{
//         EnableOptimizations = true;
//}
//#endif
      }
   }
}