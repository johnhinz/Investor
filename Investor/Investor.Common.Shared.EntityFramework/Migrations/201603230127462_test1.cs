namespace Investor.Common.Shared.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientAddress",
                c => new
                    {
                        AddressId = c.Long(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        Postal_Code = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DoB = c.DateTime(nullable: false),
                        SocialIns = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CompanyName = c.String(),
                        ContactName = c.String(),
                        PhoneNumber = c.String(),
                        AgentId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyAddress",
                c => new
                    {
                        AddressId = c.Long(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        Postal_Code = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Investment",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        InvestmentType = c.String(),
                        CompanyId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientAddressJoin",
                c => new
                    {
                        ClientId = c.Long(nullable: false),
                        AddressId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClientId, t.AddressId })
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.ClientAddress", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.CompanyAddressJoin",
                c => new
                    {
                        CompanyId = c.Long(nullable: false),
                        AddressId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyId, t.AddressId })
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.CompanyAddress", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyAddressJoin", "AddressId", "dbo.CompanyAddress");
            DropForeignKey("dbo.CompanyAddressJoin", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.ClientAddressJoin", "AddressId", "dbo.ClientAddress");
            DropForeignKey("dbo.ClientAddressJoin", "ClientId", "dbo.Client");
            DropIndex("dbo.CompanyAddressJoin", new[] { "AddressId" });
            DropIndex("dbo.CompanyAddressJoin", new[] { "CompanyId" });
            DropIndex("dbo.ClientAddressJoin", new[] { "AddressId" });
            DropIndex("dbo.ClientAddressJoin", new[] { "ClientId" });
            DropTable("dbo.CompanyAddressJoin");
            DropTable("dbo.ClientAddressJoin");
            DropTable("dbo.Investment");
            DropTable("dbo.CompanyAddress");
            DropTable("dbo.Company");
            DropTable("dbo.Client");
            DropTable("dbo.ClientAddress");
        }
    }
}
