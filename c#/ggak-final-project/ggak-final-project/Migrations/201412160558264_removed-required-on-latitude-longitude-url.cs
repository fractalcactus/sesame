namespace ggak_final_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedrequiredonlatitudelongitudeurl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WayPoints", "URL", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WayPoints", "URL", c => c.String(nullable: false));
        }
    }
}
