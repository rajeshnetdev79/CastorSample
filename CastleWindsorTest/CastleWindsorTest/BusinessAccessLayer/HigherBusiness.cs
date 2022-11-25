using CastleWindsorTest.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleWindsorTest.BusinessAccessLayer
{
    public interface ICentralBusiness
    {
        void Expenditure();
    }

    public class TexttileBusiness : ICentralBusiness
    {
        private readonly ISupportBusiness _supportBusiness;

        public TexttileBusiness(ISupportBusiness supportBusiness)
        {
            this._supportBusiness = supportBusiness;
        }
        public void Expenditure()
        {
            _supportBusiness.Expenditure();
        }
    }

    public interface ISupportBusiness
    {
        void Expenditure();
    }

    public class RetailBusiness : ISupportBusiness
    {
        private readonly ILogger _logger;
        public RetailBusiness(ILogger logger)
        {
            this._logger = logger;
        }
        public void Expenditure()
        {
            _logger.Log("Message");
        }
    }
}
