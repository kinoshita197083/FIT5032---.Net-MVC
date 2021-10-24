namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedApptHistoryClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppointmentHistories", "EventId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppointmentHistories", "EventId", c => c.String());
        }
    }
}
