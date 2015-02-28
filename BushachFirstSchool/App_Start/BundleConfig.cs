using System.Web;
using System.Web.Optimization;

namespace BushachFirstSchool
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
            // bootstrap
            bundles.Add(new StyleBundle("~/Content/Bootstrap/css").Include(
                "~/Content/bootstrap-3.3.1-dist/dist/css/bootstrap-theme.css",
                "~/Content/bootstrap-3.3.1-dist/dist/css/bootstrap.css"));  

            bundles.Add(new ScriptBundle("~/bundles/Bootstrap/js").Include(
               "~/Content/bootstrap-3.3.1-dist/dist/js/bootstrap.js",
               "~/Content/bootstrap-3.3.1-dist/dist/js/npm.js"));

            // bootstrap-material
            bundles.Add(new StyleBundle("~/Content/Bootstrap-material/css").Include(
               "~/Content/bootstrap-material/dist/css/ripples.css",
               "~/Content/bootstrap-material/dist/css/material.css"));

            bundles.Add(new ScriptBundle("~/Content/Bootstrap-material/js").Include(
               "~/Content/bootstrap-material/dist/js/ripples.js",
               "~/Content/bootstrap-material/dist/js/material.js"));
         

            //ellements
            bundles.Add(new StyleBundle("~/Content/elltments").Include(
              "~/Content/buttons/buttons.css",
              "~/Content/message/message.css"  
             ));

            bundles.Add(new StyleBundle("~/Content/HomePage").Include(
              "~/Content/home/logotype.css",
              "~/Content/home/history.css",
              "~/Content/home/team.css",
              "~/Content/home/news.css",
              "~/Content/home/position.css"
             ));
            bundles.Add(new StyleBundle("~/Content/ContentPage").Include(
             "~/Content/loader/loader.css",
             "~/Content/paginations/paginations.css",
              "~/Content/Entity/SingleTeacher.css",
             "~/Content/Entity/SingleNews.css"
             ));
            
            bundles.Add(new ScriptBundle("~/bundles/Home").Include(
                        "~/Scripts/home/navigations.js",
                        "~/Scripts/home/homeglobal.js"));
            bundles.Add(new ScriptBundle("~/bundles/global").Include(
                        "~/Scripts/global.js"));
            bundles.Add(new ScriptBundle("~/bundles/background").Include(
                       "~/Scripts/background/zero.js",
                       "~/Scripts/background/background.js"));
            bundles.Add(new ScriptBundle("~/bundles/conceptThesisGenerator").Include(
                     "~/Scripts/conceptThesisGenerator/ptparser.js",
                     "~/Scripts/conceptThesisGenerator/pttableBuilder.js",
                     "~/Scripts/conceptThesisGenerator/ptAjaxSender.js",
                     "~/Scripts/conceptThesisGenerator/ptindex.js"));
            bundles.Add(new ScriptBundle("~/bundles/testResult").Include(
                  "~/Scripts/Test/TestResultSender.js",
                  "~/Scripts/Test/testTimer.js",
                   "~/Scripts/Test/testInitialiser.js"));

            //logmenu
            bundles.Add(new ScriptBundle("~/bundles/logmenu").Include(
              "~/Content/logmenu/logmenuscript.js"));
            bundles.Add(new StyleBundle("~/Content/logmenu").Include(
            "~/Content/logmenu/logmenustyle.css"));
        }
    }
}