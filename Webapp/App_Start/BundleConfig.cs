using System.Web.Optimization;

namespace Webapp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/vendor/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryunob").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/vendor/bootstrap/js/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle(@"~/Content/css").Include(
                      "~/Content/vendor/bootstrap/css/bootstrap.css",
                      "~/Content/vendor/metisMenu/metisMenu.min.css",
                      "~/Content/vendor/datatables-plugins/dataTables.bootstrap.css",
                      "~/Content/vendor/datatables-responsive/dataTables.responsive.css",
                      "~/Content/dist/css/sb-admin-2.css",
                     "~/Content/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/pagescripts").Include(
                "~/Content/vendor/metisMenu/metisMenu.js",
                "~/Content/dist/js/sb-admin-2.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Content/vendor/datatables/js/jquery.dataTables.js",
                "~/Content/vendor/datatables-plugins/dataTables.bootstrap.js",
                "~/Content/vendor/datatables-responsive/dataTables.responsive.js",
                "~/Scripts/respond.js"));
        }
    }
}
