using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CPF).IsRequired().HasMaxLength(30);
            builder.HasIndex(x => x.CPF).IsUnique();

            builder.Property(x => x.Foto).IsRequired();
            builder.Property(x => x.PrimeiroAcesso).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasMany(x => x.ProprietariosApartamentos).WithOne(x => x.Proprietario)
                   .HasForeignKey(x => x.ProprietarioId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.MoradoresApartamentos).WithOne(x => x.Morador)
                   .HasForeignKey(x => x.MoradorId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Veiculos).WithOne(x => x.Usuario).HasForeignKey(x => x.UsuarioId);
            builder.HasMany(x => x.Eventos).WithOne(x => x.Usuario).HasForeignKey(x => x.UsuarioId);
            builder.HasMany(x => x.Pagamentos).WithOne(x => x.Usuario).HasForeignKey(x => x.UsuarioId);
            builder.HasMany(x => x.Servicos).WithOne(x => x.Usuario);

            builder.ToTable("Usuarios");
        }
    }
}
