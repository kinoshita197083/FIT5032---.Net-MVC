namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regularUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsColumnsViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Columns", "NewsColumnsViewModel_Id", c => c.Int());
            AddColumn("dbo.News", "NewsColumnsViewModel_Id", c => c.Int());
            CreateIndex("dbo.Columns", "NewsColumnsViewModel_Id");
            CreateIndex("dbo.News", "NewsColumnsViewModel_Id");
            AddForeignKey("dbo.Columns", "NewsColumnsViewModel_Id", "dbo.NewsColumnsViewModels", "Id");
            AddForeignKey("dbo.News", "NewsColumnsViewModel_Id", "dbo.NewsColumnsViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "NewsColumnsViewModel_Id", "dbo.NewsColumnsViewModels");
            DropForeignKey("dbo.Columns", "NewsColumnsViewModel_Id", "dbo.NewsColumnsViewModels");
            DropIndex("dbo.News", new[] { "NewsColumnsViewModel_Id" });
            DropIndex("dbo.Columns", new[] { "NewsColumnsViewModel_Id" });
            DropColumn("dbo.News", "NewsColumnsViewModel_Id");
            DropColumn("dbo.Columns", "NewsColumnsViewModel_Id");
            DropTable("dbo.NewsColumnsViewModels");
        }
    }
}
