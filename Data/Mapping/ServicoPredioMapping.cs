using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ServicoPredioMapping : IEntityTypeConfiguration<ServicoPredio>
    {
        public void Configure(EntityTypeBuilder<ServicoPredio> builder)
        {
            builder.HasKey(x => x.ServicoPredioId);
            builder.Property(x => x.ServicoId).IsRequired();
            builder.Property(x => x.DataExecucao).IsRequired();

            builder.ToTable("ServicoPredios");
        }
    }
}
