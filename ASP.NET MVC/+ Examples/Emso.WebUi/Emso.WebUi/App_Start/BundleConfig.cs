using System.Web.Optimization;

namespace Emso.WebUi
{
   /// <summary>
   ///    Bundle client scripts and files configuration
   /// </summary>
   public static class BundleConfig
   {
      public static void RegisterBundles(BundleCollection bundles)
      {
         #region Style bundles

         bundles.Add(new StyleBundle(StyleConstants.BootstrapStyles)
            .Include("~/Content/bootstrap.css", new CssRewriteUrlTransform())
            .Include("~/Content/bootstrap-theme.css", new CssRewriteUrlTransform())
            .Include("~/Content/bootstrap.cosmo.css", new CssRewriteUrlTransform()));

         bundles.Add(new StyleBundle(StyleConstants.JQueryUiCommonThemeStyles)
            .Include("~/Content/themes/base/all.css", new CssRewriteUrlTransform())
            .Include("~/Content/styles/jqPagination.css", new CssRewriteUrlTransform()));

         bundles.Add(new StyleBundle(StyleConstants.JQueryUiDarknessThemeStyles)
            .Include("~/Content/themes/ui-darkness/jquery-ui.ui-darkness.css", new CssRewriteUrlTransform()));

         bundles.Add(new StyleBundle(StyleConstants.EmsoStyles)
            .Include("~/Content/styles/mainStyles.css", new CssRewriteUrlTransform())
            .Include("~/Content/styles/sideViewMenu.css", new CssRewriteUrlTransform())
            .Include("~/Content/styles/radioImages.css", new CssRewriteUrlTransform()));

         bundles.Add(new StyleBundle(StyleConstants.SlickSliderStyles)
            .Include("~/Content/Slick/slick.css", new CssRewriteUrlTransform())
            .Include("~/Content/Slick/slick-theme.css", new CssRewriteUrlTransform()));

         bundles.Add(new StyleBundle(StyleConstants.BarRatingStyles)
            .Include("~/Content/styles/rating-themes/*.css", new CssRewriteUrlTransform()));

         #endregion

         #region Script bundles

         bundles.Add(new ScriptBundle(ScriptConstants.CommonJsLibraryPath)
            .Include(
               "~/Scripts/jquery-{version}.js",
               "~/Scripts/jquery-ui-{version}.js",
               "~/Scripts/bootstrap.js",
               "~/Scripts/handlebars.js",
               "~/Scripts/custom/handlebars-jquery.js",
               "~/Scripts/modernizr-{version}.js",
               "~/Scripts/jquery.maskedinput.js",
               "~/Scripts/custom/sideViewMenu.js",
               "~/Scripts/custom/controlSetup.js",
               "~/Scripts/custom/scrolltopcontrol.js"));

         bundles.Add(new ScriptBundle(ScriptConstants.SlickSliderJsPath)
            .Include(
               "~/Scripts/Slick/slick.js"));

         bundles.Add(new ScriptBundle(ScriptConstants.JqUnobtrusiveValidation)
            .Include(
               "~/Scripts/jquery.validate.js",
               "~/Scripts/jquery.validate.unobtrusive.js"));

         bundles.Add(new ScriptBundle(ScriptConstants.BarRatingJs)
            .Include(
               "~/Scripts/custom/jquery.barrating.js"));

         bundles.Add(new ScriptBundle(ScriptConstants.ContactUsJs)
            .Include(
               "~/Scripts/custom/contactUs.js"));

         bundles.Add(new ScriptBundle(ScriptConstants.AdminNews)
            .Include(
               "~/Scripts/custom/adminNews.js"));

         bundles.Add(new ScriptBundle(ScriptConstants.CrudJobVacancy)
            .Include(
               "~/Scripts/custom/crudJobVacancy.js"));

         bundles.Add(new ScriptBundle(ScriptConstants.CrudDialog)
            .Include(
               "~/Scripts/custom/crudDialog.js"));

         bundles.Add(new ScriptBundle(ScriptConstants.JqMagnifier)
            .Include(
               "~/Scripts/custom/jquery.magnifier.js"));

         bundles.Add(new ScriptBundle(ScriptConstants.JqPagination)
            .Include(
               "~/Scripts/custom/jquery.pagination.js",
               "~/Scripts/custom/rssFeed.js",
               "~/Scripts/custom/animatedcollapse.js"));

         #endregion
      }

      public static class StyleConstants
      {
         public const string BootstrapStyles = "~/Content/bundles";
         public const string JQueryUiCommonThemeStyles = "~/Content/themes/base/bundles";
         public const string JQueryUiDarknessThemeStyles = "~/Content/themes/ui-darkness/bundles";
         public const string EmsoStyles = "~/Content/styles/bundles";
         public const string SlickSliderStyles = "~/Content/Slick/bundles";
         public const string BarRatingStyles = "~/Content/styles/rating-themes/bundles";
      }

      public static class ScriptConstants
      {
         public const string CommonJsLibraryPath = "~/bundles/scripts/common";
         public const string SlickSliderJsPath = "~/bundles/scripts/slickslider";
         public const string JqUnobtrusiveValidation = "~/bundles/scripts/unobtrusive";
         public const string BarRatingJs = "~/bundles/scripts/barrating";
         public const string ContactUsJs = "~/bundles/scripts/contactus";
         public const string AdminNews = "~/bundles/scripts/adminNews";
         public const string CrudJobVacancy = "~/bundles/scripts/crudjobvacancy";
         public const string CrudDialog = "~/bundles/scripts/cruddialog";
         public const string JqMagnifier = "~/bundles/scripts/jquerymagnifier";
         public const string JqPagination = "~/bundles/scripts/jquerypagination";
      }
   }
}