namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedMultipleRedunduncyClasses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Columns", "Subscribed_Id", "dbo.Subscribeds");
            DropForeignKey("dbo.News", "Subscribed_Id", "dbo.Subscribeds");
            DropForeignKey("dbo.Memberships", "Subscriptions_Id", "dbo.Subscribeds");
            DropForeignKey("dbo.Users", "Membership_Id1", "dbo.Memberships");
            DropIndex("dbo.Columns", new[] { "Subscribed_Id" });
            DropIndex("dbo.Memberships", new[] { "Subscriptions_Id" });
            DropIndex("dbo.News", new[] { "Subscribed_Id" });
            DropIndex("dbo.Users", new[] { "Membership_Id1" });
            AddColumn("dbo.Columns", "Membership_Id", c => c.Int());
            AddColumn("dbo.Memberships", "Name", c => c.String(maxLength: 10));
            AddColumn("dbo.Memberships", "System_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Memberships", "Birthday", c => c.DateTime());
            AddColumn("dbo.News", "Membership_Id", c => c.Int());
            CreateIndex("dbo.Columns", "Membership_Id");
            CreateIndex("dbo.News", "Membership_Id");
            AddForeignKey("dbo.Columns", "Membership_Id", "dbo.Memberships", "Id");
            AddForeignKey("dbo.News", "Membership_Id", "dbo.Memberships", "Id");
            DropColumn("dbo.Columns", "Subscribed_Id");
            DropColumn("dbo.Memberships", "User_Id");
            DropColumn("dbo.Memberships", "Subscriptions_Id");
            DropColumn("dbo.News", "Subscribed_Id");
            DropTable("dbo.Subscribeds");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        Membership_Id = c.Int(nullable: false),
                        Birthday = c.DateTime(),
                        Membership_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.News", "Subscribed_Id", c => c.Int());
            AddColumn("dbo.Memberships", "Subscriptions_Id", c => c.Int());
            AddColumn("dbo.Memberships", "User_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Columns", "Subscribed_Id", c => c.Int());
            DropForeignKey("dbo.News", "Membership_Id", "dbo.Memberships");
            DropForeignKey("dbo.Columns", "Membership_Id", "dbo.Memberships");
            DropIndex("dbo.News", new[] { "Membership_Id" });
            DropIndex("dbo.Columns", new[] { "Membership_Id" });
            DropColumn("dbo.News", "Membership_Id");
            DropColumn("dbo.Memberships", "Birthday");
            DropColumn("dbo.Memberships", "System_Id");
            DropColumn("dbo.Memberships", "Name");
            DropColumn("dbo.Columns", "Membership_Id");
            CreateIndex("dbo.Users", "Membership_Id1");
            CreateIndex("dbo.News", "Subscribed_Id");
            CreateIndex("dbo.Memberships", "Subscriptions_Id");
            CreateIndex("dbo.Columns", "Subscribed_Id");
            AddForeignKey("dbo.Users", "Membership_Id1", "dbo.Memberships", "Id");
            AddForeignKey("dbo.Memberships", "Subscriptions_Id", "dbo.Subscribeds", "Id");
            AddForeignKey("dbo.News", "Subscribed_Id", "dbo.Subscribeds", "Id");
            AddForeignKey("dbo.Columns", "Subscribed_Id", "dbo.Subscribeds", "Id");
        }
    }
}
