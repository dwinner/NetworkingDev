using System.Web.Optimization;

namespace Bundling
{
   /// <summary>
   ///    Конфигурация пакетов
   /// </summary>
   public static class BundleConfig
   {
      public static void RegisterBundles(BundleCollection bundles)
      {
         bundles.Add(new StyleBundle(BundleConstants.AllCssPath)
            .Include("~/Content/*.css"));

         bundles.Add(new ScriptBundle(BundleConstants.AllScriptPath)
            .Include("~/Scripts/jquery-{version}.js",
               "~/Scripts/jquery.validate.js",
               "~/Scripts/jquery.validate.unobtrusive.js",
               "~/Scripts/jquery.unobtrusive-ajax.js"));
      }

      public static class BundleConstants
      {
         public const string AllCssPath = "~/Content/css";
         public const string AllScriptPath = "~/bundles/clientfeaturesscripts";
      }
   }
}