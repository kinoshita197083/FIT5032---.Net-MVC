namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newAttributeForColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Columns", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Columns", "Image");
        }
    }
}
