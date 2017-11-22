using System.Web;
using System.Web.Optimization;

namespace WebApplication.Helpers
{
    public static class BundlesRegistrator
    {
        private static BundleCollection _bundleCollection;

        public static void RegisterBundles(BundleCollection bundleCollection)
        {
            _bundleCollection = bundleCollection;
            RegisterStyleBundles();
            RegisterScriptBundles();
        }

        private static void RegisterScriptBundles()
        {
           
            Bundle scriptBundleTemplate = CreateScriptBundle("~/templateScripts/TempScripts");
            Bundle scriptBundle = CreateScriptBundle("~/scripts/CommonScripts");

            scriptBundleTemplate.Include("~/templateScripts/jquery-1.10.2.js");
            scriptBundleTemplate.Include("~/templateScripts/bootstrap.min.js");
            scriptBundleTemplate.Include("~/templateScripts/jquery.scrollUp.min.js");
            scriptBundleTemplate.Include("~/templateScripts/price-range.js");
            scriptBundleTemplate.Include("~/templateScripts/jquery.prettyPhoto.js");
            scriptBundleTemplate.Include("~/templateScripts/main.js");

            scriptBundle.Include("~/scripts/jquery.validate.min.js");
            scriptBundle.Include("~/scripts/jquery.validate.unobtrusive.js");
            scriptBundle.Include("~/scripts/jquery-ui.js");
            scriptBundle.Include("~/scripts/customer.js");
            scriptBundle.Include("~/scripts/search.js");
            scriptBundle.Include("~/scripts/emailvalidation.js");



            _bundleCollection.Add(scriptBundleTemplate);
            _bundleCollection.Add(scriptBundle);    
        }

        private static void RegisterStyleBundles()
        {
            Bundle stylesBundle = CreateStylesBundle("~/Content/CommonStyles");
            Bundle stylesTemplateBundle = CreateStylesBundle("~/template/css/TemplateStyles");

            //CSS FOR JQUERY UI
            stylesBundle.Include("~/Content/jquery-ui.structure.css");
            stylesBundle.Include("~/Content/jquery-ui.min.css");
            stylesBundle.Include("~/Content/jquery-ui.theme.css");

            //CSS FOR WEB TEMPLATE
            stylesTemplateBundle.Include("~/template/css/bootstrap.min.css");
            stylesTemplateBundle.Include("~/template/css/font-awesome.min.css");
            stylesTemplateBundle.Include("~/template/css/prettyPhoto.css");
            stylesTemplateBundle.Include("~/template/css/price-range.css");
            stylesTemplateBundle.Include("~/template/css/animate.css");
            stylesTemplateBundle.Include("~/template/css/main.css");
            stylesTemplateBundle.Include("~/template/css/responsive.css");



            _bundleCollection.Add(stylesBundle);
            _bundleCollection.Add(stylesTemplateBundle);
        }


        private static Bundle CreateScriptBundle(string virtualPath)
        {
            return HttpContext.Current.IsDebuggingEnabled ? new Bundle(virtualPath) : new Bundle(virtualPath, new JsMinify());
        }

        private static Bundle CreateStylesBundle(string virtualPath)
        {
            return HttpContext.Current.IsDebuggingEnabled ? new Bundle(virtualPath) : new Bundle(virtualPath, new CssMinify());
        }

 

    }
}