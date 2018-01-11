using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace JaiSmi
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region JS Bundles

            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jQuery").Include("~/Scripts/ScriptsLib/jQuery/jquery-2.2.1.min.js"));

            // Namespace
            bundles.Add(new ScriptBundle("~/bundles/namespace").Include("~/Scripts/ScriptsLib/namespace/Namespace.js"));
            
            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/ScriptsLib/bootstrap/bootstrap.min.js"));

            // Isotope
            bundles.Add(new ScriptBundle("~/bundles/isotope").Include("~/Scripts/ScriptsLib/isotope/isotope_2.2.2.pkgd.min.js", "~/Scripts/ScriptsLib/isotope/imagesloaded.pkgd.min.js"));

            // CKEditor
            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include("~/Scripts/ScriptsLib/ckeditor/ckeditor.js", "~/Scripts/ScriptsLib/ckeditor/adapters/jquery.js"));

            // Shared
            bundles.Add(new ScriptBundle("~/bundles/shared").Include("~/Scripts/Shared/Shared.js"));

            // Home
            bundles.Add(new ScriptBundle("~/bundles/home").Include("~/Scripts/Home/Home.js"));

            // Blog
            bundles.Add(new ScriptBundle("~/bundles/blog").Include("~/Areas/Blog/Scripts/Blog.js"));

            // Travel
            bundles.Add(new ScriptBundle("~/bundles/travel").Include("~/Areas/Travel/Scripts/Travel.js"));

            //Validation
            bundles.Add(new ScriptBundle("~/bundles/validation").Include("~/Scripts/ScriptsLib/jQuery/jquery.validate.min.js",
                "~/Scripts/ScriptsLib/jQuery/jquery.validate.unobtrusive.min.js",
                "~/Scripts/ScriptsLib/jQuery/jquery.unobtrusive-ajax.min.js"));

            #endregion

            #region CSS Bundles

            // Bootstrap
            bundles.Add(new StyleBundle("~/content/bootstrap").Include("~/Content/bootstrap/bootstrap.min.css"));

            // Layout
            bundles.Add(new StyleBundle("~/content/layout").Include("~/Content/LessInput/Layout.min.css"));

            // Shared
            bundles.Add(new StyleBundle("~/content/shared").Include("~/Content/LessInput/Shared.min.css"));

            // Home
            bundles.Add(new StyleBundle("~/content/home").Include("~/Content/LessInput/Home.min.css"));

            // Blog
            bundles.Add(new StyleBundle("~/content/blog").Include("~/Areas/Blog/Content/LessInput/Blog.min.css"));

            // Travel
            bundles.Add(new StyleBundle("~/content/travel").Include("~/Areas/Travel/Content/LessInput/Travel.min.css"));

            // Admin
            bundles.Add(new StyleBundle("~/content/admin").Include("~/Areas/Admin/Content/LessInput/Admin.min.css"));

            // Account
            bundles.Add(new StyleBundle("~/content/account").Include("~/Areas/Admin/Content/LessInput/Account.min.css"));

            #endregion
        }
    }
}