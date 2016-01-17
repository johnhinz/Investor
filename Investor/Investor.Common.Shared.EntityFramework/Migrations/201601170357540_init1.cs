namespace Investor.Common.Shared.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ClientPocoes", newName: "Client");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Client", newName: "ClientPocoes");
        }
    }
}
