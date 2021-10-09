namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropcolumn : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Memberships", new[] { "MembershipType_Id1" });
        }
        
        public override void Down()
        {
        }
    }
}
