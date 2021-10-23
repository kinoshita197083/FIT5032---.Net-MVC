namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointmentHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.String(),
                        Feedback = c.Int(nullable: false),
                        SystemId = c.String(),
                        TheEvent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.TheEvent_Id)
                .Index(t => t.TheEvent_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppointmentHistories", "TheEvent_Id", "dbo.Events");
            DropIndex("dbo.AppointmentHistories", new[] { "TheEvent_Id" });
            DropTable("dbo.AppointmentHistories");
        }
    }
}
