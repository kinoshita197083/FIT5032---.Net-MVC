namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImportDummyImageDataSeed : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Columns (Column_header, Column_content, Column_type, Image) VALUES ('Column1', 'Content1', 'Finance', '~/Images/Hi.jpg')");
            Sql("INSERT INTO dbo.Columns (Column_header, Column_content, Column_type, Image) VALUES ('Column2', 'Content2', 'Sports', '~/Images/Leung.jpg')");
            Sql("INSERT INTO dbo.Columns (Column_header, Column_content, Column_type, Image) VALUES ('Column3', 'Content3', 'Politics', '~/Images/COV')");
            Sql("INSERT INTO dbo.Columns (Column_header, Column_content, Column_type, Image) VALUES ('Column4', 'Content4', 'Finance', '~Images/US.jfif')");
            Sql("INSERT INTO dbo.Columns (Column_header, Column_content, Column_type, Image) VALUES ('Column5', 'Content5', 'Politics', '~Images/rainbow.jpg')");
        }
        
        public override void Down()
        {
        }
    }
}
