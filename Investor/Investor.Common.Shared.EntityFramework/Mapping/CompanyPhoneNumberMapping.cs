using Investor.Common.Shared.Pocos;
using System;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.EntityFramework.Mapping
{
    class CompanyPhoneNumberMapping:EntityTypeConfiguration <CompanyPhoneNumberPoco  >

    {
        public CompanyPhoneNumberMapping ()
        {
            ToTable("CompanyPhoneNumber");
            HasKey(c => c.Id);
            HasMany(p => p.Companies);

        }
    }
}
