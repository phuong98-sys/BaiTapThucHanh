namespace OutlookFW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_AppTokens : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccessToken = c.String(),
                        RefreshToken = c.String(),
                        user_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.user_Id)
                .Index(t => t.user_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppTokens", "user_Id", "dbo.AbpUsers");
            DropIndex("dbo.AppTokens", new[] { "user_Id" });
            DropTable("dbo.AppTokens");
        }
    }
}
