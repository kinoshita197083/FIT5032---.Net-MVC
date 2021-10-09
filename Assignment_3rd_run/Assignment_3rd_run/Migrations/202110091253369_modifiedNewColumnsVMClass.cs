namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedNewColumnsVMClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsColumnsViewModels", "System_Id", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewsColumnsViewModels", "System_Id");
        }
    }
}
