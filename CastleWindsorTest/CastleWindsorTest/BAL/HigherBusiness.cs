using CastleWindsorTest.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleWindsorTest.BAL
{
    public interface IHigherBusiness
    {
        void DoSomething();
    }

    public class HigherBusiness : IHigherBusiness
    {
        private readonly ISomeBusiness _someBusiness;

        public HigherBusiness(ISomeBusiness someBusiness)
        {
            this._someBusiness = someBusiness;
        }
        public void DoSomething()
        {
            _someBusiness.DoSomething();
        }
    }

    public interface ISomeBusiness
    {
        void DoSomething();
    }

    public class Business : ISomeBusiness
    {
        private readonly ILogger _logger;
        public Business(ILogger logger)
        {
            this._logger = logger;
        }
        public void DoSomething()
        {
            _logger.Log("Message");
        }
    }
}
