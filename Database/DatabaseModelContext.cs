using Database.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Database
{
    public class DatabaseModelContext : DbContext
    {
        private static string connection = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Radioaktywny\Desktop\TPA_Project\Database\Database.mdf; Integrated Security = True; Connect Timeout = 30";

        public DatabaseModelContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DatabaseModelContext() : base(connection)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<DatabaseAssemblyMetadata> Assemblies { get; set; }
        public DbSet<DatabaseMethodMetadata> Methods { get; set; }
        public DbSet<DatabaseNamespaceMetadata> Namespaces { get; set; }
        public DbSet<DatabaseParameterMetadata> Parameters { get; set; }
        public DbSet<DatabasePropertyMetadata> Properties { get; set; }
        public DbSet<DatabaseTypeMetadata> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<DatabaseTypeMetadata>()
                .HasMany<DatabasePropertyMetadata>(s => s.PropertiesL)
                .WithMany(c => c.TypesProperties)
                .Map(cs =>
                {
                    cs.MapLeftKey("TypeRefId");
                    cs.MapRightKey("PropertyRefId");
                    cs.ToTable("TypeProperty");
                });
            modelBuilder.Entity<DatabaseMethodMetadata>()
                .HasMany<DatabaseTypeMetadata>(s => s.GenericArgumentsL)
                .WithMany(c => c.MethodsL)
                .Map(cs =>
                {
                    cs.MapLeftKey("MethodRefId");
                    cs.MapRightKey("GenericArgumentsRefId");
                    cs.ToTable("MethodGenericArguments");
                });

            modelBuilder.Entity<DatabaseTypeMetadata>()
                .HasMany(x => x.NestedTypesL)
                .WithMany()
                .Map(x => x.ToTable("NestedTypes"));

            modelBuilder.Entity<DatabaseTypeMetadata>()
                .HasMany(x => x.ImplementedInterfacesL)
                .WithMany()
                .Map(x => x.ToTable("Implemented interfaces"));*/
        }
    }
}
