namespace Investor.Common.Shared.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "AddressId", c => c.Long(nullable: false));
            AddColumn("dbo.Client", "DoB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Client", "SocialIns", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "SocialIns");
            DropColumn("dbo.Client", "DoB");
            DropColumn("dbo.Client", "AddressId");
        }
    }
}
