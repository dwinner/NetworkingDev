using System.Web.Optimization;

namespace FreelanceUnique.Web
{
    public static class BundleConfig
    {        
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/bootstrap").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/bootstrap-theme.min.css"));
            bundles.Add(new StyleBundle("~/bundles/mainstyles").Include(
                "~/Content/mainstyles.css"));
            bundles.Add(new ScriptBundle("~/bundles/validation").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                "~/Scripts/bootstrap.min.js"));
        }
    }    
}