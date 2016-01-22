using Investor.Common.Service.Investment.Interface;
using Investor.Common.Service.Investment.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Service.Investment.Logic
{
    public class InvestmentLogic : IInvestmentLogic
    {
        private IInvestmentRepository _repository;

        public InvestmentLogic(IInvestmentRepository repository)
        {
            _repository = repository;
        }

        public void Create(InvestmentPoco investment)
        {
            _repository.Create(investment);
        }

        public InvestmentPoco Read(long id)
        {
            return _repository.Read(id);
        }
    }
}
