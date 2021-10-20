namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class debugAttempted : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Title", c => c.String());
        }
    }
}
