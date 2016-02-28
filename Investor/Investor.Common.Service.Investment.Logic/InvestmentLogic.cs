using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;

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

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public InvestmentPoco Read(long id)
        {
            return _repository.Read(id);
        }
    }
}
