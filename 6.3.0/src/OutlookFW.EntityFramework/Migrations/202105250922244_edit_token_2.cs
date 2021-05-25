namespace OutlookFW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_token_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppTokens", "user_Id", "dbo.AbpUsers");
            DropIndex("dbo.AppTokens", new[] { "user_Id" });
            AlterColumn("dbo.AppTokens", "user_Id", c => c.Long(nullable: true));
            CreateIndex("dbo.AppTokens", "user_Id");
            AddForeignKey("dbo.AppTokens", "user_Id", "dbo.AbpUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppTokens", "user_Id", "dbo.AbpUsers");
            DropIndex("dbo.AppTokens", new[] { "user_Id" });
            AlterColumn("dbo.AppTokens", "user_Id", c => c.Long());
            CreateIndex("dbo.AppTokens", "user_Id");
            AddForeignKey("dbo.AppTokens", "user_Id", "dbo.AbpUsers", "Id");
        }
    }
}
