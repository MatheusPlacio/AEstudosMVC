using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class VeiculosMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(x => x.VeiculoId);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Cor).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Marca).IsRequired().HasMaxLength(40);

            builder.Property(x => x.Placa).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.Placa).IsUnique();
            builder.Property(x => x.UsuarioId).IsRequired();

            builder.ToTable("Veiculos");

        }
    }
}
