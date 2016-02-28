using Investor.Common.Shared.Pocos;
using System.Data.Entity.ModelConfiguration;

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
