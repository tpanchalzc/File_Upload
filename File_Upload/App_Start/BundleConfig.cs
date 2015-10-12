using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace File_Upload.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts").Include("~/Scripts/bootstrap.js",
                                         "~/Scripts/jquery-2.1.4.js"));
            bundles.Add(new StyleBundle("~/Styles").Include("~/Content/bootstrap.css",
                                                         "~/Content/bootstrap-theme.css"));
        }
    }
}