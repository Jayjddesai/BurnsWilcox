using System.Web;
using System.Web.Optimization;

namespace BurnsWilcoxCLP.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Stylesheets

            bundles.Add(new StyleBundle("~/Content/Styles").Include(
                      "~/Content/css/FontGoogleApi.css",
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/icomoon.css",
                      "~/Content/css/core.min.css",
                      "~/Content/css/colors.min.css",
                      "~/Content/css/components.min.css",
                      "~/Content/css/custom.css",
                      "~/Content/css/animate.min.css",
                      "~/Content/css/site.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/ui").Include(
                "~/Content/css/Kendo/kendo.common-material.min.css",
                "~/Content/css/Kendo/kendo.material.min.css"));



            bundles.Add(new StyleBundle("~/Content/TelerikReport")
               .Include("~/ReportViewer/styles/telerikReportViewer.css"));

            #endregion

            #region Scripts

            bundles.Add(new ScriptBundle("~/Content/scripts").Include(
                //"~/Content/js/core/libraries/jquery.min.js",
            "~/Content/js/core/libraries/jquery-1.10.2.min.js",
            "~/Content/js/core/libraries/bootstrap.min.js",
              "~/Content/js/core/libraries/jquery.validate.min.js",
            "~/Content/js/core/libraries/jquery.validate.unobtrusive.min.js",
            "~/Content/js/plugins/loaders/blockui.min.js",
            "~/Content/js/plugins/forms/wizards/steps.min.js",
            "~/Content/js/plugins/forms/selects/select2.min.js",
            "~/Content/js/plugins/forms/styling/uniform.min.js",
            "~/Content/js/core/libraries/jasny_bootstrap.min.js",
            "~/Content/js/plugins/ui/moment/moment.min.js",
            "~/Content/js/plugins/extensions/cookie.js",
            "~/Content/js/core/app.js",
            "~/Content/js/pages/wizard_steps.js",
            "~/Content/js/pages/animations_css3.js",
            "~/Content/js/plugins/pickers/pickadate/picker.js",
            "~/Content/js/plugins/pickers/daterangepicker.js",
            "~/Content/js/plugins/pickers/anytime.min.js",
            "~/Content/js/plugins/pickers/pickadate/picker.date.js",
            "~/Content/js/plugins/pickers/pickadate/picker.time.js",
            "~/Content/js/plugins/pickers/pickadate/legacy.js",
            "~/Content/js/plugins/tables/datatables/datatables.min.js",
            "~/Content/js/plugins/tables/datatables/extensions/buttons.min.js",
            "~/Content/js/plugins/tables/datatables/extensions/jszip/jszip.min.js",
            "~/Content/js/plugins/tables/datatables/extensions/pdfmake/pdfmake.min.js",
            "~/Content/js/plugins/tables/datatables/extensions/pdfmake/vfs_fonts.min.js",
            "~/Content/js/pages/picker_date.js",
            "~/Content/js/pages/datatables_basic.js",
            "~/Content/js/pages/datatables_extension_buttons_html5.js",
            "~/Content/js/plugins/notifications/pnotify.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/kendoJS").Include(
                "~/Scripts/bootbox.js",
                "~/Content/js/kendo/kendo.all.min.js",
                "~/Content/js/kendo/kendo.aspnetmvc.min.js",
                "~/Content/js/app.js",
                "~/Scripts/Common.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //Bundling JS and styles for telerik report
            bundles.Add(new ScriptBundle("~/bundles/TelerikReport").Include(
                      "~/ReportViewer/js/telerikReportViewer-10.1.16.504.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/JsZip").Include(
                      "~/Content/js/core/libraries/jquery_ui/widgets.min.js",
                       "~/Content/js/jszip.js",
                      "~/Content/js/pages/jqueryui_forms.js"));

            //BundleTable.EnableOptimizations = true;
            #endregion
        }
    }
}
