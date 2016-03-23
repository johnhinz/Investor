using Investor.Common.Shared.Pocos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.EntityFramework.Mapping
{
    public class CompanyAddressMapping : EntityTypeConfiguration<CompanyAddressPoco>
    {
        public CompanyAddressMapping()
        {
            ToTable("CompanyAddress");
            HasKey(c => c.AddressId);

            HasMany(a => a.Companies);
        }
    }
}
