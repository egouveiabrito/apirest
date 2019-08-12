using Entity;
using Entity.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infrastructure.Context
{
    public class DatabaseContext : DbContext
    {
        
        public DbSet<User> User { get; set; }
        public DbSet<Phones> Phones { get; set; }



        public DatabaseContext() : base("Default")
        {
            //disable initializer reset migration
            Database.SetInitializer<DatabaseContext>(null);

            Database.CommandTimeout = 3600;
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 3600;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        }
    }
}
