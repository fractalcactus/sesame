namespace ggak_final_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WayPoint_Paths_Relationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.WayPoints", "Path_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.WayPoints", "Path_Id");
            AddForeignKey("dbo.WayPoints", "Path_Id", "dbo.Paths", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WayPoints", "Path_Id", "dbo.Paths");
            DropIndex("dbo.WayPoints", new[] { "Path_Id" });
            DropColumn("dbo.WayPoints", "Path_Id");
            DropTable("dbo.Paths");
        }
    }
}
