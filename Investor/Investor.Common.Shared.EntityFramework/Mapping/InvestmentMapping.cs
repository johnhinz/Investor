using Investor.Common.Shared.Pocos;
using System.Data.Entity.ModelConfiguration;

namespace Investor.Common.Shared.EntityFramework.Mapping
{
    public class InvestmentMapping: EntityTypeConfiguration<InvestmentPoco>
    {
        public InvestmentMapping()
        {
            ToTable("Investment");
            HasKey(c => c.Id);
        }
    }
}
