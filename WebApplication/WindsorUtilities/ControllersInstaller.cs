using System.Web.Http.Controllers;

namespace WebApplication.WindsorUtilities
{
    using System.Web.Mvc;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(FindControllers().LifestyleTransient());

            //Web API
            container.Register(
                 Classes.
                      FromThisAssembly().
                          BasedOn<IHttpController>(). 
                              If(c => c.Name.EndsWith("Controller")).
                                     LifestyleTransient()); 

        }

        private static BasedOnDescriptor FindControllers()
        {
            return Classes.FromThisAssembly()
                .BasedOn<IController>()
                .If(t => t.Name.EndsWith("Controller"));
        }
    }
}