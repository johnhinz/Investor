using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace Investor.Common.Service.Company.Logic
{
    public class CompanyLogic : ICompanyLogic
    {
        private ICompanyRepository _repository;

        public CompanyLogic(ICompanyRepository repository)
        {
            _repository = repository;
        }

        

        public CompanyPoco ReadCompany(long id)
        {
            return _repository.ReadCompany(id);
        }

        //public AddressPoco ReadAddress(long id)
        //{
        //    throw new System.NotImplementedException();
        //}

        public CompanyPoco Add(CompanyPoco company)
        {
            return _repository.Add(company);
        }

        public bool Update(long id,CompanyPoco company)
        {
          var isupdated=  _repository.Update(id, company);
            if (isupdated)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            var isDeleted = _repository.Delete(id);
            if (isDeleted)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        
       
    }
}
