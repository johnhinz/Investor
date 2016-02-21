using Investor.Common.Service.Investment.Poco;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
