namespace ggak_final_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedlatlng : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.WayPoints", "Lat");
            DropColumn("dbo.WayPoints", "Lng");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WayPoints", "Lng", c => c.Single(nullable: false));
            AddColumn("dbo.WayPoints", "Lat", c => c.Single(nullable: false));
        }
    }
}
