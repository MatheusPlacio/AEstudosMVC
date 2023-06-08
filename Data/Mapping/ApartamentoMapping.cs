using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ApartamentoMapping : IEntityTypeConfiguration<Apartamento>
    {
        public void Configure(EntityTypeBuilder<Apartamento> builder)
        {
            builder.HasKey(x => x.ApartamentoId);
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Andar).IsRequired();
            builder.Property(x => x.Foto).IsRequired();
            builder.Property(x => x.ProprietarioId).IsRequired();
            builder.Property(x => x.MoradorId).IsRequired(false);

            builder.ToTable("Apartamentos");
        }
    }
}
