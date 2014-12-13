namespace ggak_final_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class addedlatlongrows : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WayPoints", "Lat", c => c.Geometry());
            AddColumn("dbo.WayPoints", "Long", c => c.Geometry());
            DropColumn("dbo.WayPoints", "Coordinate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WayPoints", "Coordinate", c => c.Geometry());
            DropColumn("dbo.WayPoints", "Long");
            DropColumn("dbo.WayPoints", "Lat");
        }
    }
}
