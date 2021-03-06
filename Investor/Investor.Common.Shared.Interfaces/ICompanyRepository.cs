﻿using Investor.Common.Shared.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Interfaces
{
    public interface ICompanyRepository
    {

        CompanyPoco ReadCompany(long id);
        //  AddressPoco ReadAddress(long id);

        CompanyPoco Add(CompanyPoco company);
        IEnumerable<CompanyAddressPoco> ReadAddresses(long id);

        bool Update(long id, CompanyPoco company);
        void CreateAddress(long id, CompanyAddressPoco address);
        bool UpdateAddress(long id, CompanyAddressPoco address);
        void DeleteAddress(long companyId, long addressId);
        void CreatePhoneNumber(long id, CompanyPhoneNumberPoco phoneNumber);
        IEnumerable<CompanyPhoneNumberPoco> ReadPhoneNumber(long id);
        bool UpdatePhoneNumber(long id, CompanyPhoneNumberPoco phoneNumber);
        void DeletePhoneNumber(long companyId, long phoneNumberId);
        bool Delete(long id);

    }
}