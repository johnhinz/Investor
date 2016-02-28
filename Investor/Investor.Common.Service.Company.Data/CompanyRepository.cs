using Investor.Common.Shared.EntityFramework;
using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;
using System.Linq;

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
