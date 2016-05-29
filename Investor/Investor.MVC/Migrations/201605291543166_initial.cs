namespace Investor.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvestmentDtoes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        InvestmentType = c.Long(nullable: false),
                        CompanyId = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Term = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        MatureDate = c.DateTime(nullable: false),
                        ClientId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InvestmentDtoes");
        }
    }
}
