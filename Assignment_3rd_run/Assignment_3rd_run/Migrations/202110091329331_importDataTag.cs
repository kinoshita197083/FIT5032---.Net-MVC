namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class importDataTag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO dbo.Tags (Type) VALUES ('Politics')");
            Sql("INSERT INTO dbo.Tags (Type) VALUES ('Tech')");
            Sql("INSERT INTO dbo.Tags (Type) VALUES ('Sports')");
            Sql("INSERT INTO dbo.Tags (Type) VALUES ('Finance')");

        }
        
        public override void Down()
        {
            DropTable("dbo.Tags");
        }
    }
}
