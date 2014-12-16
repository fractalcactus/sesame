using ggak_final_project.Controllers;

namespace ggak_final_project.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public interface IWorldPlaygroundDBContext
    {
        IDbSet<WayPoint> WayPoints { get; set; }
        int SaveChanges();
        void Dispose();
    }

    public class WorldPlaygroundDBContext : DbContext, IWorldPlaygroundDBContext
    {
        // Your context has been configured to use a 'WorldPlaygroundDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ggak_final_project.Models.WorldPlaygroundDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'WorldPlaygroundDBContext' 
        // connection string in the application configuration file.
        public WorldPlaygroundDBContext() : base("name=WorldPlaygroundDBContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<WorldPlaygroundDBContext, Migrations.Configuration>());
          
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual IDbSet<WayPoint> WayPoints { get; set; }
        public virtual IDbSet<Path> Paths { get; set; } 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WayPoint>().HasKey(i => i.Id).HasRequired(p => p.Path).WithMany(w => w.WayPoints);
            modelBuilder.Entity<Path>().HasKey(i => i.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
     

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}