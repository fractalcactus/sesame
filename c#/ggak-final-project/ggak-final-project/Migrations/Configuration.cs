using ggak_final_project.Models;

namespace ggak_final_project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ggak_final_project.Models.WorldPlaygroundDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ggak_final_project.Models.WorldPlaygroundDBContext context)
        {
            ////  This method will be called after migrating to the latest version.

            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            ////  to avoid creating duplicate seed data. E.g.
            ////
            //WorldPlaygroundDBContext.AddOrUpdate(
            //  p => p.FullName,
            //  new WayPoint()
            //  new Person { FullName = "Brice Lambson" },
            //  new Person { FullName = "Rowan Miller" }
            //);
            
        }
    }
}
