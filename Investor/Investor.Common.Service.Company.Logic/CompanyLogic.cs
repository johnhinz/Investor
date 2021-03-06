﻿using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace Investor.Common.Service.Company.Logic
{
    public class CompanyLogic : ICompanyLogic
    {
        private ICompanyRepository _repository;

        public CompanyLogic(ICompanyRepository repository)
        {
            _repository = repository;
        }



        public CompanyPoco ReadCompany(long id)
        {
            return _repository.ReadCompany(id);
        }

        //public AddressPoco ReadAddress(long id)
        //{
        //    throw new System.NotImplementedException();
        //}

        public CompanyPoco Add(CompanyPoco company)
        {
            return _repository.Add(company);
        }

        public bool Update(long id, CompanyPoco company)
        {
            var isupdated = _repository.Update(id, company);
            if (isupdated)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            var isDeleted = _repository.Delete(id);
            if (isDeleted)
            {
                return true;
            }
            else
            {
                return false;

            }
        }





        public IEnumerable<CompanyAddressPoco> ReadAddresses(long id)
        {
            return _repository.ReadAddresses(id);
        }

        public void CreateAddress(long id, CompanyAddressPoco address)
        {
            _repository.CreateAddress(id, address);

        }

        public bool UpdateAddress(long companyId, CompanyAddressPoco address)
        {
            var isupdated = _repository.UpdateAddress(companyId, address);
            if (isupdated)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        public void DeleteAddress(long companyId, long addressId)
        {
            _repository.DeleteAddress(companyId, addressId);

        }

        public void CreatePhoneNumber(long id, CompanyPhoneNumberPoco phoneNumber)
        {
            _repository.CreatePhoneNumber(id, phoneNumber);

        }

        public IEnumerable<CompanyPhoneNumberPoco> ReadPhoneNumber(long id)
        {
           return _repository.ReadPhoneNumber(id);
        }
        public bool UpdatePhoneNumber(long companyId, CompanyPhoneNumberPoco phoneNumber)
        {
            var isupdated = _repository.UpdatePhoneNumber(companyId, phoneNumber);
            if (isupdated)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        public void DeletePhoneNumber(long companyId, long phoneNumberId)
        {
            _repository.DeleteAddress(companyId, phoneNumberId);
        }
    }
}