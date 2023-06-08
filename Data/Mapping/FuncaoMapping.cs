using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class FuncaoMapping : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(30);

            builder.HasData(
                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Morador",
                    NormalizedName = "MORADOR",
                    Descricao = "Morador do Prédio"
                },

                 new Funcao
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = "Sindico",
                     NormalizedName = "SINDICO",
                     Descricao = "Sindico do Prédio"
                 },

                   new Funcao
                   {
                       Id = Guid.NewGuid().ToString(),
                       Name = "Administrador",
                       NormalizedName = "ADMINISTRADOR",
                       Descricao = "Administrador do Prédio"
                   });

            builder.ToTable("Funcoes");
        }
    }
}
