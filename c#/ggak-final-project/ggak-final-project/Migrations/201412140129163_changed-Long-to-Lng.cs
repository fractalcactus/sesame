namespace ggak_final_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedLongtoLng : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WayPoints", "Lng", c => c.Single(nullable: false));
            DropColumn("dbo.WayPoints", "Long");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WayPoints", "Long", c => c.Single(nullable: false));
            DropColumn("dbo.WayPoints", "Lng");
        }
    }
}
