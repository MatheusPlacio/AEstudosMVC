using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class AluguelMap : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.HasKey(x => x.AluguelId);
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.MesId).IsRequired();
            builder.Property(x => x.Ano).IsRequired();

            builder.HasMany(x => x.Pagamentos).WithOne(x => x.Aluguel).HasForeignKey(x => x.AluguelId);

            builder.ToTable("Alugueis");
        }
    }
}
