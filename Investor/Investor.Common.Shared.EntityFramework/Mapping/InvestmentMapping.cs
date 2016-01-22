using System;
using System.Collections.Generic;
using Investor.Common.Service.Investment.Poco;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
