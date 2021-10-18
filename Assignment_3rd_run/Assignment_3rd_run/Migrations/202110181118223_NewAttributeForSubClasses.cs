namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewAttributeForSubClasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubColumns", "SubscribedString", c => c.String());
            AddColumn("dbo.SubNews", "SubscribedString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubNews", "SubscribedString");
            DropColumn("dbo.SubColumns", "SubscribedString");
        }
    }
}
