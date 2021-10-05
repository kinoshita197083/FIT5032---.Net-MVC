namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImportDummyData1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.News (Headline, Content, Type, Image) VALUES ('BREAKING', 'Content', 'Politics', '~/Images/Hi.jpg')");
            Sql("INSERT INTO dbo.News (Headline, Content, Type, Image) VALUES ('BREAKING2', 'Content', 'Sports', '~/Images/Hi.jpg')");
            Sql("INSERT INTO dbo.News (Headline, Content, Type, Image) VALUES ('BREAKING3', 'Content', 'Finance', '~/Images/Hi.jpg')");
        }
        
        public override void Down()
        {
        }
    }
}
