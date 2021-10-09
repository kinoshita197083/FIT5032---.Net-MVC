namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedMembershipCS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Columns", "Membership_Id", c => c.Int());
            AddColumn("dbo.News", "Membership_Id", c => c.Int());
            CreateIndex("dbo.Columns", "Membership_Id");
            CreateIndex("dbo.News", "Membership_Id");
            AddForeignKey("dbo.Columns", "Membership_Id", "dbo.Memberships", "Id");
            AddForeignKey("dbo.News", "Membership_Id", "dbo.Memberships", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "Membership_Id", "dbo.Memberships");
            DropForeignKey("dbo.Columns", "Membership_Id", "dbo.Memberships");
            DropIndex("dbo.News", new[] { "Membership_Id" });
            DropIndex("dbo.Columns", new[] { "Membership_Id" });
            DropColumn("dbo.News", "Membership_Id");
            DropColumn("dbo.Columns", "Membership_Id");
        }
    }
}
