namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationsToModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Memberships", "Name", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Memberships", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Memberships", "Birthday", c => c.DateTime());
            AlterColumn("dbo.Memberships", "Name", c => c.String(maxLength: 10));
        }
    }
}
