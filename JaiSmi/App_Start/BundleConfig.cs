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

            // Shared
            bundles.Add(new ScriptBundle("~/bundles/shared").Include("~/Scripts/Shared/Shared.js"));

            // Home
            bundles.Add(new ScriptBundle("~/bundles/home").Include("~/Scripts/Home/Home.js"));

            #endregion

            #region CSS Bundles

            // Bootstrap
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap/bootstrap.min.css"));

            // Layout
            bundles.Add(new StyleBundle("~/Content/layout").Include("~/Content/LessInput/Layout.min.css"));

            // Home
            bundles.Add(new StyleBundle("~/Content/home").Include("~/Content/LessInput/Home.min.css"));

            #endregion
        }
    }
}