namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedMembership : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscribeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Columns", "Subscribed_Id", c => c.Int());
            AddColumn("dbo.Memberships", "User_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Memberships", "Subscriptions_Id", c => c.Int());
            AddColumn("dbo.News", "Subscribed_Id", c => c.Int());
            CreateIndex("dbo.Columns", "Subscribed_Id");
            CreateIndex("dbo.Memberships", "Subscriptions_Id");
            CreateIndex("dbo.News", "Subscribed_Id");
            AddForeignKey("dbo.Columns", "Subscribed_Id", "dbo.Subscribeds", "Id");
            AddForeignKey("dbo.News", "Subscribed_Id", "dbo.Subscribeds", "Id");
            AddForeignKey("dbo.Memberships", "Subscriptions_Id", "dbo.Subscribeds", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Memberships", "Subscriptions_Id", "dbo.Subscribeds");
            DropForeignKey("dbo.News", "Subscribed_Id", "dbo.Subscribeds");
            DropForeignKey("dbo.Columns", "Subscribed_Id", "dbo.Subscribeds");
            DropIndex("dbo.News", new[] { "Subscribed_Id" });
            DropIndex("dbo.Memberships", new[] { "Subscriptions_Id" });
            DropIndex("dbo.Columns", new[] { "Subscribed_Id" });
            DropColumn("dbo.News", "Subscribed_Id");
            DropColumn("dbo.Memberships", "Subscriptions_Id");
            DropColumn("dbo.Memberships", "User_Id");
            DropColumn("dbo.Columns", "Subscribed_Id");
            DropTable("dbo.Subscribeds");
        }
    }
}
