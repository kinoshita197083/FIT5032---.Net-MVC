namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubClassesImplemented : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubColumns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SystemId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubNews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SystemId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubNews");
            DropTable("dbo.SubColumns");
        }
    }
}
