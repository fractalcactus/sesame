namespace ggak_final_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedurlstring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WayPoints", "URL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WayPoints", "URL");
        }
    }
}
