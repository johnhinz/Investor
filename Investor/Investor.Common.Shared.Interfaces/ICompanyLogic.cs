using Investor.Common.Shared.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Interfaces
{
    public interface ICompanyLogic
    {
        CompanyPoco ReadCompany(long id);
      //  AddressPoco ReadAddress(long id);

        CompanyPoco Add(CompanyPoco company);
      
        bool Update(long id,CompanyPoco company);



        bool Delete(long id);
    }
}
