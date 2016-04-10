using Investor.Common.Shared.Pocos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.EntityFramework.Mapping
{
    class LogMapping : EntityTypeConfiguration<LogPoco>
    {
        public LogMapping()
        {
            ToTable("Logs");
            HasKey(l => l.Id);
        }
    }
}
