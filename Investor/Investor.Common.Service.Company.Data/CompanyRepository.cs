using System;
using System.Collections.Generic;
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
        public void CreateAddress(long id, CompanyAddressPoco address)
        {
            CompanyPoco c = _db.Companies.Single(comp => comp.Id == id);
            c.Addresses.Add(address);
            _db.SaveChanges();
        }
        public IEnumerable<CompanyAddressPoco> ReadAddresses(long id)
        {
            return _db.Companies.Where(c => c.Id == id).SelectMany(a => a.Addresses);
            //return _db.CompanyAddresses.Where(a => a.Companies.Where(c=>c.Id==id).Select(ad=>ad.Addresses)).ToList();
        }
        public bool UpdateAddress(long id, CompanyAddressPoco address)
        {
            try
            {
                CompanyPoco c = _db.Companies.Where(comp => comp.Id == id).FirstOrDefault();
                CompanyAddressPoco a = c.Addresses.Single(ad => ad.AddressId == address.AddressId);
                a.Street = address.Street;
                a.Province = address.Province;
                a.City = address.City;
                a.Postal_Code = address.Postal_Code;
                _db.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public void DeleteAddress(long companyId, long addressid)
        {
            CompanyAddressPoco a = _db.CompanyAddresses.Single(ad => ad.AddressId == addressid);
            CompanyPoco c = _db.Companies.Single(comp => comp.Id == companyId);
            c.Addresses.Remove(a);
            _db.SaveChanges();

        }
        public void CreatePhoneNumber(long id, CompanyPhoneNumberPoco phoneNumber)
        {
            CompanyPoco c = _db.Companies.Single(comp => comp.Id == id);
            c.PhoneNumbers.Add(phoneNumber);
            _db.SaveChanges();
        }


        public IEnumerable<CompanyPhoneNumberPoco> ReadPhoneNumber(long id)
        {
            return _db.Companies.Where(c => c.Id == id).SelectMany(a => a.PhoneNumbers);
          
        }

        public bool UpdatePhoneNumber(long id, CompanyPhoneNumberPoco phoneNumber)
        {
            try
            {
                CompanyPoco c = _db.Companies.Where(comp => comp.Id == id).FirstOrDefault();
                CompanyPhoneNumberPoco a = c.PhoneNumbers.Single(ad => ad.PhoneNumberId == phoneNumber.PhoneNumberId);
                a.PhoneNo = phoneNumber.PhoneNo;
                a.PhoneType = phoneNumber.PhoneType;
               _db.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public void DeletePhoneNumber(long companyId, long phoneNumberId)
        {
            CompanyPhoneNumberPoco a = _db.CompanyPhones.Single(ad => ad.PhoneNumberId == phoneNumberId);
            CompanyPoco c = _db.Companies.Single(comp => comp.Id == companyId);
            c.PhoneNumbers.Remove(a);
            _db.SaveChanges();

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