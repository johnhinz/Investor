using Investor.Common.Shared.EntityFramework;
using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;
using System.Linq;

namespace Investor.Common.Service.Investment.Data
{
    public class InvestmentRepository : IInvestmentRepository
    {
        protected InvestorContext _db;
        public InvestmentRepository()
        {
            _db = new InvestorContext();
        }

        public void Create(InvestmentPoco investment)
        {
            _db.Investments.Add(investment);
            _db.SaveChanges();
        }

        public void Delete(long id)
        {
            InvestmentPoco p = _db.Investments.Find(id);
            _db.Investments.Remove(p);
            _db.SaveChanges();
        }

        public InvestmentPoco Read(long id)
        {
            return _db.Investments.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
