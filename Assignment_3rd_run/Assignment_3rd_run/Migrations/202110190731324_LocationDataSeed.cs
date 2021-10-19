namespace Assignment_3rd_run.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationDataSeed : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Locations (Name, Description, Latitude,Longitude) VALUES(N'Whippet (Caufield)', N'Caulfield Branch', CAST(-37.87682300 AS Decimal(10, 8)), CAST(145.04583700 AS Decimal(11, 8)))");
            Sql("INSERT INTO dbo.Locations (Name, Description, Latitude,Longitude) VALUES(N'Whippet (Clayton)', N'Clayton Branch', CAST(-37.91500000 AS Decimal(10, 8)), CAST(145.13000000 AS Decimal(11, 8)))");
        }
        
        public override void Down()
        {
        }
    }
}
