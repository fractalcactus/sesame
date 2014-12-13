namespace ggak_final_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedtofloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WayPoints", "Lat", c => c.Single(nullable: false));
            AlterColumn("dbo.WayPoints", "Long", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WayPoints", "Long", c => c.Geometry());
            AlterColumn("dbo.WayPoints", "Lat", c => c.Geometry());
        }
    }
}
