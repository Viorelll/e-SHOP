using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Infrastructure;
using Presentation.MVC.Filters;
using WebApplication.App_Start;
using WebApplication.Helpers;
using WebApplication.WindsorUtilities;

namespace WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private IWindsorContainer _container;
        protected void Application_Start()
        {
            NHibernateProfiler.Initialize();
            AreaRegistration.RegisterAllAreas();
            GlobalFilters.Filters.Add(new HandleAllErrorAttribute());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           


            // Setup Castle.Windsor IOC
            _container = new WindsorContainer().Install(FromAssembly.This());


            _container.Install(new ControllersInstaller()); // for web api

            ServiceLocator.RegisterAll(_container.Kernel);

            // Web API
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorWebApiControllerFactory(_container));

            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);


            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_container.Kernel));

      




            // Setup automapper
            MappingConfig.RegisterMaps();

            // Bundles registrator
            BundlesRegistrator.RegisterBundles(BundleTable.Bundles);

          

        }
    }

  
}
