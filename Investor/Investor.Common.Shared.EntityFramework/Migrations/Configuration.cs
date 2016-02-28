using Investor.Common.Shared.Pocos;
using System.Data.Entity.Migrations;

namespace Investor.Common.Shared.EntityFramework.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<Investor.Common.Shared.EntityFramework.InvestorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Investor.Common.Shared.EntityFramework.InvestorContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Clients.AddOrUpdate(
                c => c.FirstName, new ClientPoco() { FirstName = "Joe", LastName = "Smith" });

            context.Investments.AddOrUpdate(
                i => i.InvestmentType, new InvestmentPoco() { InvestmentType = "RRSP" });
        }
    }
}
