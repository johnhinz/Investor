using Investor.Common.Service.Company.Interface;
using Investor.Common.Service.Company.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Service.Company.Logic
{
    public class CompanyLogic:ICompanyLogic
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
