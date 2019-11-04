namespace QuickEstimationDAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Estimator : DbContext
    {
        // Your context has been configured to use a 'Estimator' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'QuickEstimationDAL.Estimator' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Estimator' 
        // connection string in the application configuration file.
        public Estimator() : base("name=Estimator")
        {
        }       


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Catagory> Catogories { get; set; }
        public virtual DbSet<EstimationVersionsHistory> VersionHistory { get; set; }
        public virtual DbSet<VersionDetails_Phased> VersionDetails_Phased { get; set; }
        public virtual DbSet<VersionDetails_Featured> VersionDetailsFeatured { get; set; }
        public virtual DbSet<ProjectReleaseEfforts_Featured> ProjectReleaseEffortsFeatured { get; set; }
        public virtual DbSet<Assumptions> Assumptions { get; set; }
        public virtual DbSet<InScope> InScope { get; set; }
        public virtual DbSet<OutScope> OutScope { get; set; }
    }    

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}