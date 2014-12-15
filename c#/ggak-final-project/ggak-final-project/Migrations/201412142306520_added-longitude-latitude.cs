namespace ggak_final_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlongitudelatitude : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WayPoints", "Latitude", c => c.Single(nullable: false));
            AddColumn("dbo.WayPoints", "Longitude", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WayPoints", "Longitude");
            DropColumn("dbo.WayPoints", "Latitude");
        }
    }
}
