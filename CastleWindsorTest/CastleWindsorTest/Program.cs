using Castle.MicroKernel.Registration;
using CastleWindsorTest.BAL;
using CastleWindsorTest.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleWindsorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Castle.Windsor.WindsorContainer();
            container.Register(
                    Component.For<IHigherBusiness>()
                    .ImplementedBy<HigherBusiness>()
                    .DependsOn(Dependency.OnComponent(typeof(ISomeBusiness),
                                "BusinessWithExtendedLogger"))
                );
            container.Register(Component.For<ISomeBusiness>().ImplementedBy<Business>()
                    .DependsOn(Dependency.OnComponent<ILogger, FullDetailLogger>())
                    .Named("BusinessWithExtendedLogger")
                );
            container.Register(Component.For<ISomeBusiness>().ImplementedBy<Business>()
                    .DependsOn(Dependency.OnComponent<ILogger, SimpleLogger>())
                    .IsDefault()
                );
            container.Register(Component.For<ILogger>().ImplementedBy<FullDetailLogger>()
                    .IsFallback()
                );
            container.Register(Component.For<ILogger>().ImplementedBy<SimpleLogger>());

            var business = container.Resolve<IHigherBusiness>();
            business.DoSomething();

            var normalBusiness = container.Resolve<ISomeBusiness>();
            normalBusiness.DoSomething();

            var logger = container.Resolve<ILogger>();
            logger.Log("Some Log... .");
            Console.ReadKey();
        }
    }
}
