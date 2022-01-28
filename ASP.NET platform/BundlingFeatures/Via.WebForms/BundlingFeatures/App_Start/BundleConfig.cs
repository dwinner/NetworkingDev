using System.Web.Optimization;
using System.Web.UI;
using BundlingFeatures.Utils;

namespace BundlingFeatures
{
   public static class BundleConfig
   {
      public static void RegisterBundles(BundleCollection bundles)
      {
         var jqCdn = new CdnScriptBundle("~/bundle/jquery").CdnInclude("~/Scripts/jquery-{version}.js",
            "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-{version}.min.js");

         //var jquery = new ScriptBundle("~/bundle/jquery")
         //{
         //   CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.4.min.js"
         //};
         //jquery.Include("~/Scripts/jquery-{version}.js");

         var jqueryUi = new ScriptBundle("~/bundle/jqueryui")
         {
            CdnPath = "http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.1/jquery-ui.min.js"
         };
         jqueryUi.Include("~/Scripts/jquery-{version}.js", "~/Scripts/jquery-ui-{version}.js");

         var basicStyles = new StyleBundle("~/bundle/basicCSS")
            .Include("~/Styles/MainStyles.css", "~/Styles/ErrorStyles.css");
         var jqueryUiStyles = new StyleBundle("~/Content/themes/base/jqueryUiCss")
            //.Include("~/Content/themes/base/all.css");
            .IncludeDirectory("~/Content/themes/base", "*.css");

         //#if DEBUG
         //         bundles.UseCdn = true;
         //#endif

         ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
            new ScriptResourceDefinition { Path = "~/Scripts/jquery-2.1.4.js" });

         bundles.Add(jqCdn);
         bundles.Add(jqueryUi);
         bundles.Add(basicStyles);
         bundles.Add(jqueryUiStyles);
      }
   }
}