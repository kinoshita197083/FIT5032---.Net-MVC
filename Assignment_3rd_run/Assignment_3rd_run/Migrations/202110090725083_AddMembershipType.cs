namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Membership_type = c.String(),
                        price = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Memberships", "MembershipType_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Memberships", "MembershipType_Id1", c => c.Int());
            CreateIndex("dbo.Memberships", "MembershipType_Id1");
            AddForeignKey("dbo.Memberships", "MembershipType_Id1", "dbo.MembershipTypes", "Id");
            DropColumn("dbo.Memberships", "Length");
            DropColumn("dbo.Memberships", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Memberships", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Memberships", "Length", c => c.String());
            DropForeignKey("dbo.Memberships", "MembershipType_Id1", "dbo.MembershipTypes");
            DropIndex("dbo.Memberships", new[] { "MembershipType_Id1" });
            DropColumn("dbo.Memberships", "MembershipType_Id1");
            DropColumn("dbo.Memberships", "MembershipType_Id");
            DropTable("dbo.MembershipTypes");
        }
    }
}
