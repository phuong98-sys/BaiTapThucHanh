namespace OutlookFW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_token_type : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppTokens", "type", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppTokens", "type");
        }
    }
}
