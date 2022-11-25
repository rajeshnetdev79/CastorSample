using CastleWindsorTest.BusinessAccessLayer;
using CastleWindsorTest.Logs;
using System;
using System.Diagnostics.Contracts;
using Castle.Windsor;

namespace CastleWindsorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var castleRegistration = new CastleRegistration();
            var container = castleRegistration.Register();
            var centralBusiness = container.Resolve<ICentralBusiness>();
            centralBusiness.Expenditure();
            var supportBusiness = container.Register().Resolve<ISupportBusiness>();
            supportBusiness.Expenditure();
            var logger = container.Register().Resolve<ILogger>();
            logger.Log("Some Log... .");
            Console.ReadKey();
        }
        }
    }

