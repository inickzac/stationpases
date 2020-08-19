namespace stationpases.Model
{
    using stationpases.VMs;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StationDBContext : DbContext
    {

        static StationDBContext()
        {
            Database.SetInitializer(new DBInitialaizer());

        }


        public StationDBContext()
            : base("name=StationDBContext")
        {
        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SinglePass> SinglePasses { get; set; }
        public DbSet<IssuingAuthority> IssuingAuthorities { get; set; }
    }


}