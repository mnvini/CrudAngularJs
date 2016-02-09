using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Angular.App.Data.EntityConfig;

namespace Angular.App.Data
{
    public class DataContext: DbContext
    {
        public DataContext()
            :base("CursoAngularJsContext")
        {

        }

        public DbSet<CelularModel> Celular { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new CelularConfiguration());
        }
    }
}
