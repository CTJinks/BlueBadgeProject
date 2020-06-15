namespace PokeTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedDataBaseUserIssue : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "ApplicationUserID", "dbo.ApplicationUser");
            DropIndex("dbo.User", new[] { "ApplicationUserID" });
            AlterColumn("dbo.User", "ApplicationUserID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.User", "ApplicationUserID");
            AddForeignKey("dbo.User", "ApplicationUserID", "dbo.ApplicationUser", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "ApplicationUserID", "dbo.ApplicationUser");
            DropIndex("dbo.User", new[] { "ApplicationUserID" });
            AlterColumn("dbo.User", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.User", "ApplicationUserID");
            AddForeignKey("dbo.User", "ApplicationUserID", "dbo.ApplicationUser", "Id");
        }
    }
}
