using System.Web;
using System.Web.Optimization;

namespace WebChallenged
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/assets/plugins/jquery/jquery.min.js",
                        "~/assets/plugins/jquery-ui/jquery-ui.min.js",
                        "~/assets/plugins/bootstrap/js/bootstrap.bundle.min.js",
                        "~/assets/plugins/chart.js/Chart.min.js",
                        "~/assets/plugins/sparklines/sparkline.js",
                        "~/assets/plugins/jqvmap/jquery.vmap.min.js",
                        "~/assets/plugins/jqvmap/maps/jquery.vmap.usa.js",
                        "~/assets/plugins/jquery-knob/jquery.knob.min.js",
                        "~/assets/plugins/moment/moment.min.js",
                        "~/assets/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
                        "~/assets/plugins/summernote/summernote-bs4.min.js",
                        "~/assets/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
                        "~/assets/dist/js/adminlte.js",
                        "~/assets/dist/js/pages/dashboard.js",
                        "~/assets/plugins/sweetalert2/sweetalert2.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/plugins/fontawesome-free/css/all.min.css",
                      "~/assets/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css",
                       "~/assets/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                        "~/assets/plugins/jqvmap/jqvmap.min.css",
                         "~/assets/dist/css/adminlte.min.css",
                          "~/assets/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                          "~/assets/plugins/daterangepicker/daterangepicker.css",
                          "~/assets/plugins/summernote/summernote-bs4.min.css",
                          "~/assets/plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css"));
        }
    }
}
