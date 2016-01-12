using Investor.Common.Service.Company.Interface;
using Investor.Common.Service.Company.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Service.Company.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        public CompanyPoco Get(long id)
        {
            return new CompanyPoco() { CompanyName = "Joe Smith Investments" };
        }
    }
}
