
namespace Addvesting.Modules
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Runtime.InteropServices;

    public partial class AdvAgEntities : DbContext
    {
        public AdvAgEntities()
            : base("name=AdvAgEntities")
        {
        }

        static private AdvAgEntities _ctx;
        static public AdvAgEntities GetContext() => _ctx ?? (_ctx = new AdvAgEntities());   

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Auth> Auths { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Perfomance> Perfomances { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
