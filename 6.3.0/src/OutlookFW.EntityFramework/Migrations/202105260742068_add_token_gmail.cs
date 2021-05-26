namespace OutlookFW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_token_gmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppTokens", "gmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppTokens", "gmail");
        }
    }
}
