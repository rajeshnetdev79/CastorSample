using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CastleWindsorTest.Logs;

namespace CastleWindsorTest.BusinessAccessLayer
{
    class CastleRegistration
    {
        public WindsorContainer Register()
        {
            var container = new Castle.Windsor.WindsorContainer();
            container.Register(
                Component.For<ICentralBusiness>()
                    .ImplementedBy<TexttileBusiness>()
                    .DependsOn(Dependency.OnComponent(typeof(ISupportBusiness),
                        "BusinessWithExtendedLogger"))
            );
            container.Register(Component.For<ISupportBusiness>().ImplementedBy<RetailBusiness>()
                .DependsOn(Dependency.OnComponent<ILogger, FullDetailLogger>())
                .Named("BusinessWithExtendedLogger")
            );
            container.Register(Component.For<ISupportBusiness>().ImplementedBy<RetailBusiness>()
                .DependsOn(Dependency.OnComponent<ILogger, SimpleLogger>())
                .IsDefault()
            );
            container.Register(Component.For<ILogger>().ImplementedBy<FullDetailLogger>()
                .IsFallback()
            );
            container.Register(Component.For<ILogger>().ImplementedBy<SimpleLogger>());
            return container;
        }

    }
}
