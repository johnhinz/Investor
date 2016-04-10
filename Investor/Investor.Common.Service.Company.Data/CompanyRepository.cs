using System;
using Investor.Common.Shared.EntityFramework;
using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Investor.Common.Service.Company.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private InvestorContext _db;

        public CompanyRepository()
        {
            _db = new InvestorContext();
        }
        public CompanyPoco ReadCompany(long id)
        {
            return _db.Companies.Where(comp => comp.Id == id).FirstOrDefault();
        }

        //public AddressPoco ReadAddress(long id)
        //{
        //    throw new NotImplementedException();
        //}


        public CompanyPoco Add(CompanyPoco company)
        {

            if (company == null)
            {
                throw new ArgumentNullException("Company");
            }

            _db.Companies.Add(company);
            _db.SaveChanges();
            return company;
        }

        public bool Update(long id, CompanyPoco company)
        {
            try
            {
                _db.Entry(company).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }




        public bool Delete(long id)
        {
            try
            {

                var company = _db.Companies.Find(id);
                if (company == null) return false;
                _db.Companies.Remove(company);
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
