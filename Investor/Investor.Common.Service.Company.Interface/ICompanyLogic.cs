using Investor.Common.Service.Company.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Service.Company.Interface
{
    public interface ICompanyLogic
    {
        CompanyPoco Read(long id);
    }
}
