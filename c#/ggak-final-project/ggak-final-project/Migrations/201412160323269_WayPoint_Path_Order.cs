namespace ggak_final_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WayPoint_Path_Order : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WayPoints", "Order", c => c.Int(nullable: false, defaultValue:0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WayPoints", "Order");
        }
    }
}
