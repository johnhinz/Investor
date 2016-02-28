using Investor.Common.Shared.EntityFramework.Mapping;
using Investor.Common.Shared.Pocos;
using System.Data.Entity;

namespace Investor.Common.Shared.EntityFramework
{
    public class InvestorContext : DbContext
    {
        public InvestorContext() : base ("InvestorContext")
        {
            Database.SetInitializer<InvestorContext>(null);
#if DEBUG
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
#endif
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMapping());
            modelBuilder.Configurations.Add(new InvestmentMapping());
            modelBuilder.Configurations.Add(new AddressMapping());
            modelBuilder.Configurations.Add(new CompanyMapping());
            //modelBuilder.Configurations.Add(new InvestmentClientMapping());

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
