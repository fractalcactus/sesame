namespace ggak_final_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class addedcoordinateswithDbGeometry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WayPoints", "Coordinate", c => c.Geometry());
            DropColumn("dbo.WayPoints", "Latitude");
            DropColumn("dbo.WayPoints", "Longitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WayPoints", "Longitude", c => c.Single(nullable: false));
            AddColumn("dbo.WayPoints", "Latitude", c => c.Single(nullable: false));
            DropColumn("dbo.WayPoints", "Coordinate");
        }
    }
}
