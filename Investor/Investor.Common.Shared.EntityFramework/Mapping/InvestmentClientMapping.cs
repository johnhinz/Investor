using Investor.Common.Shared.Pocos;
using System.Data.Entity.ModelConfiguration;

namespace Investor.Common.Shared.EntityFramework.Mapping
{
    class InvestmentClientMapping : EntityTypeConfiguration<InvestmentClientPoco>
    {
        public InvestmentClientMapping()
        {

            ToTable("InvestmentClient");
            HasKey(im =>new { im.Client,im.Investment});
            HasRequired(im => im.Client);
            HasRequired(im => im.Investment);
        }
    }
}
