using Investor.Common.Service.Company.Interface;
using Investor.Common.Service.Company.Poco;
using Investor.Common.Shared.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Service.Company.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private InvestorContext _db;

        public CompanyRepository()
        {
            _db = new InvestorContext();
        }
        public CompanyPoco Read(long id)
        {
            return _db.Companies.Where(comp => comp.Id == id).FirstOrDefault();
        }
    }
}
