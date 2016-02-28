using Investor.Common.Shared.Pocos;
using System.Data.Entity.ModelConfiguration;

namespace Investor.Common.Shared.EntityFramework.Mapping
{
    class InvestmentClientMapping : EntityTypeConfiguration<InvestmentClientPoco>
    {
        public InvestmentClientMapping()
        {
            ToTable("InvestmentClient");
            HasMany(im => im.Clients);
            HasRequired(im => im.Investment);
        }
    }
}
