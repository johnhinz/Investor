using Investor.Common.Shared.EntityFramework;
using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;
using System.Linq;
using System;
using System.Collections.Generic;


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

        public void CreateInvestmentType(InvestmentTypePoco investmenttype)
        {
            _db.InvestmentTypes.Add(investmenttype);
            _db.SaveChanges();
        }

        public void Delete(long id)
        {
            InvestmentPoco p = _db.Investments.Find(id);
            _db.Investments.Remove(p);
            _db.SaveChanges();
        }

        public void DeleteInvestmentType(long id)
        {
            InvestmentTypePoco p = _db.InvestmentTypes.Find(id);
            _db.InvestmentTypes.Remove(p);
            _db.SaveChanges();
        }

        public InvestmentPoco Read(long id)
        {
            return _db.Investments.Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<InvestmentPoco> ReadByMatureDate(DateTime maturedate, int skip, int take)
        {
            //return _db.Investments.Where(a => a.MatureDate.Contains(maturedate), skip, take).ToList();
            return null;
        }

        public IEnumerable<InvestmentClientPoco> ReadClient(long id)
        {

            return null;
           //return _db.InvestmentClients.Where(a=>a.Investments.Select(c=>c.Id).Contains(id)).ToList();
        }

        public InvestmentTypePoco ReadInvestmentType(long id)
        {
            return _db.InvestmentTypes.Where(a => a.Id == id).FirstOrDefault();
        }

        public bool Update(long id, InvestmentPoco investment)
        {
            try
            {
                _db.Entry(investment).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateInvestmentType(long id, InvestmentTypePoco investmenttype)
        {
            try
            {
                _db.Entry(investmenttype).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
