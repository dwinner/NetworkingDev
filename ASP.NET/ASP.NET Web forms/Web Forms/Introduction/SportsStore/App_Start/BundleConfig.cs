using System.Web.Optimization;

namespace SportsStore
{
   public class BundleConfig
   {
      private readonly static BundleConfig BundledConfig = new BundleConfig();

      private BundleConfig() { }

      public static BundleConfig Instance
      {
         get { return BundledConfig; }
      }

      public void RegisterBundles(BundleCollection bundles)
      {
         bundles.Add(new ScriptBundle("~/bundles/validation").Include(
            "~/Scripts/jquery-{version}.js",
            "~/Scripts/jquery.validate.js",
            "~/Scripts/jquery.validate.unobtrusive.js"));
      }
   }
}