using Investor.Common.Service.Investment.Interface;
using Investor.Common.Service.Investment.Poco;
using Investor.Common.Shared.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
