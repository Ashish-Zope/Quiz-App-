using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace QuizzApp.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {



            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-3.0.0.js",
                "~/Scripts/popper.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery.easing.js"
                
                ));

          //  bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));


          //  bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

          //  bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/umd/bootstrap.min.js", "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/*.css"));
          //  BundleTable.EnableOptimizations = true; 

          
        }
    }
}