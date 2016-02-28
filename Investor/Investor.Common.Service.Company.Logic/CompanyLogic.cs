using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;

namespace Investor.Common.Service.Company.Logic
{
    public class CompanyLogic : ICompanyLogic
    {
        private ICompanyRepository _repository;

        public CompanyLogic(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public CompanyPoco Read(long id)
        {
            return _repository.Read(id);
        }

    }
}
