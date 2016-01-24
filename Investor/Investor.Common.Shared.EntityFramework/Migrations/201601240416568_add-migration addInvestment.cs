namespace Investor.Common.Shared.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationaddInvestment : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InvestmentPocoes", newName: "Investment");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Investment", newName: "InvestmentPocoes");
        }
    }
}
