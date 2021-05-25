namespace OutlookFW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditToken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppTokens", "access_token", c => c.String());
            AddColumn("dbo.AppTokens", "refresh_token", c => c.String());
            DropColumn("dbo.AppTokens", "AccessToken");
            DropColumn("dbo.AppTokens", "RefreshToken");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppTokens", "RefreshToken", c => c.String());
            AddColumn("dbo.AppTokens", "AccessToken", c => c.String());
            DropColumn("dbo.AppTokens", "refresh_token");
            DropColumn("dbo.AppTokens", "access_token");
        }
    }
}
