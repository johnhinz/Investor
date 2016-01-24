using Investor.Common.Service.Company.Poco;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.EntityFramework.Mapping
{
    class CompanyMapping : EntityTypeConfiguration<CompanyPoco>
    {
        public CompanyMapping()
        {
            ToTable("Company");
            HasKey(c => c.Id);
        }

    }
}
