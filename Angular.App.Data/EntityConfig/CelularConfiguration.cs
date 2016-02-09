using System.Data.Entity.ModelConfiguration;

namespace Angular.App.Data.EntityConfig
{
    public class CelularConfiguration: EntityTypeConfiguration<CelularModel>
    {
        public CelularConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.Marca).IsRequired().HasMaxLength(50);
            Property(c => c.Modelo).IsRequired().HasMaxLength(50);
            Property(c => c.Cor).IsRequired().HasMaxLength(30);
            Property(c => c.TipoChip).IsRequired().HasMaxLength(30);
            Property(c => c.MemoriaInterna).IsRequired().HasMaxLength(3);

            ToTable("Celulares");
        }
    }
}
