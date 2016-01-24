using Investor.Common.Service.Client.Poco;
using Investor.Common.Service.Investment.Poco;
using Investor.Common.Shared.EntityFramework.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.EntityFramework
{
    public class InvestorContext : DbContext
    {
        public InvestorContext() : base ("InvestorContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMapping());
            modelBuilder.Configurations.Add(new InvestmentMapping());
        }

        public DbSet<ClientPoco> Clients { get; set; }

        public DbSet<InvestmentPoco> Investments { get; set; }

    }
}
