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
            modelBuilder.Configurations.Add(new ClientAddressMapping());
            modelBuilder.Configurations.Add(new CompanyAddressMapping());
            modelBuilder.Configurations.Add(new CompanyMapping());
            modelBuilder.Configurations.Add(new ClientPhoneNumberMapping());
            modelBuilder.Configurations.Add(new CompanyPhoneNumberMapping());
            modelBuilder.Configurations.Add(new InvestmentClientMapping());
            //modelBuilder.Configurations.Add(new InvestmentClientMapping());

            modelBuilder.Entity<ClientPoco>()
                .HasMany<ClientAddressPoco>(c => c.Addresses)
                .WithMany(a => a.Clients)
                .Map(ca =>
                    {
                        ca.MapLeftKey("ClientId");
                        ca.MapRightKey("AddressId");
                        ca.ToTable("ClientAddressJoin");

                    });

            modelBuilder.Entity<InvestmentPoco>()
                .HasMany<InvestmentClientPoco>(c => c.Clients)
                .WithMany(a => a.Investments)
                .Map(ca =>
                {
                    ca.MapLeftKey("InvestmentId");
                    ca.MapRightKey("ClientId");
                    ca.ToTable("InvestmentClientJoin");


                });
            modelBuilder.Entity<CompanyPoco>()
                .HasMany<CompanyAddressPoco>(c => c.Addresses)
                .WithMany(a => a.Companies)
                .Map(ca =>
                {
                    ca.MapLeftKey("CompanyId");
                    ca.MapRightKey("AddressId");
                    ca.ToTable("CompanyAddressJoin");

                });
            modelBuilder.Entity<ClientPoco>()
                .HasMany<ClientPhoneNumberPoco>(c => c.PhoneNumbers)
                .WithMany(p => p.Clients)
                .Map(ca =>
               {
                   ca.MapLeftKey("ClientId");
                   ca.MapRightKey("PhoneNumberId");
                   ca.ToTable("ClientPhoneNumberJoin");

               });
            modelBuilder.Entity<CompanyPoco>()
                .HasMany<CompanyPhoneNumberPoco>(c => c.PhoneNumbers)
                .WithMany(p => p.Companies)
                .Map(ca =>
               {
                   ca.MapLeftKey("CompanyId");
                   ca.MapRightKey("PhoneNumberId");
                   ca.ToTable("CompanyPhoneNumberJoin");

               });
        }

        public DbSet<ClientPoco> Clients { get; set; }
        public DbSet<CompanyPoco> Companies { get; set; }
        public DbSet<InvestmentPoco> Investments { get; set; }
        public DbSet<ClientAddressPoco> ClientAddresses { get; set; }
        public DbSet<CompanyAddressPoco> CompanyAddresses { get; set; }
        public DbSet<InvestmentClientPoco> InvestmentClients { get; set; }
        public DbSet <ClientPhoneNumberPoco > ClientPhones { get; set; }
        public DbSet <CompanyPhoneNumberPoco > CompanyPhones { get; set; }

    }
}
