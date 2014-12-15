namespace ggak_final_project.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WorldPlaygroundDBContext : DbContext
    {
        // Your context has been configured to use a 'WorldPlaygroundDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ggak_final_project.Models.WorldPlaygroundDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'WorldPlaygroundDBContext' 
        // connection string in the application configuration file.
        public WorldPlaygroundDBContext() : base("name=WorldPlaygroundDBContext")
        {
             Database.SetInitializer(new MigrateDatabaseToLatestVersion<WorldPlaygroundDBContext, Migrations.Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<WayPoint> WayPoints { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WayPoint>().HasKey(i => i.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
     

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}