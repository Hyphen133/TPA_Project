using Database.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Database
{
    public class DatabaseModelContext : DbContext
    {
        public DatabaseModelContext() : base("DatabaseModel")
        { }

        public DbSet<DatabaseAssemblyMetadata> Assemblies { get; set; }
        public DbSet<DatabaseMethodMetadata> Methods { get; set; }
        public DbSet<DatabaseNamespaceMetadata> Namespaces { get; set; }
        public DbSet<DatabaseParameterMetadata> Parameters { get; set; }
        public DbSet<DatabasePropertyMetadata> Properties { get; set; }
        public DbSet<DatabaseTypeMetadata> Types { get; set; }
    }
}
