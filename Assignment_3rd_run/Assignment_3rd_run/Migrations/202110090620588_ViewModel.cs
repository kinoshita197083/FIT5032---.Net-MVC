namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Columns", "Membership_Id", "dbo.Memberships");
            DropForeignKey("dbo.News", "Membership_Id", "dbo.Memberships");
            DropIndex("dbo.Columns", new[] { "Membership_Id" });
            DropIndex("dbo.News", new[] { "Membership_Id" });
            DropColumn("dbo.Columns", "Membership_Id");
            DropColumn("dbo.News", "Membership_Id");
            DropTable("dbo.Memberships");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        System_Id = c.Int(nullable: false),
                        Birthday = c.DateTime(),
                        Length = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.News", "Membership_Id", c => c.Int());
            AddColumn("dbo.Columns", "Membership_Id", c => c.Int());
            CreateIndex("dbo.News", "Membership_Id");
            CreateIndex("dbo.Columns", "Membership_Id");
            AddForeignKey("dbo.News", "Membership_Id", "dbo.Memberships", "Id");
            AddForeignKey("dbo.Columns", "Membership_Id", "dbo.Memberships", "Id");
        }
    }
}
