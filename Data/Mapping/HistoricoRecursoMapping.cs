using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class HistoricoRecursoMapping : IEntityTypeConfiguration<HistoricoRecurso>
    {
        public void Configure(EntityTypeBuilder<HistoricoRecurso> builder)
        {
            builder.HasKey(x => x.HistoricoRecursosId);
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.Dia).IsRequired();
            builder.Property(x => x.MesId).IsRequired();
            builder.Property(x => x.Ano).IsRequired();

            builder.ToTable("HistoricoRecursos");
        }
    }
}
