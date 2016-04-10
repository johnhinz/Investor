using Investor.Common.Shared.Pocos;
using System.Data.Entity.ModelConfiguration;

namespace Investor.Common.Shared.EntityFramework.Mapping
{
    public class InvestmentTypeMapping : EntityTypeConfiguration<InvestmentTypePoco>
    {
        public InvestmentTypeMapping()
        {
            ToTable("InvestmentType");
            HasKey(c => c.Id);
        }
    }
    
}
