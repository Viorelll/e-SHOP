using System.Web.Mvc;
using Factory;

namespace Infrastructure
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel;
    using Notification.Implementation;
    using Notification.Interfaces;
    using Payment.Interfaces;
    using Payment.Implementation;
    using Repository.Interfaces;
    using Repository.Implementation;

    internal static class ServiceLocator
    { 

        public static IKernel _kernel;

        public static void RegisterAll(IKernel kernel)
        {
            _kernel = kernel;

            //_kernel.Register(
            //    Component.For(typeof(IProductNotification))
            //    .ImplementedBy(typeof(ProductCreationNotificationBySms)));

            _kernel.Register(
                Component.For(typeof(ItemFactory))
               .ImplementedBy(typeof(ItemFactory)));


            _kernel.Register(
                Component.For(typeof(IProductNotification))
               .ImplementedBy(typeof(ProductTrackTraceNotification)));


            _kernel.Register(
                 Component.For(typeof(IPayment))
                .ImplementedBy(typeof(CreditCard)).Named("card"));

            _kernel.Register(
                Component.For(typeof(IPayment))
               .ImplementedBy(typeof(Paypal)).Named("paypal"));


            _kernel.Register(
                Component.For(typeof(IItemRepository)).LifestyleTransient()
               .ImplementedBy(typeof(ItemRepository)).LifestyleTransient());

            _kernel.Register(
               Component.For(typeof(IUserRepository)).LifestyleTransient()
              .ImplementedBy(typeof(UserRepository)).LifestyleTransient());

            _kernel.Register(Classes.FromAssemblyNamed("Elmah.Mvc")
           .BasedOn<IController>()
           .LifestyleTransient());


        }

        public static T Resolve<T>(string mode)
        {
            return _kernel.Resolve<T>(mode);
        }
        public static T Resolve<T>()
        {
            return _kernel.Resolve<T>();
        }
    }
}
