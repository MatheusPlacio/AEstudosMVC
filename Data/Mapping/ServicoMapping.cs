using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ServicoMapping : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(x => x.ServicoId);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.UsuarioId).IsRequired();

            builder.HasMany(x => x.ServicoPredios).WithOne(x => x.Servico).HasForeignKey(x => x.ServicoId);

            builder.ToTable("Servicos");
        }
    }
}
