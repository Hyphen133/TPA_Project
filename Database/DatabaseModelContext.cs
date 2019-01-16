using Database.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Database
{
    public class DatabaseModelContext : DbContext
    {
        public DatabaseModelContext(string connectionString) : base(connectionString)
        { }

        public DbSet<DatabaseAssemblyMetadata> Assemblies { get; set; }
        public DbSet<DatabaseMethodMetadata> Methods { get; set; }
        public DbSet<DatabaseNamespaceMetadata> Namespaces { get; set; }
        public DbSet<DatabaseParameterMetadata> Parameters { get; set; }
        public DbSet<DatabasePropertyMetadata> Properties { get; set; }
        public DbSet<DatabaseTypeMetadata> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<DatabaseAssemblyMetadata>()
                .HasMany<DatabaseNamespaceMetadata>(a => a.NamespacesL);

            modelBuilder.Entity<DatabaseNamespaceMetadata>()
                .HasMany<DatabaseTypeMetadata>(n => n.TypesL);

            modelBuilder.Entity<DatabaseTypeMetadata>()
                .HasMany<DatabasePropertyMetadata>(n => n.PropertiesL);

            modelBuilder.Entity<DatabaseTypeMetadata>()
                .HasOptional<DatabaseTypeMetadata>(t => t.ImplementedInterface)
                .WithMany(t => t.ImplementedInterfacesL)
                .HasForeignKey(t => t.ImplementedInterfaceID);

            //modelBuilder.Entity<DatabasePropertyMetadata>()
            //  .HasRequired(p => p.TypeMetadata)
            //.WithMany(t => t.PropertiesL)
            //.HasForeignKey(p => p.TypeID);


        }
    }
}
