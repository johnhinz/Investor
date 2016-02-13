//using Investor.Common.Service.Address.Poco;
using Investor.Common.Service.Client.Poco;
using Investor.Common.Service.Company.Poco;
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
            modelBuilder.Configurations.Add(new AddressMapping());
            modelBuilder.Configurations.Add(new CompanyMapping());

            modelBuilder.Entity<ClientPoco>()
                .HasMany<AddressPoco>(c => c.Addresses)
                .WithMany(a => a.Clients)
                .Map(ca =>
                    {
                        ca.MapLeftKey("ClientId");
                        ca.MapRightKey("AddressId");
                        ca.ToTable("ClientAddresses");

                    });
        }

        public DbSet<ClientPoco> Clients { get; set; }
        public DbSet<CompanyPoco> Companies { get; set; }
        public DbSet<InvestmentPoco> Investments { get; set; }
        public DbSet<AddressPoco> Addresses { get; set; }
    }
}
