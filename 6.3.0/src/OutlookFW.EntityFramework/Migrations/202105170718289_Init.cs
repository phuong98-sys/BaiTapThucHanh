namespace OutlookFW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppMails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        subject = c.String(),
                        from = c.String(),
                        to = c.String(nullable: false),
                        date = c.String(),
                        body = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        GSenderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppSenders", t => t.GSenderId, cascadeDelete: true)
                .Index(t => t.GSenderId);
            
            CreateTable(
                "dbo.AppSenders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        Email = c.String(nullable: false, maxLength: 256),
                        Avatar = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppMails", "GSenderId", "dbo.AppSenders");
            DropIndex("dbo.AppMails", new[] { "GSenderId" });
            DropTable("dbo.AppSenders");
            DropTable("dbo.AppMails");
        }
    }
}
