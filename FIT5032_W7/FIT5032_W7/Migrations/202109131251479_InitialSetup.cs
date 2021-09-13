namespace FIT5032_W7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.UnitId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.Student_StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Units", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Units", new[] { "Student_StudentId" });
            DropTable("dbo.Units");
            DropTable("dbo.Students");
        }
    }
}
